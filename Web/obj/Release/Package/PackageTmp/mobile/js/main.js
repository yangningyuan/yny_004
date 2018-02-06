/**
 * Created by Administrator on 2017/2/23 0023.
 */
//日期选择器
 $("#city-picker").cityPicker({
    toolbarTemplate: '<header class="bar bar-nav">\
    <button class="button button-link pull-right close-picker">确定</button>\
    <h1 class="title">选择收货地址</h1>\
    </header>'
  });
/*判断手机或者pc*/
var userAgent = navigator.userAgent,
    isMobile = (function(){
        return userAgent.match(/.*Mobile.*/) ? true : false;
    }()),
// click =  window.click = isMobile ? "tap": "click";
    click =  window.click = isMobile ? "click": "click";
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
    var $el = e.data.el,
       $this = $(this);
    $this.parent().siblings().removeClass("open");
    $this.parent().addClass("open");
    // $this = $(this),
    //     $next = $this.next();
    // if($next.css("display")=="none"){
    //     $next.show();
    // }else {
    //     $next.hide();
    // }
    // $this.parent().toggleClass('open');
    //
    // if (!e.data.multiple) {
    //     $el.find('.submenu').not($next).hide(300).parent().removeClass('open');
    // };
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

/*加载动画*/
function  Loading() {
    $.showPreloader();
    setTimeout(function () {
        $.hidePreloader();
    }, 2000);
}

/**
 * sui 路由
 * pageInit 初始化触发的事件  #index 页面page的ID  function  页面加载的方法
 * $(document).on("pageInit","#index",function (e,id,$page){}
 **/
$(function() {
    $(document).on("pageInit","#index",function (e,id,$page) {
        console.log("index");
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary');
        search.on(click, function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
                $('.bar-header-secondary ~ .content').css("top", "5.6rem");
            } else {
                bar_header_secondary.addClass("hide");
                $('.bar-header-secondary ~ .content').css("top", "3.4rem");
            }
        });
        var accordion = new Accordion($('#accordion'), false);
    });

    $(document).on("pageInit","#login",function (e,id,$page) {
        console.log("login");
        Loading(); //加载动画
    });

    $(document).on("pageInit","#Notice",function (e,id,$page) {
        console.log('notice.html');
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary');
        search.on("click", function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
            } else {
                bar_header_secondary.addClass("hide");
            }
        });
        var accordion = new Accordion($('#accordion'), false);
        /*添加操作表*/
        $($page).on('click','.create-actions', function () {
            var buttons1=[
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
                        $.popup('.popup-about');
                        // $.alert("你选择了“详情“");
                    }
                }
            ];
            var buttons2 = [
                {
                    text: '取消',
                    bg: 'danger'
                }
            ];
            var groups = [buttons1, buttons2];
            $.actions(groups);
        });
        /*上拉刷新*/
        Upajax();
        /*下拉加载*/
        var loading = false;
        // 每次加载添加多少条目
        var itemsPerLoad = 20;
        // 最多可加载的条目
        var maxItems = 100;
        var lastIndex = $('.list-container li').length;
        function addItems(number, lastIndex) {
            // 生成新条目的HTML
            var html = '';
            for (var i = lastIndex + 1; i <= lastIndex + number; i++) {
                html += '<li class="item-content"><div class="item-inner create-actions"><div class="item-title">公告标题<p>14:22:22</p> </div> </div></li>';
            }
            // 添加新条目
            $('.infinite-scroll-bottom .list-container').append(html);
        }
        $($page).on('infinite', function() {
            // 如果正在加载，则退出
            if (loading) return;
            // 设置flag
            loading = true;
            // 模拟1s的加载过程
            setTimeout(function() {
                // 重置加载flag
                loading = false;
                if (lastIndex >= maxItems) {
                    // 加载完毕，则注销无限加载事件，以防不必要的加载
                    $.detachInfiniteScroll($('.infinite-scroll'));
                    // 删除加载提示符
                    $('.infinite-scroll-preloader').remove();
                    return;
                }
                addItems(itemsPerLoad,lastIndex);
                // 更新最后加载的序号
                lastIndex = $('.list-container li').length;
                $.refreshScroller();
            }, 1000);
        });
    });

    $(document).on("pageInit","#Register",function (e,id,$page) {
        console.log("Register");
        setImagePreviews();  //上传图片
        Loading();   //加载动画
    });

    $(document).on("pageInit","#Setting",function (e,id,$page) {
        console.log("Setting");
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
    });

    $(document).on("pageInit","#User",function (e,id,$page) {
        console.log("User");
        var accordion = new Accordion($('#accordion'), false);
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary'),
            searchbar_cancel=$('.searchbar-cancel');
        search.on(click, function () {
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
    });

    $(document).on("pageInit","#Transfer",function (e,id,$page) {
        console.log("Transfer");
        var accordion = new Accordion($('#accordion'), false);
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary'),
            searchbar_cancel=$('.searchbar-cancel');
        search.on(click, function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
            } else {
                bar_header_secondary.addClass("hide");
            }
        });
        /**下拉加载**/
        var loading = false;
        // 每次加载添加多少条目
        var itemsPerLoad = 20;
        // 最多可加载的条目
        var maxItems = 100;
        var lastIndex = $('.list-container li')[0].length;
        function addItems(number, lastIndex) {
            // 生成新条目的HTML
            var html = '';
            for (var i = lastIndex + 1; i <= lastIndex + number; i++) {
                html += '<li class="item-content create-actions open-about">' +
                    '<div class="item-inner"><div class="item-title">金额：200元</div>' +
                    '<div class="item-after">2016/12/22</div></div></li>';
            }
            // 添加新条目
            $('.infinite-scroll.active .list-container').append(html);
        }
        $($page).on('infinite', function() {
            // 如果正在加载，则退出
            if (loading) return;
            // 设置flag
            loading = true;
            var tabIndex = 0;
            if($(this).find('.infinite-scroll.active').attr('id') == "tab1"){
                tabIndex = 0;
            }
            if($(this).find('.infinite-scroll.active').attr('id') == "tab2"){
                tabIndex = 1;
            }
            lastIndex = $('.list-container').eq(tabIndex).find('li').length;
            // 模拟1s的加载过程
            setTimeout(function() {
                // 重置加载flag
                loading = false;
                if (lastIndex >= maxItems) {
                    // 加载完毕，则注销无限加载事件，以防不必要的加载
                    //$.detachInfiniteScroll($('.infinite-scroll').eq(tabIndex));
                    // 删除加载提示符
                    $('.infinite-scroll-preloader').eq(tabIndex).hide();
                    return;
                }
                addItems(itemsPerLoad,lastIndex);
                // 更新最后加载的序号
                lastIndex =  $('.list-container').eq(tabIndex).find('li').length;
                $.refreshScroller();
            }, 1000);
        });
        /**上拉刷新**/
        Upajax();
        /**添加操作表**/
        $($page).on('click','.create-actions', function () {
            var buttons1=[
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
            var buttons2 = [
                {
                    text: '取消',
                    bg: 'danger'
                }
            ];
            var groups = [buttons1, buttons2];
            $.actions(groups);
        });
    });

    $(document).on("pageInit","#info",function (e,id,$page) {
        console.log("info");
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary');
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
        $("#datetime-picker").datetimePicker({
            value: ['1985', '12', '04', '9', '34']
        });
        $("#city-picker").cityPicker({
            toolbarTemplate: '<header class="bar bar-nav">\
    <button class="button button-link pull-right close-picker">确定</button>\
    <h1 class="title">选择收货地址</h1>\
    </header>'
        });
        Loading();
    });

    $(document).on("pageInit","#Recharge",function (e,id,$page) {
        console.log("Recharge");
        var accordion = new Accordion($('#accordion'), false);
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary'),
            searchbar_cancel=$('.searchbar-cancel');
        search.on(click, function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
            } else {
                bar_header_secondary.addClass("hide");
            }
        });
        searchbar_cancel.on("click",function () {
            bar_header_secondary.addClass("hide");
        });
        $("#checkType").on("change",function () {
            if($("#checkType").attr("checked")){
                $.alert('选择立即到账会平台会收取5%的手续费');
                // $.toast("选择立即到账会平台会收取5%的手续费");
            }
        })

    });

    $(document).on("pageInit","#CurrencyExchange",function (e,id,$page) {
        console.log("CurrencyExchange");
        var accordion = new Accordion($('#accordion'), false);
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary'),
            searchbar_cancel=$('.searchbar-cancel');
        search.on(click, function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
            } else {
                bar_header_secondary.addClass("hide");
            }
        });
        searchbar_cancel.on("click",function () {
            bar_header_secondary.addClass("hide");
        });
        $("#exchange").picker({
            toolbarTemplate: '<header class="bar bar-nav" style="height: 2.2rem;">\
  <button class="button button-link pull-right close-picker">确定</button>\
  <h1 class="title">请选择币种</h1>\
  </header>',
            cols: [
                {
                    textAlign: 'center',
                    values: ['现金币', '报单币']
                }
            ]
        });
        $("#exchange1").picker({
            toolbarTemplate: '<header class="bar bar-nav" style="height: 2.2rem;">\
  <button class="button button-link pull-right close-picker">确定</button>\
  <h1 class="title">请选择要兑换的币种</h1>\
  </header>',
            cols: [
                {
                    textAlign: 'center',
                    values: ['现金币', '报单币']
                }
            ]
        });

    });

    $(document).on("pageInit","#UserList",function (e,id,$page) {
        console.log("UserList");
        var accordion = new Accordion($('#accordion'), false);
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary'),
            searchbar_cancel=$('.searchbar-cancel');
        search.on(click, function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
            } else {
                bar_header_secondary.addClass("hide");
            }
        });
        searchbar_cancel.on("click",function () {
            bar_header_secondary.addClass("hide");
        });
        var accordion = new Accordion($('#accordion'), false);
        /*添加操作表*/
        $($page).on(click,'.create-actions', function () {
            var buttons1=[
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
                        $.popup('.popup-about');
                        // $.alert("你选择了“详情“");
                    }
                }
            ];
            var buttons2 = [
                {
                    text: '取消',
                    bg: 'danger'
                }
            ];
            var groups = [buttons1, buttons2];
            $.actions(groups);
        });
        /*上拉刷新*/
        Upajax();
        /*下拉加载*/
        var loading = false;
        // 每次加载添加多少条目
        var itemsPerLoad = 20;
        // 最多可加载的条目
        var maxItems = 100;
        var lastIndex = $('.list-container li').length;
        function addItems(number, lastIndex) {
            // 生成新条目的HTML
            var html = '';
            for (var i = lastIndex + 1; i <= lastIndex + number; i++) {
                html += '<li class="item-content item-link create-actions">' +
                    '<div class="item-inner">' +
                    '<div class="item-title">李梦龙</div><div class="item-after">黄金会员</div>' +
                    '</div></li>';
            }
            // 添加新条目
            $('.infinite-scroll-bottom .list-container').append(html);
        }
        $($page).on('infinite', function() {
            // 如果正在加载，则退出
            if (loading) return;
            // 设置flag
            loading = true;
            // 模拟1s的加载过程
            setTimeout(function() {
                // 重置加载flag
                loading = false;
                if (lastIndex >= maxItems) {
                    // 加载完毕，则注销无限加载事件，以防不必要的加载
                    $.detachInfiniteScroll($('.infinite-scroll'));
                    // 删除加载提示符
                    $('.infinite-scroll-preloader').remove();
                    return;
                }
                addItems(itemsPerLoad,lastIndex);
                // 更新最后加载的序号
                lastIndex = $('.list-container li').length;
                $.refreshScroller();
            }, 1000);
        });
    });

    $(document).on("pageInit","#Encrypted",function (e,id,$page) {
        console.log("Encrypted");
        var accordion = new Accordion($('#accordion'), false);
        var search = $('.search'),
            bar_header_secondary = $('.bar-header-secondary'),
            searchbar_cancel=$('.searchbar-cancel');
        search.on(click, function () {
            if (bar_header_secondary.hasClass("hide")) {
                bar_header_secondary.removeClass("hide");
            } else {
                bar_header_secondary.addClass("hide");
            }
        });
        searchbar_cancel.on("click",function () {
            bar_header_secondary.addClass("hide");
        });
        $("#exchange").picker({
            toolbarTemplate: '<header class="bar bar-nav" style="height: 2.2rem;">\
  <button class="button button-link pull-right close-picker">确定</button>\
  <h1 class="title">请选择密保问题</h1>\
  </header>',
            cols: [
                {
                    textAlign: 'center',
                    values: ['您母亲的姓名是？', '您父亲的姓名是？','您配偶的姓名是？','您的出生地是？','对您最大影响的人是？']
                }
            ]
        });
    });

    $(document).on("pageInit","#Mail",function (e,id,$page) {
        console.log("Mail");
       $($page).on(click,".open-about",function () {
           $.popup('.popup-about');
       })
    });

    $.init();
});
