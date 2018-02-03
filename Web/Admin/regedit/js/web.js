(function($) {
	
	$(".refresh").click(function(){window.location.reload();});
	
	 /*删除一条数据*/
	 $(".delete").click(function(){
	 	var self = $(this);
	 	var id = self.attr('data-id');
	 	var posturl = self.attr('data-url');
	 	layer.confirm('确定删除吗？',{icon: 3, title:'删除确认'}, function(index){
	 		layer.close(index);
			$.post(posturl,{id:id},function(data){
				if(data=='ok'){
					layer.msg('已删除！',{icon:1,time:500},function(){
						if($("#tr_"+id).length>0){
							$("#tr_"+id).remove();
						}else{
							window.location.reload();
						}
					});
				}else{
					layer.alert(data);
					return false;
				}
			});
	    		return false;
		});
	 });
	
	if($('.province').length>0){ 
    	$('.province').each(function(){
            var ele=$(this);
            var provinceurl = base_url+'/web/ajax/province';
            var selected_provinceid = $(this).attr('province-selected');  
            //根据province表单上面的属性设置选中的城市id和省份id
            $.post(provinceurl,'',function(data){
                //var data = jQuery.parseJSON(result);
                var prohtml = '';
                $.each(data, function(i, value) {
                    prohtml += '<option value="'+value.provinceid+'" '+(value.provinceid==selected_provinceid?'selected':'')+'>'+value.province+'</option>';
                });
                ele.empty().append(prohtml);
                ele.find('option:selected').change();
            },'json');
        });
    }
    // 省份点击，城市更换
    $(".province").change(function(){
        var provinceid = $(this).val();
        var ele = $(this);
        if(provinceid){
            var cityurl = base_url+'/web/ajax/city';
            var selected_cityid = $(this).attr('city-selected');
            var selected_areaid = $(this).attr('area-selected');
            $.post(cityurl,{provinceid:provinceid},function(data){
            	var cityhtml = '<select class="pull-left select city form-control" style="width:140px;margin-left:10px;display:inline-block;" name="cityid" area-selected="'+selected_areaid+'"><option value="0">选择城市</option>';
                $.each(data, function(i, value) {
                    cityhtml += '<option value="'+value.cityid+'">'+value.city+'</option>';
                });
                cityhtml += '</select>';
                ele.parent().find('.city').remove();
                ele.parent().find('.area').remove();
                ele.after(cityhtml);
                var cityselect = ele.parent().find('.city');
                if(selected_cityid){  //设置默认的值选中，主要用于编辑的时候存在值，直接读取
                    if(cityselect.find("option[value='"+selected_cityid+"']").length>0){
                        cityselect.val(selected_cityid);
                        cityselect.find('option:selected').change();
                    }
                }
            },'json');
        }
        
    }); 
	// 城市点击，地区更换
    $(document).on('change','.city',function(){
        var cityid = $(this).val();
        var ele = $(this);
        if(cityid){
            var areaurl = base_url+'/web/ajax/area';
            var selected_areaid = $(this).attr('area-selected');
            $.post(areaurl,{cityid:cityid},function(data){
                var areahtml = '<select class="pull-left select area  form-control" style="width:140px;display:inline-block;margin-left:10px;" name="areaid">';
                $.each(data, function(i, value) {
                    areahtml += '<option value="'+value.areaid+'">'+value.area+'</option>';
                });
                areahtml += '</select>';
                ele.parent().find('.area').remove();
                ele.after(areahtml);
                if(selected_areaid){  //设置默认的值选中，主要用于编辑的时候存在值，直接读取
                    var areaselect = ele.parent().find('.area');
                    if(areaselect.find("option[value='"+selected_areaid+"']").length>0){
                        areaselect.val(selected_areaid);
                    }
                }
            },'json');
        }
    }); 


})(jQuery);

//最大
function max2num(num,len){
	if(arguments[1]!=undefined){
		var lenght = len;
	}else{
		var lenght =  2;
	}
    if(num){
    	lenght = parseInt(lenght)+1;
    	//typeof(maxPriceLen)
    	if(num.toString().indexOf(".") == -1 || num.toString().indexOf(".") == null ){
    		return num;
    	}else{
    		num = num.toString().substring(0,num.toString().indexOf(".")+lenght)
    		return parseFloat(num);
    	}
    }else{
        return '0';
    }
}

//最大
function max2num(num,len){
    if(arguments[1]!=undefined){
        var lenght = len;
    }else{
        var lenght =  2;
    }
    if(num){
        lenght = parseInt(lenght)+1;
        //typeof(maxPriceLen)
        if(num.toString().indexOf(".") == -1 || num.toString().indexOf(".") == null ){
            return num;
        }else{
            num = num.toString().substring(0,num.toString().indexOf(".")+lenght)
            return parseFloat(num);
        }
    }else{
        return '0';
    }
}

//得到浮点数相乘的精确结果
function accMul(arg1,arg2)
{
    var m=0,s1=arg1.toString(),s2=arg2.toString();
    try{m+=s1.split(".")[1].length}catch(e){}
    try{m+=s2.split(".")[1].length}catch(e){}
    return Number(s1.replace(".",""))*Number(s2.replace(".",""))/Math.pow(10,m);
}
//返回值：arg1加上arg2的精确结果
function accAdd(arg1,arg2){
    var r1,r2,m;
    try{r1=arg1.toString().split(".")[1].length}catch(e){r1=0}
    try{r2=arg2.toString().split(".")[1].length}catch(e){r2=0}
    m=Math.pow(10,Math.max(r1,r2));
    return (arg1*m+arg2*m)/m;
}
//返回值：arg1除以arg2的精确结果
function accDiv(arg1,arg2){
    var t1=0,t2=0,r1,r2;
    try{t1=arg1.toString().split(".")[1].length}catch(e){}
    try{t2=arg2.toString().split(".")[1].length}catch(e){}
    with(Math){
        r1=Number(arg1.toString().replace(".",""));
        r2=Number(arg2.toString().replace(".",""));
        return (r1/r2)*pow(10,t2-t1);
    }
}

function round2(number,fractionDigits){
    var nm = number.split('.');
    if(nm[1] && nm[1].length>fractionDigits){
        with(Math){
            return round(number*pow(10,fractionDigits))/pow(10,fractionDigits);
        }
    }else{
        return number;
    } 
}


//只能输入数字
function enforceNum(id) {
    $(document).on("keyup blur",'#'+id, function () {
        $("#"+id).val($("#"+id).val().replace(/[^0-9-]+/, ''));
    });
}

//输入价格判断
function enforceMoney(id) {
    $(document).on("keyup blur",'#'+id, function () {
        $("#"+id).val($("#"+id).val().replace(/[^\d+(\.\d+)?]/, ''));
    });
}
