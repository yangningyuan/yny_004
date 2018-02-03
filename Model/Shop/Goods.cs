using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class Goods
    {
        /// <summary>
        /// 商品编号
        /// </summary>
        public int GID { get; set; }
        public string GoodsCode { get; set; }//服务编码
        public string GParentCode { get; set; }//种类编码
        public string GParentName { get; set; }//种类名称
        public string GName { get; set; }//服务名称
        public string Unit { get; set; }//单位
        public decimal CostPrice { get; set; }//原价
        public decimal CostPV { get; set; }//原价PV
        public decimal MemberPrice { get; set; }//会员价
        public decimal MemberPV { get; set; }//会员PV
        public decimal GroupPrice { get; set; }//团购价
        public decimal GroupPV { get; set; }//团购PV
        public string ImageAddr { get; set; }//图片路径
        /// <summary>
        /// 已售出数量
        /// </summary>
        public int SelledCount { get; set; }//已发货数量
        /// <summary>
        /// 库存数量
        /// </summary>
        public int SellingCount { get; set; }//
        public bool IsDeleted { get; set; }//是否已删除
        public int Status { get; set; }//状态
        public string Remark { get; set; }//备注说明
        public List<Model.GoodsPic> GoodsPic { get; set; }//商品图片
    }
}
