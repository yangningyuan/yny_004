using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class GoodsPic
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
        /// GId
        /// </summary>		
        private string _gid;
        public string GId
        {
            get { return _gid; }
            set { _gid = value; }
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
        /// PicURL
        /// </summary>		
        private string _picurl;
        public string PicURL
        {
            get { return _picurl; }
            set { _picurl = value; }
        }
        /// <summary>
        /// PicSize
        /// </summary>		
        private int _picsize;
        public int PicSize
        {
            get { return _picsize; }
            set { _picsize = value; }
        }
        /// <summary>
        /// IsMain
        /// </summary>		
        private bool _ismain;
        public bool IsMain
        {
            get { return _ismain; }
            set { _ismain = value; }
        }
        /// <summary>
        /// Decription
        /// </summary>		
        private string _decription;
        public string Decription
        {
            get { return _decription; }
            set { _decription = value; }
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
