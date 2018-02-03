using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace yny_004.BLL
{
    public class Notice
    {
        public static bool Add(Model.Notice model)
        {
            return DAL.Notice.Add(model);
        }

        public static bool Update(Model.Notice model)
        {
            return DAL.Notice.Update(model);
        }

        public static Model.Notice Select(int Id, bool isRead)
        {
            return DAL.Notice.Select(Id, isRead);
        }

        public static DataTable GetNoticeTable(string strWhere)
        {
            return DAL.Notice.GetNoticeTable(strWhere);
        }

        public static List<Model.Notice> GetNoticeList(string strWhere)
        {
            return DAL.Notice.GetNoticeList(strWhere);
        }

        public static Model.Notice GetNewNotice(int days)
        {
            return DAL.Notice.GetNewNotice(days);
        }

        public static Model.Notice GetTopNotice()
        {
            return DAL.Notice.GetTopNotice();
        }

        public static List<Model.Notice> GetNoticeLists(int top, bool isTop = false)
        {
            return DAL.Notice.GetNoticeLists(top, isTop);
        }
    }
}
