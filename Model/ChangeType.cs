using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004
{
    public enum ChangeType
    {
        /// <summary>
        /// 修改资料
        /// </summary>
        O_XGZL,
        /// <summary>
        /// 充值
        /// </summary>
        O_CZ,
        /// <summary>
        /// 审核提现
        /// </summary>
        O_SHTX,
        /// <summary>
        /// 审核线下汇款
        /// </summary>
        O_SHXXHK,
        /// <summary>
        /// 升级会员
        /// </summary>
        O_SJHY,
        /// <summary>
        /// 修改奖金参数
        /// </summary>
        O_XGJJCS,
        /// <summary>
        /// 备份网站
        /// </summary>
        O_BFWZ,
        /// <summary>
        /// 静态分红
        /// </summary>
        O_JTFH,
        /// <summary>
        /// 修改会员资料
        /// </summary>
        O_XGHYZL
    }
}
