using System;
using System.Collections;
using System.Data;
using System.Text;
using DBUtility;
using System.Collections.Generic;

namespace yny_004.DAL
{
    public class Configuration
    {

        private static Model.Configuration _model;
        public static Model.Configuration TModel
        {
            get
            {
                if (_model == null)
                    _model = DAL.Configuration._GetConfiguration();
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        # region 获取数据

        # region 公共表

        /// <summary>
        /// <summary>
        /// 返回系统配置信息
        /// </summary>
        /// <returns></returns>
        private static Model.Configuration _GetConfiguration()
        {
            Model.Configuration model = DAL.BaseParameter.GetEntity<Model.Configuration>();

            model.HaSh = new Hashtable();

            model.ConfigDictionaryTable = DAL.ConfigDictionary.GetTable();
            model.ConfigDictionaryList = DAL.ConfigDictionary.GetDicList();
            model.NConfigDictionaryTable = DAL.NConfigDictionary.GetTable();
            model.NConfigDictionaryList = DAL.NConfigDictionary.GetDicList();

            model.SHMoneyTable = DAL.SHMoney.GetSHMoneyListDataTable();
            model.SHMoneyTableMoney = DAL.SHMoney.GetSHMoneyListDataTable(" Money > 0 ", " cast(Money as int) ");
            model.SHMoneyList = DAL.SHMoney.GetSHMoneyList(model.SHMoneyTable);
            //model.NewSHMoneyTable = DAL.NewSHMoney.GetNewSHMoneyListDataTable();
            //model.NewSHMoneyList = DAL.NewSHMoney.GetNewSHMoneyList(model.NewSHMoneyTable);
            model.ConfigDictionaryNewTable = DAL.ConfigDictionaryNew.GetTable();
            model.ConfigDictionaryNewList = DAL.ConfigDictionaryNew.GetDicList();

            return model;
        }

        # endregion 公共表

        # endregion 获取数据

        public static bool _Update(Model.Configuration model)
        {
            if (model != null)
            {
                Hashtable MyHs = new Hashtable();
                DAL.BaseParameter.SaveChange<Model.Configuration>(model, MyHs);

                DAL.SHMoney.UpdateList(model.SHMoneyList, MyHs);
                //DAL.NewSHMoney.UpdateList(model.NewSHMoneyList, MyHs);

                List<Model.ConfigDictionary> list = new List<Model.ConfigDictionary>();
                foreach (List<Model.ConfigDictionary> MyDe in DAL.Configuration.TModel.ConfigDictionaryList.Values)
                {
                    list.AddRange(MyDe);
                }
                DAL.ConfigDictionary.UpdateList(list, MyHs);

                //List<Model.ConfigDictionaryNew> list = new List<Model.ConfigDictionaryNew>();
                //foreach (List<Model.ConfigDictionaryNew> MyDe in DAL.Configuration.TModel.ConfigDictionaryNewList.Values)
                //{
                //    list.AddRange(MyDe);
                //}
                //DAL.ConfigDictionaryNew.UpdateList(list, MyHs);

                //List<Model.NConfigDictionary> nlist = new List<Model.NConfigDictionary>();
                //foreach (List<Model.NConfigDictionary> MyDe in DAL.Configuration.TModel.NConfigDictionaryList.Values)
                //{
                //    nlist.AddRange(MyDe);
                //}
                //DAL.NConfigDictionary.UpdateList(nlist, MyHs);

                DAL.Configuration.TModel = null;
                return DAL.CommonBase.RunHashtable(MyHs);
            }
            return false;
        }

        public static Hashtable UpdateConfigurationCF(string fieldName, string fieldValue, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update Configuration set ");
            if (isEqual)
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{1}' ", fieldName, fieldValue));
            }
            else
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {0} + {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{0}' + '{1}' ", fieldName, fieldValue));
            }


            MyHs.Add(strSql, null);

            return MyHs;
        }

        /// <summary>
        /// 【现金币】 转 【循环币】 是否开启
        /// </summary>
        /// <returns></returns>
        public static bool IsTranMoney(bool flag)
        {
            if (flag)
                return DbHelperSQL.ExecuteSql(string.Format("Update Configuration set IsTranMoney='{0}'", "1")) > 0;
            else
                return DbHelperSQL.ExecuteSql(string.Format("Update Configuration set IsTranMoney='{0}'", "0")) > 0;
        }
    }
}
