using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class Sys_SQ_Answer
    {
        public Sys_SQ_Answer()
        {
            this._code = Guid.NewGuid().ToString();
            this.CreatedTime = DateTime.Now;
            this.IsDeleted = false;
            this.Status = 1;
        }
        /// <summary>
        /// ID
        /// </summary>		
        private long _id;
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// MID
        /// </summary>		
        private long _mid;
        public long MID
        {
            get { return _mid; }
            set { _mid = value; }
        }
        /// <summary>
        /// QID
        /// </summary>		
        private long _qid;
        public long QId
        {
            get { return _qid; }
            set { _qid = value; }
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
        /// Answer
        /// </summary>		
        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set { _answer = value; }
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
        /// CreatedTime
        /// </summary>		
        private DateTime _createdtime;
        public DateTime CreatedTime
        {
            get { return _createdtime; }
            set { _createdtime = value; }
        }
        /// <summary>
        /// LastUpdateBy
        /// </summary>		
        private string _lastupdateby;
        public string LastUpdateBy
        {
            get { return _lastupdateby; }
            set { _lastupdateby = value; }
        }
        /// <summary>
        /// LastUpdateTime
        /// </summary>		
        private DateTime? _lastupdatetime;
        public DateTime? LastUpdateTime
        {
            get { return _lastupdatetime; }
            set { _lastupdatetime = value; }
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
