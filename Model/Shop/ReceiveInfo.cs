using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    //ReceiveInfo
    public class ReceiveInfo
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
        /// Province
        /// </summary>		
        private string _province;
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        /// <summary>
        /// City
        /// </summary>		
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        /// <summary>
        /// Zone
        /// </summary>		
        private string _zone;
        public string Zone
        {
            get { return _zone; }
            set { _zone = value; }
        }
        /// <summary>
        /// Tel
        /// </summary>		
        private string _tel;
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        /// <summary>
        /// Receiver
        /// </summary>		
        private string _receiver;
        public string Receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }
        /// <summary>
        /// Phone
        /// </summary>		
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
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
        /// ZipCode
        /// </summary>		
        private string _zipcode;
        public string ZipCode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        public string DetailAddress
        {
            get { return _province + _city + _zone + _address; }
        }

    }
}
