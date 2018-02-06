/**
 * Created by qb on 2016/11/24.
 */
//$(function(){
//    var move_list=document.querySelectorAll('.nav1_move>li');
//    var ul_width=0;
//    for(var i= 0;i<move_list.length;i++){
//        ul_width+=parseFloat($(move_list[i]).css('width'));
//    }
//    var screenWidth=parseFloat(window.screen.availWidth);

//    $('.nav1_move').css('width',ul_width+'px').css('min-width',screenWidth);
//    var nav1_move_width=parseFloat($('.nav1_move').css('width'));
//    console.log(screenWidth,nav1_move_width);
//    if(screenWidth!=nav1_move_width){
//        var nav_width=parseFloat($('#nav1').css('width'));
//        var max_left=(ul_width)-nav_width;
//        var startX,endX,moveX,nowleft;
//        var left=parseFloat($('.nav1_move').css('left'));
//        $('#nav1').on('touchstart',function(e){
//            var touch = e.originalEvent.targetTouches[0];
//            //$(touch.target).addClass('borderB').siblings().removeClass('borderB');
//            startX=touch.pageX;
//            left=parseFloat($('.nav1_move').css('left'));
//        });
//        $('#nav1').on('touchmove',function(e){
//            $('#nav1 .nav1-tan').fadeOut();
//            var touch = e.originalEvent.targetTouches[0];
//            moveX=touch.pageX;
//            nowleft=parseFloat($('.nav1_move').css('left'));
//            if(nowleft<0&&nowleft>-max_left){
//                $('.nav1_move').css('left',left+(moveX-startX)+'px');
//            }else{
//                $('.nav1_move').css('left',left+(moveX-startX)+'px');
//            }

//            //else if(nowleft>=0){
//            //    //$('.nav1_move').css('left',left+(moveX-startX)+'px');
//            //    $('.nav1_move').css('left',left+'px');
//            //}else{
//            //    $('.nav1_move').css('left',max_left+'px');
//            //}

//        });
//        $('#nav1').on('touchend',function(e){
//            var touch = e.originalEvent.changedTouches[0];
//            endX=touch.pageX;
//            nowleft=parseFloat($('.nav1_move').css('left'));
//            if(nowleft>0){
//                $('.nav1_move').animate({left:'0'},200);
//            }else if(nowleft<-max_left){
//                $('.nav1_move').animate({left:-max_left+'px'},200);
//            }
//        });
//        $('#nav1').on('click','ul.nav1_move>li',function(event){

//            $(this).children('ul').slideToggle(200);
//            $(this).siblings().children('ul').slideUp(200);
//            var li_index=$(this).index();
//            var li_width=0;
//            for(var i=0;i<li_index;i++){
//                li_width+=parseFloat($(move_list[i]).css('width'));
//            }
//            if(-li_width>-max_left){
//                $('.nav1_move').animate({left:-li_width+'px'},200);
//            }else{
//                $('.nav1_move').animate({left:-max_left+'px'},200);
//            }
//        });
//    }else{
//        $('#nav1').on('click','ul.nav1_move>li',function(event){
//            event.preventDefault();
//            $(this).children('ul').slideToggle(200);
//            $(this).siblings().children('ul').slideUp(200);
//            //var li_index=$(this).index();
//            //var li_width=0;
//            //for(var i=0;i<li_index;i++){
//            //    li_width+=parseFloat($(move_list[i]).css('width'));
//            //}
//            //if(-li_width>-max_left){
//            //    $('.nav1_move').animate({left:-li_width+'px'},200);
//            //}else{
//            //    $('.nav1_move').animate({left:-max_left+'px'},200);
//            //}
//        });
//    }



//})

function add(object){
    var prev=parseInt($(object).prev().val());
    console.log(prev);
    $(object).prev().val(prev+1+'');
}
function reduce(object){
    var next=parseInt($(object).next().val());
    if($(object).next().val()>1){
        $(object).next().val(next-1+'');
    }

}
