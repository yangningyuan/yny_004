/**  版本信息模板在安装目录下，可自行修改。
* StockRightConfig.cs
*
* 功 能： N/A
* 类 名： StockRightConfig
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/23 14:32:10   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using yny_004.Model;
using System.Collections;
namespace yny_004.BLL
{
    /// <summary>
    /// StockRightConfig
    /// </summary>
    public class StockRightConfig
    {
        private static Dictionary<string, Model.StockRightConfig> _StockRightConfigDic = null;
        public static Dictionary<string, Model.StockRightConfig> StockRightConfigDic
        {
            get
            {
                if (_StockRightConfigDic == null)
                {
                    _StockRightConfigDic = DAL.StockRightConfig.GetStockRightConfigDic();
                }
                return _StockRightConfigDic;
            }
            set
            {
                _StockRightConfigDic = value;
            }
        }

        private static List<Model.StockRightConfig> _StockRightConfigList = null;
        public static List<Model.StockRightConfig> StockRightConfigList
        {
            get
            {
                if (_StockRightConfigList == null)
                {
                    _StockRightConfigList = DAL.StockRightConfig.GetStockRightConfigList();
                }
                return _StockRightConfigList;
            }
            set
            {
                _StockRightConfigList = value;
            }
        }

        public static bool UpdateList(Dictionary<string, Model.StockRightConfig> list)
        {
            return CommonBase.RunHashtable(DAL.StockRightConfig.UpdateList(list, new Hashtable()));
        }

    }
}