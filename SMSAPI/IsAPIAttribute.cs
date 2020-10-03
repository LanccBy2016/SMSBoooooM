using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSBoooooM
{

    /// <summary>
    /// 用于标识短信API接口
    /// </summary>
    public class IsAPIAttribute:Attribute

    {
        public string ApiName { get;}
        public IsAPIAttribute(string name)
        {
            this.ApiName = name;
        }
    }
}
