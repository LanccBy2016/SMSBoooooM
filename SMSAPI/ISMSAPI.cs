using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSAPI
{
    public interface ISMSAPI
    {

        /// <summary>
        /// 发送短信的入口方法
        /// </summary>
        /// <param name="phoneNum">手机号</param>
        /// <returns>返回结果</returns>
        SMSAPIRunResultDto Run(string mobile);
    }
}
