using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class IPClick
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
        /// MID
        /// </summary>		
        private string _mid;
        public string MID
        {
            get { return _mid; }
            set { _mid = value; }
        }
        /// <summary>
        /// IP
        /// </summary>		
        private string _ip;
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        /// <summary>
        /// ClickTime
        /// </summary>		
        private DateTime _clicktime;
        public DateTime ClickTime
        {
            get { return _clicktime; }
            set { _clicktime = value; }
        }
        /// <summary>
        /// Money
        /// </summary>		
        private decimal _money;
        public decimal Money
        {
            get { return _money; }
            set { _money = value; }
        }

    }
}
