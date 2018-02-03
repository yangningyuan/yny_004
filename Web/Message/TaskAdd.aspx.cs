using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace yny_004.Web.Message
{
    public partial class TaskAdd : BasePage
    {
        protected override void SetValue(string id)
        {
            List<Model.Task> task = BLL.Task.GetTaskList(1, "ID=" + id);
            if (task.Count > 0)
            {
                txtMID.Value = task[0].TFromMID;
                hdMID.Value = txtMID.Value;
            }
        }
        protected override void SetPowerZone()
        {
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.CMessage && emp.IsAdmin))
            {
                List<Model.Member> list = BLL.Member.ManageMember.GetMemberEntityList("RoleCode='" + item.RType + "' and IsClose<>'1' and MState='1'");
                foreach (Model.Member model in list.Where(emp => BLL.Member.IfOnLine(emp.MID)))
                {
                    ddlAdmin.Items.Add(new ListItem(item.RName + " [" + model.MName + "][在线]", model.MID));
                }
                foreach (Model.Member model in list.Where(emp => !BLL.Member.IfOnLine(emp.MID)))
                {
                    ddlAdmin.Items.Add(new ListItem(item.RName + " [" + model.MName + "][离线]", model.MID));
                }
            }
            ddlAdmin.Items.Insert(0, new ListItem("请选择", ""));
            if (!TModel.Role.Super)
            {
                txtMID.Attributes["type"] = "hidden";
                txtMID.Value = BLL.Member.ManageMember.TModel.MID;
            }
        }

        public Model.Task TaskModel
        {
            get
            {
                Model.Member TMember = BLL.Member.ManageMember.TModel;
                if (!string.IsNullOrEmpty(Request.Form["txtMID"]))
                    TMember = BllModel.GetModel(Request.Form["txtMID"]);
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

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            if (!string.IsNullOrEmpty(Request.Form["txtMID"]))
            {
                if (!string.IsNullOrEmpty(Request.Form["hdMID"]))
                {
                    Model.Member TMember = BllModel.GetModel(Request.Form["hdMID"]);
                    BLL.Task.ManageSend(TMember, "尊敬的" + TMember.MID + "会员，您有一封新邮件，请注意查收！");
                }
                if (BllModel.GetModel(Request.Form["txtMID"]) == null)
                    return "会员不存在";
            }
            return BLL.Task.Add(TaskModel);
        }
    }
}