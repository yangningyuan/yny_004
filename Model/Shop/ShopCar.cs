using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class ShopCar
    {

        /// <summary>
        /// Id
        /// </summary>		
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Code
        /// </summary>		
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        /// <summary>
        /// MID
        /// </summary>		
        private string _mid;
        public string MID
        {
            get { return _mid; }
            set { _mid = value; }
        }
        /// <summary>
        /// GId
        /// </summary>		
        private int _gid;
        public int GId
        {
            get { return _gid; }
            set { _gid = value; }
        }
        /// <summary>
        /// GType
        /// </summary>		
        private string _gtype;
        public string GType
        {
            get { return _gtype; }
            set { _gtype = value; }
        }
        /// <summary>
        /// GCount
        /// </summary>		
        private int _gcount;
        public int GCount
        {
            get { return _gcount; }
            set { _gcount = value; }
        }
        /// <summary>
        /// AddTime
        /// </summary>		
        private DateTime _addtime;
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        /// <summary>
        /// AddBy
        /// </summary>		
        private string _addby;
        public string AddBy
        {
            get { return _addby; }
            set { _addby = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// IsDeleted
        /// </summary>		
        private bool _isdeleted;
        public bool IsDeleted
        {
            get { return _isdeleted; }
            set { _isdeleted = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private int _status;
        /// <summary>
        /// 购物车状态：1、加入购物车；2、购物车提交订单(不在购物车列表页面显示)
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private decimal _buyprice;
        public decimal BuyPrice
        {
            get { return _buyprice; }
            set { _buyprice = value; }
        }

    }
}
