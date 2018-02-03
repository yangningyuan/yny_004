using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.mobile.html
{
    public partial class TaskAdd :BasePage
    {
        public Model.Task TaskModel
        {
            get
            {
                Model.Member TMember = BLL.Member.ManageMember.TModel;
                
                Model.Task model = new Model.Task();
                Model.Member FMember = TModel;

                model.TContent = Request.Form["txtMessage"];
                model.TDateTime = DateTime.Now;
                model.TFromMID = FMember.MID;
                model.TFromMName = FMember.MName;
                model.TToMID = TMember.MID;
                model.TToMName = TMember.MName;
                model.TType = Request.Form["ddlTType"];
                return model;
            }
        }


        protected override string btnAdd_Click()
        {
            return BLL.Task.Add(TaskModel);
        }
    }
}