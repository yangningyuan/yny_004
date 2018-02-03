using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonModel
{
    public class Sys_Language : BaseClass
    {
        /// <summary>
        /// Name
        /// </summary>		
        private string _zhname;
        public string ZHName
        {
            get { return _zhname; }
            set { _zhname = value; }
        }
        /// <summary>
        /// PicUrl
        /// </summary>		
        private string _enname;
        public string ENName
        {
            get { return _enname; }
            set { _enname = value; }
        }

        private long _sort;
        public long Sort
        {
            get { return _sort; }
            set { _sort = value; }
        }
        /// <summary>
        /// 语言编号
        /// </summary>
        public string LanguageCode
        {
            get;
            set;
        }

    }
}
