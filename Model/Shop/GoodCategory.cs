using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class GoodCategory
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
        /// Name
        /// </summary>		
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// ParentCode
        /// </summary>		
        private string _parentcode;
        public string ParentCode
        {
            get { return _parentcode; }
            set { _parentcode = value; }
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
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
