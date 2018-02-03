using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web.Script.Serialization;

namespace yny_004.Web.Handler
{
    /// <summary>
    /// TJTree 的摘要说明
    /// </summary>
    public class TJTree : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            string mkey = memberModel.MID;
            bool isStructure = false;

            if (!string.IsNullOrEmpty(context.Request["id"]))//非查询
            {
                mkey = context.Request["id"];
                isStructure = true;
            }
            else
            {
                if (!string.IsNullOrEmpty(context.Request["serachId"]))//查询
                {
                    if (memberModel.Role.Super)
                    {
                        isStructure = false;
                        mkey = context.Request["serachId"];
                    }
                }
            }

            if (!TModel.Role.IsAdmin)
            {
                int count = Convert.ToInt32(BLL.CommonBase.GetSingle(string.Format(@"
                            -- 查找所有父节点
                            with tab as
                            (
                             select MID,MTJ from member where MID='{0}' --子节点
                             union all
                             select b.MID,b.MTJ
                             from
                              tab a,--子节点数据集
                              member b  --父节点数据集
                             where a.MTJ=b.MID and b.MID <> '{1}'  --子节点数据集.parendID=父节点数据集.ID
                            )
                            select count(*) from tab where MID = '{2}';
                            ", mkey, BLL.Member.ManageMember.TModel.MID, TModel.MID)));
                //int mcount = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from GetAllSubBDMember('" + TModel.MID + "') where mid='" + mkey + "';"));
                if (count <= 0)
                {
                    mkey = TModel.MID;
                }
            }

            List<sys_Tree> tree = new List<sys_Tree>();
            if (isStructure)
            {
                GetStructure(mkey, tree);
            }
            else
            {
                Model.Member tempmodel = BLL.Member.ManageMember.GetModel(mkey);
                tree.Add(GetTreeByMember(tempmodel, isParent(tempmodel.MID), true));
                //GetStructure(tempmodel.MID, tree);//默认两层
            }

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            string strJson = oSerializer.Serialize(tree);
            context.Response.Write(strJson);
        }

        private void GetStructure(string mid, List<sys_Tree> tree)
        {
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MTJ='{0}' and MID<>'{0}' order by MDate", mid));
            for (int i = 0; i < ListMember.Count; i++)
            {
                //string colors = "";
                //colors = ListMember[i].MAgencyType.MColor;
                //bool parent = isParent(ListMember[i].MID);
                tree.Add(GetTreeByMember(ListMember[i], isParent(ListMember[i].MID)));
            }
        }

        private bool isParent(string mid)
        {
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(string.Format("MTJ='{0}' and MID<>'{0}' order by MDate", mid));
            if (ListMember != null && ListMember.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private sys_Tree GetTreeByMember(Model.Member member, bool isparent = false, bool isOpen = false, bool isCheck = false)
        {
            sys_Tree tree = new sys_Tree();
            if (member != null)
            {
                tree.id = member.MID;
                if (member.MID != member.MTJ)
                {
                    tree.pId = member.MTJ;
                }
                tree.name = GetDisplay(member);/// member.MID + member.Role.RName;
                tree.open = isOpen;
                tree.checke = isCheck;
                tree.isParent = isparent;
            }
            return tree;
        }

        private string GetDisplay(Model.Member member)
        {
            string result = "";

            result = string.Format("<span>会员帐号：【<b style=\"color:{2};font-weight: bold;\">{0}</b>】</span><span>会员级别：【{1}】</span><span>人数：【<b style=\"color:red;font-weight: bold;\">{3}</b>】</span><span>业绩：【<b style=\"color:red;font-weight: bold;\">{4}万</b>】</span>", member.MID, member.MAgencyType.MAgencyName, member.MAgencyType.MColor, member.MConfig.YJCount, member.MConfig.YJMoney / 10000);

            return result;
        }
    }

    /// <summary>
    /// sys_resourse:实体类(属性说明自动提取数据库字段的描述信息)
    /// 用来显示树形列表用
    /// </summary>
    [Serializable]
    public partial class sys_Tree
    {
        public sys_Tree()
        { }

        #region Model

        private string _id;
        private string _pId;
        private string _name;
        private bool _checked;
        private bool _open;
        private bool _isparent;

        /// <summary>
        /// id
        /// </summary>
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 父id
        /// </summary>
        public string pId
        {
            set { _pId = value; }
            get { return _pId; }
        }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool checke
        {
            set { _checked = value; }
            get { return _checked; }
        }
        /// <summary>
        /// 是否展开
        /// </summary>
        public bool open
        {
            set { _open = value; }
            get { return _open; }
        }
        /// <summary>
        /// 是否父节点
        /// </summary>
        public bool isParent
        {
            set { _isparent = value; }
            get { return _isparent; }
        }

        #endregion Model
    }
}