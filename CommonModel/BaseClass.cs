using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonModel
{
    public class BaseClass
    {

        /// <summary>
        /// Id
        /// </summary>		
        private long _id;
        public long Id
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
        /// UpdatedTime
        /// </summary>		
        private DateTime? _updatedtime;
        public DateTime? UpdatedTime
        {
            get { return _updatedtime; }
            set { _updatedtime = value; }
        }
        /// <summary>
        /// UpdatedBy
        /// </summary>		
        private string _updatedby;
        public string UpdatedBy
        {
            get { return _updatedby; }
            set { _updatedby = value; }
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
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// Status
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
