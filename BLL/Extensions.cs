using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yny_004
{
    public static class Extensions
    {
        public static string Name(this ChangeType c)
        {
            return BLL.Reward.List[c.ToString()].RewardName;
        }

        public static string Percent(this decimal value)
        {
            return string.Format("{0}%", (value * 100m).ToNoZero());
        }
    }
}
