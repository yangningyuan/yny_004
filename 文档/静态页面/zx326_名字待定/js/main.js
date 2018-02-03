$(function() {
	bindEvent();
})

function bindEvent() {
	var n = 0;
	$(".select_method ul").css("display","none");
	$(".select_method ul").eq(0).css("display","block");
	$(".select_btn .t").click(function() {
		//		$(".select_btn .t").addClass("active").siblings().removeClass("active");
		n = $(this).index();
		$(".select_btn .t").eq(n).addClass("active").siblings().removeClass("active");
			$(".select_method ul").css("display","none");
			$(".select_method ul").eq(n).css("display","block");
	})

}