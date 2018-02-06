$(function () {
    erMenu();
});
function erMenu() {
    $(".menuLi").mouseover(function () {
        $(this).find(".ermenu").show();
    });
    $(".menuLi").mouseleave(function () {
        $(this).find(".ermenu").hide();
    });
//     $(".menuLi").toggle(function(){
//          $(this).find(".ermenu").show();		 
//	},function(){
//	      $(this).find(".ermenu").hide();
//	})
}
/*function erMenu() {
	$(".menuLi").toggle(function(){
		 $(this).find(".ermenu").show();
},function(){
	  $(this).find(".ermenu").hide();
})
}*/



$(document).ready(function () {
    $(".dotBox dd").mouseover(function () {
        clearInterval(time);
        index = $(this).index();
        norzet(index);
    });
    $(".dotBox dd").mouseleave(function () {
        time = setInterval(lunbo, 3000);
    });
    $(".banner-o dd").mouseover(function () {
        clearInterval(time);
        index = $(this).index();
        norzet(index);
    });
    $(".banner-o dd").mouseleave(function () {
        time = setInterval(lunbo, 3000);
    });
    var time = setInterval(lunbo, 3000);
    var index = 0;
    function lunbo() {
        index = index == 3 ? 0 : ++index;
        norzet(index);
    }
    function norzet(index) {
        $(".dotBox dd").eq(index).addClass("activeDot").siblings().removeClass("activeDot");
        $(".banner-o dd").eq(index).fadeIn().siblings().hide();
    }
})