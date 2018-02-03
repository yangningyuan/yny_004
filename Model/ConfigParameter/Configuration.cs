using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace yny_004.Model
{
    public class Configuration
    {
        # region 基础参数配置属性

        # region 基础字段

        /// <summary>
        /// 自动结算
        /// </summary>
        public bool B_AutoJS { get; set; }
        /// <summary>
        /// 自动分红
        /// </summary>
        public bool B_AutoDFH { get; set; }
        /// <summary>
        /// 商城管理费
        /// </summary>
        public int B_YLMoney { get; set; }
        /// <summary>
        /// 接点人数(太阳线)
        /// </summary>
        public int B_BDCount { get; set; }
        /// <summary>
        /// 最少提现金额
        /// </summary>
        public int B_TXMinMoney { get; set; }
        /// <summary>
        /// 提现倍数
        /// </summary>
        public int B_TXBaseMoney { get; set; }
        /// <summary>
        /// 最大提现金额
        /// </summary>
        public int B_TXMaxMoney { get; set; }
        /// <summary>
        /// 提现开关
        /// </summary>
        public bool B_TXSwitch { get; set; }
        /// <summary>
        /// 最少转账金额
        /// </summary>
        public int B_ZZMinMoney { get; set; }
        /// <summary>
        /// 转账倍数
        /// </summary>
        public int B_ZZBaseMoney { get; set; }
        /// <summary>
        /// 最少转账金额
        /// </summary>
        public int B_DHMinMoney { get; set; }
        /// <summary>
        /// 转账倍数
        /// </summary>
        public int B_DHBaseMoney { get; set; }
        /// <summary>
        /// 对碰比例
        /// </summary>
        public decimal B_DPFloat { get; set; }
        /// <summary>
        /// 对碰日封顶
        /// </summary>
        public decimal B_DPTopFloat { get; set; }
        /// <summary>
        /// 对碰最大层数
        /// </summary>
        public int B_MaxDPCount { get; set; }
        /// <summary>
        /// 激活默认角色
        /// </summary>
        public string B_DefaultRole { get; set; }
        /// <summary>
        /// 入账汇率
        /// </summary>
        public decimal B_InFloat { get; set; }
        /// <summary>
        /// 出账汇率
        /// </summary>
        public decimal B_OutFloat { get; set; }
        /// <summary>
        /// 一个身份信息可注册会员数
        /// </summary>
        public int B_MaxRegister { get; set; }

        # endregion 基础字段

        # region 修改字段

        /// <summary>
        /// 投资倍数
        /// </summary>
        public int E_TZBase { get; set; }

        /// <summary>
        /// 最小投资额
        /// </summary>
        public int E_TZMin { get; set; }

        /// <summary>
        /// 最大投资额
        /// </summary>
        public int E_TZMax { get; set; }

        /// <summary>
        /// 日分红比例
        /// </summary>
        public decimal E_DayFHFloat { get; set; }

        /// <summary>
        /// 推荐奖比例
        /// </summary>
        public decimal E_TJFloat { get; set; }

        /// <summary>
        /// 退本扣手续费
        /// </summary>
        public decimal E_QuitFloat { get; set; }

        /// <summary>
        /// 体验金分红次数
        /// </summary>
        public int E_BbinTimes { get; set; }
        /// <summary>
        /// 体验金数额
        /// </summary>
        public decimal E_BbinMoney { get; set; }
        /// <summary>
        /// 手机单数
        /// </summary>
        public int E_BbinMaxCount { get; set; }

        /// <summary>
        /// 体验金日分红比例
        /// </summary>
        public decimal E_BbinFHFloat { get; set; }
        /// <summary>
        /// 退本烧伤周期
        /// </summary>
        public int B_TBTJDate { get; set; }
        /// <summary>
        /// 退本烧伤金额
        /// </summary>
        public decimal B_TBTJMoney { get; set; }

        /// <summary>
        /// 最大投资额
        /// </summary>
        public decimal E_MaxTouZi { get; set; }

        # endregion 修改字段

        # endregion 基础参数配置属性

        # region 其它属性(不存储在基础数据表中的属性,需加入[IgnoreThis]特性)

        /// <summary>
        /// 审核费用
        /// </summary>
        [IgnoreThis]
        public DataTable SHMoneyTable { get; set; }
        [IgnoreThis]
        public DataTable SHMoneyTableMoney { get; set; }

        /// <summary>
        /// 审核费用列表
        /// </summary>
        [IgnoreThis]
        public Dictionary<string, Model.SHMoney> SHMoneyList { get; set; }

        //public DataTable NewSHMoneyTable { get; set; }
        //public Dictionary<string, Model.NewSHMoney> NewSHMoneyList { get; set; }

        /// <summary>
        /// 组织奖数据源
        /// </summary>
        [IgnoreThis]
        public DataTable ConfigDictionaryTable { get; set; }

        /// <summary>
        /// 字典
        /// </summary>
        [IgnoreThis]
        public Dictionary<string, List<ConfigDictionary>> ConfigDictionaryList { get; set; }

        /// <summary>
        /// 组织奖数据源
        /// </summary>
        [IgnoreThis]
        public DataTable NConfigDictionaryTable { get; set; }
        /// <summary>
        /// 字典
        /// </summary>
        [IgnoreThis]
        public Dictionary<string, List<NConfigDictionary>> NConfigDictionaryList { get; set; }

        /// <summary>
        /// 组织奖数据源
        /// </summary>
        [IgnoreThis]
        public DataTable ConfigDictionaryNewTable { get; set; }
        /// <summary>
        /// 字典
        /// </summary>
        [IgnoreThis]
        public Dictionary<string, List<ConfigDictionaryNew>> ConfigDictionaryNewList { get; set; }

        [IgnoreThis]
        public Hashtable HaSh { get; set; }

        # endregion 其它属性(不存储在基础数据表中的属性,需加入[IgnoreThis]特性)
    }
}
