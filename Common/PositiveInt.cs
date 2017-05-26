using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class PositiveInt
    {
        private PositiveInt()
        {
        }
        /// <summary>
        /// 判断是否是正整数
        /// </summary>
        /// <param name="paramobj"></param>
        /// <returns></returns>
        public static bool IsPositiveInt(string paramobj)
        {
            Regex reg = new Regex("^[0-9]*[1-9][0-9]*$");
            return reg.IsMatch(paramobj);
        }
    }
}
