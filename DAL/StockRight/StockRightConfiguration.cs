using System;
using System.Collections;
using System.Data;
using System.Text;
using DBUtility;

namespace yny_004.DAL
{
    public class StockRightConfiguration
    {
        private static Model.StockRightConfiguration _StockRightConfiguration;
        public static Model.StockRightConfiguration StockRightCf
        {
            get
            {
                if (_StockRightConfiguration == null)
                    _StockRightConfiguration = _Get_StockRightConfiguration();
                return _StockRightConfiguration;
            }
            set
            {
                _StockRightConfiguration = value;
            }
        }

        /// <summary>
        /// <summary>
        /// 返回系统配置信息
        /// </summary>
        /// <returns></returns>
        private static Model.StockRightConfiguration _Get_StockRightConfiguration()
        {
            Model.StockRightConfiguration model = DAL.BaseParameter.GetEntity<Model.StockRightConfiguration>();

            model.stockRightConfigList = DAL.StockRightConfig.GetStockRightConfigList();
            model.stockRightConfigDic = DAL.StockRightConfig.GetStockRightConfigDic();

            return model;
        }

        public static bool _Update(Model.StockRightConfiguration model)
        {
            if (model != null)
            {
                Hashtable MyHs = new Hashtable();
                DAL.BaseParameter.SaveChange<Model.StockRightConfiguration>(model, MyHs);

                DAL.StockRightConfig.UpdateList(model.stockRightConfigDic, MyHs);

                return DAL.CommonBase.RunHashtable(MyHs);
            }
            return false;
        }

        public static bool ReSetSys()
        {
            Hashtable MyHs = new Hashtable();
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from StockRightConfig;");
            MyHs.Add(sb.ToString(), null);
            return CommonBase.RunHashtable(MyHs);
        }
    }
}