/**
 * Created by Administrator on 2017/2/23 0023.
 */
/*判断手机或者pc*/
var userAgent = navigator.userAgent,
    isMobile = (function(){
        return userAgent.match(/.*Mobile.*/) ? true : false;
    }()),
// click =  window.click = isMobile ? "tap": "click";
    click =  window.click = isMobile ? "click": "click";
/***
 * create 操作表参数
 * @name  显示操作表的class
 * @buttons1 显示的按钮  是一个集合
 */
var create={
    name:".create-actions",
    buttons1:[
        {
            text: '删除',
            bold: true,
            color: 'danger',
            onClick: function() {
                $.confirm('你真的要删除吗?', function () {
                    $.toast("删除成功");
                });

            }
        },{
            text: '已读',
            bold: true,
            color: 'success',
            onClick: function() {
                $.alert("你选择了“已读“");
            }
        },
        {
            text: '详情',
            onClick: function() {
                $.alert("你选择了“详情“");
            }
        }
    ]
};
/**
 * load  下拉加载参数配置
 * @loading  加载flag
 * @maxItems 最多可加载的条目
 * @itemsPerLoad 每次加载添加多少条目
 * @lastIndex  上次加载的序号
 * @$JqObj  需要加载的位置
 * @html   每次需要加载的html文本
 **/
var load={
    loading : false,
    maxItems : 100,
    itemsPerLoad : 20,
    lastIndex :0,
    $JqObj : $('.infinite-scroll-bottom .list-container'),
    html : '<li class="item-content"><div class="item-inner create-actions"><div class="item-title">公告标题<p>14:22:22</p> </div> </div></li>',
    addItems:function (number,lastIndex) {
        // 生成新条目的HTML
        var html = '';
        for (var i = lastIndex + 1; i <= lastIndex + number; i++) {
            html += load.html;
        }
        // 添加新条目
        load.$JqObj.append(html);
    }
};
/*导航操作*/
var Accordion = function(el, multiple) {
    this.el = el || {};
    this.multiple = multiple || false;

    // Variables privadas
    var links = this.el.find('.link');
    // Evento
    links.on(click, {el: this.el, multiple: this.multiple}, this.dropdown)
};
Accordion.prototype.dropdown = function(e) {
    var $el = e.data.el;
    $this = $(this),
        $next = $this.next();
    if($next.css("display")=="none"){
        $next.show();
    }else {
        $next.hide();
    }
    $this.parent().toggleClass('open');

    if (!e.data.multiple) {
        $el.find('.submenu').not($next).hide(300).parent().removeClass('open');
    };
}
/*上传图片*/
function setImagePreviews(avalue) {

    var docObj = document.getElementById("doc");
    var fileList = docObj.files;

    for (var i = 0; i < fileList.length; i++) {
        if (docObj.files && docObj.files[i]) {
            var imgObjPreview = window.URL.createObjectURL(docObj.files[i]);
            $(".Register_Img").css({"background":"url("+imgObjPreview+") no-repeat","background-size": "100% 100%"});
            $(".Register_Img i").hide();
        }
    }
    return true;
}
/*操作表*/
function create_actions() {
    $(document).on(click,create.name, function () {
        $(".modal-in").remove();
        var _this=$(this);
        var buttons1 = create.buttons1;
        var buttons2 = [
            {
                text: '取消',
                bg: 'danger'
            }
        ];
        var groups = [buttons1, buttons2];
        $.actions(groups);
    })
}
/*上拉刷新*/
function Upajax() {
    $(document).on('refresh','.pull-to-refresh-content',function(e) {
        // 模拟2s的加载过程
        setTimeout(function() {
            $.alert("刷新完成");
            // 加载完毕需要重置
            $.pullToRefreshDone('.pull-to-refresh-content');
        }, 2000);
    });
}
/*下拉加载*/
function Download() {
    $(document).on('infinite', '.infinite-scroll-bottom',function() {

        // 如果正在加载，则退出
        if (load.loading) return;

        // 设置flag
        load.loading = true;

        // 模拟1s的加载过程
        setTimeout(function() {
            // 重置加载flag
            load.loading = false;

            if (load.lastIndex >= load.maxItems) {
                // 加载完毕，则注销无限加载事件，以防不必要的加载
                $.detachInfiniteScroll($('.infinite-scroll'));
                // 删除加载提示符
                $('.infinite-scroll-preloader').remove();
                return;
            }
            // 添加新条目
            load.addItems(load.itemsPerLoad, load.lastIndex);
            // 更新最后加载的序号
            load.lastIndex = $('.list-container li').length;
            //容器发生改变,如果是js滚动，需要刷新滚动
            $.refreshScroller();
        }, 1000);
    });
}


/*加载动画*/
function  Loading() {
    $.showPreloader();
    setTimeout(function () {
        $.hidePreloader();
    }, 2000);
}
$(function() {
    $(document).on("pageInit",function (e,id,$page) {
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary');
        switch (id){
            case "index":
                search.on(click, function () {
                    if (bar_header_secondary.hasClass("hide")) {
                        bar_header_secondary.removeClass("hide");
                        $('.bar-header-secondary ~ .content').css("top", "4.4rem");
                    } else {
                        bar_header_secondary.addClass("hide");
                        $('.bar-header-secondary ~ .content').css("top", "2.2rem");
                    }
                });
                var accordion = new Accordion($('#accordion'), false);
                break;
            case "login":
                Loading(); //加载动画
                break;
            case "Notice":
                console.log('notice.html');
                search.on("click", function () {
                    if (bar_header_secondary.hasClass("hide")) {
                        bar_header_secondary.removeClass("hide");
                    } else {
                        bar_header_secondary.addClass("hide");
                    }
                });
                var accordion = new Accordion($('#accordion'), false);
                /*添加操作表*/
                create.buttons1=[
                    {
                        text: '删除',
                        bold: true,
                        color: 'danger',
                        onClick: function() {
                            $.confirm('你真的要删除吗?', function () {
                                $.toast("删除成功");
                            });

                        }
                    },{
                        text: '已读',
                        bold: true,
                        color: 'success',
                        onClick: function() {
                            $.alert("你选择了“已读“");
                        }
                    },
                    {
                        text: '详情',
                        onClick: function() {
                            $.alert("你选择了“详情“");
                        }
                    }
                ];
                create_actions();
                /*上拉刷新*/
                Upajax();
                /*下拉加载*/
                load.$JqObj=$('.infinite-scroll-bottom .list-container');
                load.html='<li class="item-content"><div class="item-inner create-actions"><div class="item-title">公告标题<p>14:22:22</p> </div> </div></li>';
                // Download();
                break;
            case "Register":
                setImagePreviews();  //上传图片
                Loading();   //加载动画
                break;
            case "Setting":
                var User=$("#User"),
                    Safety=$("#Safety"),
                    Setting_User=$(".Setting-User"),
                    Setting_Safety=$(".Setting-Safety");
                User.on(click,function () {
                    $(this).addClass("active");
                    $(this).siblings().removeClass("active");
                    Setting_User.addClass("show");
                    Setting_Safety.removeClass("show");
                });
                Safety.on(click,function () {
                    $(this).addClass("active");
                    $(this).siblings().removeClass("active");
                    Setting_Safety.addClass("show");
                    Setting_User.removeClass("show");
                });
                Loading();
                var accordion = new Accordion($('#accordion'), false);
                break;
            case "User":
                var accordion = new Accordion($('#accordion'), false);
                var search = $('.search'),
                    bar_header_secondary = $('.bar-header-secondary'),
                    searchbar_cancel=$('.searchbar-cancel');
                search.on("click", function () {
                    if (bar_header_secondary.hasClass("hide")) {
                        bar_header_secondary.removeClass("hide");
                    } else {
                        bar_header_secondary.addClass("hide");
                    }
                });
                searchbar_cancel.on("click",function () {
                    bar_header_secondary.addClass("hide");
                });
                Loading();
                break;
            case "Transfer":
                search.on(click, function () {
                    if (bar_header_secondary.hasClass("hide")) {
                        bar_header_secondary.removeClass("hide");
                        $('.bar-header-secondary ~ .content').css("top", "4.4rem");
                    } else {
                        bar_header_secondary.addClass("hide");
                        $('.bar-header-secondary ~ .content').css("top", "2.2rem");
                    }
                });
                $(".buttons-tab .tab-link").on("click",function () {
                    if($(".buttons-tab .active").attr("href")=="#tab1"){
                        load.$JqObj=$('#tab1 .list-container');
                        load.html='<li class="item-content create-actions open-about"> ' +
                            '<div class="item-inner"><div class="item-title">金额：100元</div>' +
                            '<div class="item-after">2016/12/22</div> </div></li>';
                    }else {
                        load.$JqObj=$('#tab2 .list-container');
                        load.html='<li class="item-content create-actions open-about"> ' +
                            '<div class="item-inner"><div class="item-title">金额：200元</div>' +
                            '<div class="item-after">2016/12/22</div> </div></li>';
                    }
                    load.addItems(20,0);  //预先加载20条
                });
                if($(".buttons-tab .active").attr("href")=="#tab1")
                /*下拉加载*/
                $.attachInfiniteScroll($(".infinite-scroll-bottom"));
                // Download();
                /*添加操作表*/
                create.buttons1=[
                    {
                        text: '删除',
                        bold: true,
                        color: 'danger',
                        onClick: function() {
                            $.confirm('你真的要删除吗?', function () {
                                $.toast("删除成功");
                            });
                        }
                    },
                    {
                        text: '详情',
                        onClick: function() {
                            $.popup('.popup-about');
                            // $.alert("你选择了“详情“");
                        }
                    }
                ];
                create_actions();
                var accordion = new Accordion($('#accordion'), false);
                break;
        }
    });
    $.init();
});
