using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class OrderDetail
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
        /// OrderCode
        /// </summary>		
        private string _ordercode;
        public string OrderCode
        {
            get { return _ordercode; }
            set { _ordercode = value; }
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
        /// GCount
        /// </summary>		
        private int _gcount;
        public int GCount
        {
            get { return _gcount; }
            set { _gcount = value; }
        }
        /// <summary>
        /// BuyPrice
        /// </summary>		
        private decimal _buyprice;
        public decimal BuyPrice
        {
            get { return _buyprice; }
            set { _buyprice = value; }
        }
        /// <summary>
        /// TotalMoney
        /// </summary>		
        private decimal _totalmoney;
        public decimal TotalMoney
        {
            get { return _totalmoney; }
            set { _totalmoney = value; }
        }
        /// <summary>
        /// CreatedTime
        /// </summary>		
        private DateTime _createdtime;
        public DateTime CreatedTime
        {
            get { return _createdtime; }
            set { _createdtime = value; }
        }
        /// <summary>
        /// CreatedBy
        /// </summary>		
        private string _createdby;
        public string CreatedBy
        {
            get { return _createdby; }
            set { _createdby = value; }
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
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
