using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.cqp.fjaxzhy.bilibili.Code
{
    public class Copyright_Judge
    {
        public string Copyright(int num)
        {
            string str=null;
            if (num==1)
            {
                str = "自制";
            }
            else if (num==2)
            {
                str = "转载";
            }
            return str;
        }
    }
}
