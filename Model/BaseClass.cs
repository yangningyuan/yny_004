using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004.Model
{
    public class BaseClass
    {
        public BaseClass()
        {
            this.Code = Guid.NewGuid().ToString();
            this.CreatedTime = DateTime.Now;
            this.IsDeleted = false;
            this.Status = 1;
        }
        public int ID { get; set; }
        public string Code
        { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTime
        { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public bool IsDeleted { get; set; }
        public int Status
        { get; set; }
    }
}
