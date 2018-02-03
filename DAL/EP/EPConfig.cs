using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Collections;

namespace yny_004.DAL
{
    //EPConfig
    public class EPConfig
    {
        private static Model.EPConfig _EPConfigModel;
        public static Model.EPConfig EPConfigModel
        {
            get
            {
                if (_EPConfigModel == null)
                    _EPConfigModel = GetModel();
                return _EPConfigModel;
            }
            set
            {
                _EPConfigModel = value;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static yny_004.Model.EPConfig GetModel()
        {
            Model.EPConfig model = DAL.BaseParameter.GetEntity<Model.EPConfig>();

            return model;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(yny_004.Model.EPConfig model)
        {
            return DAL.BaseParameter.SaveChange<Model.EPConfig>(model);
        }

        public static bool ResetEP()
        {
            Hashtable MyHs = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete from EPList; delete from EPJX; ");
            MyHs.Add(strSql.ToString(), null);
            return DAL.CommonBase.RunHashtable(MyHs);
        }
    }
}
