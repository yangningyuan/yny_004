function twbs(pageID, totalPages, onPageClick) {
	console.log('pageID : ' + pageID);
	console.log('totalPages : ' + totalPages);
	//console.log($('#' + pageID).data('twbs-pagination'));
	var twbs_pagination = $('#' + pageID).data('twbs-pagination');
	if (twbs_pagination && twbs_pagination.options.totalPages != totalPages) {
		$('#' + pageID).unbind('page').data('twbs-pagination', false).html('');
	}

	$('#' + pageID).twbsPagination({
		totalPages: totalPages,
		visiblePages: 15,
		onPageClick: onPageClick,
		first: '首页',
		prev: '上一页',
		next: '下一页',
		last: '末页'
	});
}
function paginationHelper(pid) {
	this.pageIndex = function (index) {
		if (index == undefined) {
			return $('#' + pid).data('pageindex');
		} else {
			$('#' + pid).data('pageindex', index);
		}
	}
	this.pageSize = function (size) {
		if (size == undefined) {
			return $('#' + pid).data('pagesize');
		} else {
			$('#' + pid).data('pagesize', size);
		}
	}
	this.tmpl = function (tmpl) {
		if (tmpl == undefined) {
			return $('#' + pid).data('tmpl');
		} else {
			$('#' + pid).data('tmpl', tmpl);
		}
	}
	this.container = function (container) {
		if (container == undefined) {
			return $('#' + pid).data('container');
		} else {
			$('#' + pid).data('container', container);
		}
	}
	this.id = function () {
		return pid;
	}
}

function getPaginationData(context) {
	var helper = new paginationHelper($('#' + context.formID).data('pagination'));
	context.pushNameValue('pageindex', helper.pageIndex());
	context.pushNameValue('pagesize', helper.pageSize());
}

function onPaginationSuccess(result, formID) {
	var list = result;
	var helper = new paginationHelper($('#' + formID).data('pagination'));
	$('#' + helper.container()).html('');
	$("#" + helper.tmpl()).tmpl(list.PageData).appendTo('#' + helper.container());

	twbs(helper.id(), list.TotalPage, function (event, page) {
		helper.pageIndex(page);
		ajaxForm.submit(formID);
	});
}


/* 文档
    data-pagination 放在ajaxform上，值为分页div的id
	下面的放在 data-pagination所表示的div
    data-pageindex  表示第几页，一般是1
    data-pagesize   表示每页有多少条记录
    data-tmpl       表示tmpl的id
    data-container  表示数据的容器

	json返回结果为:
	{
		PageData  :  Array 类型   本页的数据
		TotalPage :  Number 类型  总页数
	}
*/