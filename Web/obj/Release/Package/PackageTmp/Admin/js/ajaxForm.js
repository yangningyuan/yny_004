(function () {
	/** @summary 由 {name:'',value:''}组成的数组，被用来当做ajax的数据
	 *
	 */
	function internalGetAjaxData(nameValueObjectArray) {
		/** @summary 将内部的数据转换为一个object {}
		 *
		 */
		this.toObject = function () {
			var obj = {};
			for (var i = 0; i < nameValueObjectArray.length; i++) {
				var item = nameValueObjectArray[i];
				obj[item.name] = item.value;
			}
			return obj;
		}

		function isValidStr(input) {
			if (input == undefined || input == null) {
				return false;
			}
			if (typeof input == 'string' && $.trim(input) != '') {
				return true;
			} else {
				return false;
			}

		}

		/** @summary 将内部的数据转换为一个查询字符串
		 *
		 */
		this.toQueryString = function () {
			var newArray = new Array();
			for (var i = 0; i < nameValueObjectArray.length; i++) {
				var item = nameValueObjectArray[i];
				newArray.push(item.name + '=' + item.value);
			}
			return newArray.join('&');
		}

		this.getInternalData = function () {
			return nameValueObjectArray.slice();
		}

		/** @summary 向得到的form内容中添加一些数据
		 *
		 */
		this.pushNameValue = function (name, value) {
			if (isValidStr(name) == false) {
				throw 'name必须不是一个空字符串';
			}
			if (value == undefined || value == null) {
				throw 'value不能为undefined 或 null'
			}
			nameValueObjectArray.push({ name: name, value: value });
		}


	}
	function internalAjaxFormHelper(id) {
		this.beforesubmit = function () {
			var beforesubmitBody = $('#' + id).data('beforesubmit');
			if (beforesubmitBody == undefined || beforesubmitBody == null || beforesubmitBody == '' || $.trim(beforesubmitBody) == '') {
				return function (context) {
					return true;
				}
			} else {
				return new Function('context', beforesubmitBody);
			}
		}

		this.action = function () {
			var ele = $('#' + id)[0];
			var action = undefined;
			if (ele.tagName == 'FORM') {
				action = $(ele).attr('action');
			} else {
				action = $(ele).data('action');
			}
			if (action == undefined || action == null) {
				action = '';
			}
			return action;
		}
		this.method = function () {
			var ele = $('#' + id)[0];
			var method = undefined;
			if (ele.tagName == 'FORM') {
				method = $(ele).attr('method');
			} else {
				method = $(ele).data('method');
			}
			if (method == undefined || method == null || $.trim(method) == '') {
				method = 'post';
			}
			return method;
		}

		this.resultType = function () {
			var resultType = $('#' + id).data('resulttype');
			if (resultType == null || resultType == undefined || $.trim(resultType) == '') {
				resultType = 'text';
			}
			return resultType;
		}

		this.success = function (formID) {
			var successBody = $('#' + id).data('success');
			if (successBody == undefined || successBody == null || successBody == '' || $.trim(successBody) == '') {
				return function (result, formID) {

				}
			} else {
				var successFunction = new Function('result', 'formID', successBody);
				return function (result) {
					successFunction(result, formID);
				}
			}
		}
	}
	function submitAjaxForm(id, ajaxData) {
		var helper = new internalAjaxFormHelper(id);
		$.ajax(helper.action(), {
			cache: false,
			dataType: helper.resultType(),
			method: helper.method(),
			type: helper.method(),
			data: ajaxData.getInternalData(),
			success: helper.success(id),
			async: true
		})
	}

	function beforeSubmit(e) {
		var form = $(e.target).parents('[data-ajaxform=true][id][id!=""]:first');
		if (form.length == 1) {
			var eleID = form[0].id;
			ajaxForm.submit(eleID);
		}
	}
	window.ajaxForm = {
		/** @summary 获取ajax请求所需要的数据
		 *
		 */
		getAjaxData: function (divID) {
			if (typeof (divID) != 'string') {
				throw 'divID必须是一个字符串';
			}

			var div = document.getElementById(divID);
			if (div == null || (div.tagName != 'DIV' && div.tagName != 'FORM')) {
				throw 'divID必须是一个div或form元素的ID';
			}

			var query = $('#' + divID);
			var elements = query.find('input,textarea,select').filter(':not(:disabled)');

			var ajaxData = new Array();
			for (var i = 0; i < elements.length; i++) {
				var element = elements[i];

				var name = element.name;
				if (name == '') {
					continue;
				}
				if (element.tagName == 'INPUT') {
					var type = element.type;
					if (type == 'file' || type == 'button' || type == 'reset' || type == 'submit') {
						continue;
					}
					if ((type == 'radio' || type == 'checkbox') && element.checked == false) {
						continue;
					}
					//ajaxData.push({ name: name, value: encodeURIComponent($(element).val()) });
					ajaxData.push({ name: name, value: ($(element).val()) });
				} else if (element.tagName == 'SELECT' || element.tagName == 'TEXTAREA') {
					var val = $(element).val();
					if (val == undefined || val == null) {
						continue;
					}
					//ajaxData.push({ name: name, value: encodeURIComponent(val) });
					ajaxData.push({ name: name, value: (val) });
				}
			}
			return new internalGetAjaxData(ajaxData);
		},

		/** @summary 初始化ajaxForm
		 *
		 */
		init: function () {
			$(document).on('click', ':button[data-submit=true],a[data-submit=true]', beforeSubmit);
			$(document).on('change', 'input[data-submit=true]:not([type=file]),select[data-submit=true]', beforeSubmit);
		},

		submit: function (eleID) {
			if (typeof eleID != 'string' || $.trim(eleID) == '') {
				throw 'eleID不是字符串或是空字符串';
			}
			if (($('#' + eleID)).length == 0) {
				throw '找不到id = ' + eleID + ' 的元素';
			}

			var helper = new internalAjaxFormHelper(eleID);
			var ajaxData = ajaxForm.getAjaxData(eleID);
			var result = helper.beforesubmit()({
				submit: submitAjaxForm.bind({}, eleID, ajaxData),
				pushNameValue: ajaxData.pushNameValue.bind(ajaxData),
				formID: eleID
			});

			if (result === true) {
				submitAjaxForm(eleID, ajaxData);
			}
		}
	}
})();
ajaxForm.init();
