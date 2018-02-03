using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace CommonModel
{
    //Sys_BankInfo
    public class Sys_BankInfo : BaseClass
    {

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
        /// PicUrl
        /// </summary>		
        private string _picurl;
        public string PicUrl
        {
            get { return _picurl; }
            set { _picurl = value; }
        }

        /// <summary>
        /// PicUrl
        /// </summary>		
        private string _linkurl;
        public string LinkUrl
        {
            get { return _linkurl; }
            set { _linkurl = value; }
        }
   

    }
}

