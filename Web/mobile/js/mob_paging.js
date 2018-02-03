
(function ($) {
    function MobPaging(_itemsPerPage, _dataGetter, _dataRender, rendered, other) {
        var currentPage = 1;
        var itemsPerPage = _itemsPerPage;
        var dataGetter = _dataGetter;
        var dataRender = _dataRender;
        var totalPages;
        var totalItems;
        var _this = this;

        this.GetCurrentPage = function () {
            return currentPage;
        }

        this.SetCurrentPage = function (value) {
            value = parseInt(value);
            if (isNaN(value) || value <= 0) value = 1;
            currentPage = value;
             if (currentPage > totalPages) {
                currentPage = totalPages;
            }
            if (currentPage <= 0) {
                currentPage = 1;
            }
            _this.Refresh();
        }

        this.GetTotalItems = function () {
            return totalItems;
        }

        this.GetTotalPages = function () {
            return totalPages;
        }

        this.Refresh = function () {
            dataGetter.GetData(currentPage, itemsPerPage, function (data) {
                totalItems = data.TotalCount;   //总记录数
                totalPages = Math.ceil(totalItems / itemsPerPage);  //总页数

                dataRender.RenderData(data.Items);  //渲染数据
                if (typeof rendered === 'function') {
                    rendered();
                }
                dataRender.RenderPaging(_this);  //渲染分页
            }); //获取数据
        }
        this.ReQuery = function () {
            _this.SetCurrentPage(1);
        }
        this.Refresh();
        if (typeof other == 'function') {
            other.call(_this);
        }
    }

    function AjaxDataGetter(queryFormSelector, url) {
        if (!queryFormSelector) queryFormSelector = '';
        this.GetData = function (currentPage, itemsPerPage, callback) {
            var data = $(queryFormSelector).serializeArray();
            data.push({ name: 'CurrentPage', value: currentPage })
            data.push({ name: 'ItemsPerPage', value: itemsPerPage });
            $.post(url, data, callback, 'json');
        }
    }

    function TmplDataRender(tmplSelector, dataContainerSelector, pageContainerSelector) {
        this.RenderData = function (items) {
            $(dataContainerSelector).empty().append($(tmplSelector).tmpl(items));
        }
        this.RenderPaging = function (paging) {
            var pagingTmpl = '<a href="javascript:void(0)" title="" class="previous_page">上一页</a>' +
            '<input type="text" name="" value="" class="yema" >' +
            '<a href="javascript:void(0)" title="" class="tiaozhuan background_1">跳转</a>' +
            '<a href="javascript:void(0)" title="" class="next_page background_2">下一页</a>';
            var pt = $(pagingTmpl);
            $(pageContainerSelector).empty().append(pt);
            var pt = $(pageContainerSelector);
            pt.find('.yema').val(paging.GetCurrentPage());
            if (paging.GetCurrentPage() == 1) {
                pt.find('.previous_page').css('background-color', 'gray').addClass('p_disabled');
            }
            if (paging.GetTotalPages() == 0 || paging.GetCurrentPage() == paging.GetTotalPages()) {
                pt.find('.next_page').css('background-color', 'gray').addClass('p_disabled');
            }
            pt.find('.previous_page:not(.p_disabled)').click(function () {
                var ct = paging.GetCurrentPage();
                paging.SetCurrentPage(ct - 1);
            });

            pt.find('.next_page:not(.p_disabled)').click(function () {
                var ct = paging.GetCurrentPage();
                paging.SetCurrentPage(ct + 1);
            });
            pt.find('.tiaozhuan').click(function () {
                var ct = pt.find('.yema').val();
                paging.SetCurrentPage(ct);
            });
        }
    }

    var _defaultConfig = {
        QueryContainer: '',  //form 的id
        DataContainer: '',  //存放列表数据的容器的选择器
        DataUrl: '',   //获取数据的地址
        TemplateContainer: '',   //jquery tmpl 模板选择器
        Rendered: function () {  //在数据显示之后执行
        }
    };

    $.fn.extend({
        Paging: function (config) {
            config = $.extend({}, _defaultConfig, config);

            if (this.length == 0) {
                throw '没有符合条件的元素';
            }
            var firstEle = this[0];
            if (!firstEle.id) {
                throw '分页容器必须要有ID';
            }
            var pagingObject = $(firstEle).data('Paging');
            if (!pagingObject) {
                var eleid = firstEle.id;
                pagingObject = new MobPaging(20, new AjaxDataGetter(config.QueryContainer, config.DataUrl), new TmplDataRender(config.TemplateContainer, config.DataContainer, '#' + eleid), config.Rendered, function () {
                    $(config.QueryContainer).find('.requery:button').bind('click', this.ReQuery);
                    $(config.QueryContainer).find('a.requery').bind('click', this.ReQuery);
                    $(config.QueryContainer).find('select.requery').bind('change', this.ReQuery);
                    $(config.QueryContainer).find(':radio.requery').bind('change', this.ReQuery);
                    $(config.QueryContainer).find(':checkbox.requery').bind('change', this.ReQuery);
                });
                $(firstEle).data('Paging', pagingObject);
            }
            return pagingObject;
        }
    });
})(jQuery);