
window.MobileSelectAll = function () {
    function Refresh() {
        var items = $('.select_item');
        var selected_count = items.filter(':checked').length;
        if (items.length > 0 && items.length == selected_count) {
            $('.select_all').prop('checked', true);
        } else {
            $('.select_all').prop('checked', false);
        }
    }
    $('.select_item').unbind('click').bind('click', function () {
        Refresh();
    });
    $('.select_all').unbind('click').bind('click', function () {
        if ($(this).prop('checked') == true) {
            $('.select_item').prop('checked', true);
        } else {
            $('.select_item').prop('checked', false);
        }
        Refresh();
    });
}