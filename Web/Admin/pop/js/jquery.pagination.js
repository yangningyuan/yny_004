/**
* This jQuery plugin displays pagination links inside the selected elements.
* 
* This plugin needs at least jQuery 1.4.2
*
* @author Gabriel Birke (birke *at* d-scribe *dot* de)
* @version 2.0rc
* @param {int} maxentries Number of entries to paginate
* @param {Object} opts Several options (see README for documentation)
* @return {Object} jQuery Object
*/
var pagination = (function ($) {
    /**
    * @class Class for calculating pagination values
    */
    $.PaginationCalculator = function (maxentries, opts) {
        this.maxentries = maxentries;
        this.opts = opts;
    }

    $.extend($.PaginationCalculator.prototype, {
        /**
        * Calculate the maximum number of pages
        * @method
        * @returns {Number}
        */
        numPages: function () {
            return Math.ceil(this.maxentries / this.opts.items_per_page);
        },
        /**
        * Calculate start and end point of pagination links depending on 
        * current_page and num_display_entries.
        * @returns {Array}
        */
        getInterval: function (current_page) {
            var ne_half = Math.ceil(this.opts.num_display_entries / 2);
            var np = this.numPages();
            var upper_limit = np - this.opts.num_display_entries;
            var start = current_page > ne_half ? Math.max(Math.min(current_page - ne_half, upper_limit), 0) : 0;
            var end = current_page > ne_half ? Math.min(current_page + ne_half, np) : Math.min(this.opts.num_display_entries, np);
            return { start: start, end: end };
        }
    });

    // Initialize jQuery object container for pagination renderers
    $.PaginationRenderers = {}

    /**
    * @class Default renderer for rendering pagination links
    */
    $.PaginationRenderers.defaultRenderer = function (maxentries, opts) {
        this.maxentries = maxentries;
        this.opts = opts;
        this.pc = new $.PaginationCalculator(maxentries, opts);
    }
    $.extend($.PaginationRenderers.defaultRenderer.prototype, {
        /**
        * Helper function for generating a single link (or a span tag if it's the current page)
        * @param {Number} page_id The page id for the new item
        * @param {Number} current_page 
        * @param {Object} appendopts Options for the new item: text and classes
        * @returns {jQuery} jQuery object containing the link
        */
        createLink: function (page_id, current_page, appendopts) {
            var lnk, np = this.pc.numPages();
            page_id = page_id < 0 ? 0 : (page_id < np ? page_id : np - 1); // Normalize page id to sane value
            appendopts = $.extend({ text: page_id + 1, classes: "" }, appendopts || {});
            if (page_id < 0) {
                page_id = 0;
            }
            if (current_page < 0) {
                current_page = 0;
            }
            if (page_id == current_page) {
                lnk = $("<li class='active'><a>" + appendopts.text + "</a></li>");
                if (appendopts.classes) { lnk.attr("class", appendopts.classes); }
            }
            else {
                lnk = $("<a>" + appendopts.text + "</a>").attr('href', this.opts.link_to.replace(/__id__/, page_id));
                lnk.data('page_id', page_id);
                lnk = $("<li></li>").append(lnk);
            }
            return lnk;
        },
        createJumpLink: function (current_page, eventHandler, appendopts) {//跳转
            var np = this.pc.numPages();
            lnk = $("<a style='background-color: #428bca; border-color: #428bca; color: #fff;'>" + this.opts.jump_text + "</a>").attr('href', this.opts.link_to.replace(/__id__/, 0));
            lnk = $("<li style='float: right;'></li>").append(lnk);
            $(lnk).bind("click", function () {
                /***************判断当前数字********************/
                var index = jQuery("#jump-index").val();
                if (/^\d+$/.test(index)) {
                    if (index > np) {
                        index = np;
                    } else if (index < 1) {
                        index = 1;
                    }
                } else {
                    index = 1;
                }
                index = index - 1;
                /***************判断当前数字********************/
                if (index != current_page) {
                    eventHandler(parseInt(index));
                }
            });
            return lnk;
        },
        // Generate a range of numeric links 
        appendRange: function (container, current_page, start, end) {
            var i;
            for (i = start; i < end; i++) {
                this.createLink(i, current_page).appendTo(container);
            }
        },
        getLinks: function (current_page, eventHandler) {
            var begin, end,
				interval = this.pc.getInterval(current_page),
				np = this.pc.numPages(),
				fragment = $("<ul class='pagination pagination-centered margin-none'></ul>");

            // Generate "isFirst"-Link
            if (this.opts.isFirst) {
                fragment.append(this.createLink(0, current_page, { text: this.opts.first_text, classes: "disabled" }));
            }

            // Generate "Previous"-Link
            if (this.opts.prev_text && (current_page > 0 || this.opts.prev_show_always)) {
                fragment.append(this.createLink(current_page - 1, current_page, { text: this.opts.prev_text, classes: "disabled" }));
            }
            // Generate starting points
            if (interval.start > 0 && this.opts.num_edge_entries > 0) {
                end = Math.min(this.opts.num_edge_entries, interval.start);
                this.appendRange(fragment, current_page, 0, end);
                if (this.opts.num_edge_entries < interval.start && this.opts.ellipse_text) {
                    jQuery("<li>" + this.opts.ellipse_text + "</li>").appendTo(fragment);
                }
            }
            // Generate interval links
            this.appendRange(fragment, current_page, interval.start, interval.end);
            // Generate ending points
            if (interval.end < np && this.opts.num_edge_entries > 0) {
                if (np - this.opts.num_edge_entries > interval.end && this.opts.ellipse_text) {
                    jQuery("<li>" + this.opts.ellipse_text + "</li>").appendTo(fragment);
                }
                begin = Math.max(np - this.opts.num_edge_entries, interval.end);
                this.appendRange(fragment, current_page, begin, np);
            }
            // Generate "Next"-Link
            if (this.opts.next_text && (current_page < np - 1 || this.opts.next_show_always)) {
                fragment.append(this.createLink(current_page + 1, current_page, { text: this.opts.next_text, classes: "disabled" }));
            }

            // Generate "isFirst"-Link
            if (this.opts.isFirst) {
                fragment.append(this.createLink(np, current_page, { text: this.opts.last_text, classes: "disabled" }));
            }

            // Generate "Sum"-Link 
            if (this.opts.isSum) {
                //                fragment.append("<li><a class='paginationTotal'>共&nbsp;" + this.maxentries + "&nbsp;条记录</a></li>");
                fragment.append("<li><a class='paginationTotal'>" + this.opts.total_text.replace('{0}', this.maxentries) + "</a></li>");
            }

            $('a[href]', fragment).click(eventHandler); //点击事件

            // Generate "Jump"-Link 
            if (this.opts.isJump) {
                if (this.maxentries == 0) {
                    // Generate Jump Input
                    fragment.append($("<input type='text' style='width: 50px; height: 34px;' id='jump-index' maxlength='4' value='" + (current_page) + "'/>"));
                }
                else {
                    // Generate Jump Input
                    fragment.append($("<input type='text' style='width: 50px; height: 34px;' id='jump-index' maxlength='4' value='" + (current_page + 1) + "'/>"));
                }
                // Generate Jump Handler
                this.createJumpLink(current_page, eventHandler).appendTo(fragment);
            }
            return fragment;
        }
    });

    // Extend jQuery
    $.fn.pagination = function (maxentries, opts) {

        // Initialize options with default values
        opts = jQuery.extend({
            items_per_page: 10,
            num_display_entries: 10,
            current_page: 0,
            num_edge_entries: 2,
            link_to: "javascript:void(0);",
            prev_text: "Prev",
            next_text: "Next",
            total_text: "total {0} record",
            jump_text: "Jump",
            first_text: "First Page",
            last_text: "Last Page",
            isFirst: true,
            isSum: true,
            isJump: true,
            ellipse_text: "<a>...</a>",
            prev_show_always: true,
            next_show_always: true,
            renderer: "defaultRenderer",
            callback: function () { return false; }
        }, opts || {});

        var containers = this,
		renderer, links, current_page;

        /**
        * This is the event handling function for the pagination links. 
        * @param {int} page_id The new page number
        */
        function pageSelected(evt) {
            var links, current_page = $(evt.target).data('page_id');
            if (!current_page && current_page != 0)
                current_page = evt;
            containers.data('current_page', current_page);
            links = renderer.getLinks(current_page, pageSelected);
            containers.empty();
            links.appendTo(containers);
            var continuePropagation = opts.callback(current_page, containers);
            if (!continuePropagation) {
                if (evt.stopPropagation) {
                    evt.stopPropagation();
                }
                else {
                    evt.cancelBubble = true;
                }
            }
            return continuePropagation;
        }

        current_page = opts.current_page;
        containers.data('current_page', current_page);
        // Create a sane value for maxentries and items_per_page
        //maxentries = (!maxentries || maxentries < 0) ? 1 : maxentries;
        opts.items_per_page = (!opts.items_per_page || opts.items_per_page < 0) ? 1 : opts.items_per_page;

        if (!$.PaginationRenderers[opts.renderer]) {
            throw new ReferenceError("Pagination renderer '" + opts.renderer + "' was not found in jQuery.PaginationRenderers object.");
        }
        renderer = new $.PaginationRenderers[opts.renderer](maxentries, opts);

        containers.each(function () {
            // Attach control functions to the DOM element 
            this.selectPage = function (page_id) { pageSelected(page_id); }
            this.prevPage = function () {
                var current_page = containers.data('current_page');
                if (current_page > 0) {
                    pageSelected(current_page - 1);
                    return true;
                }
                else {
                    return false;
                }
            }
            this.nextPage = function () {
                var current_page = containers.data('current_page');
                if (current_page < numPages() - 1) {
                    pageSelected(current_page + 1);
                    return true;
                }
                else {
                    return false;
                }
            }
        });
        // When all initialisation is done, draw the links
        links = renderer.getLinks(current_page, pageSelected);
        containers.empty();
        links.appendTo(containers);
        // call callback function，注释防止读取两遍
        //opts.callback(current_page, containers);
    }
})(jQuery);
