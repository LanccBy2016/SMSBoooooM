using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMSAPI
{
    public abstract class SMSAPIBase : ISMSAPI
    {
        protected string mobile;
        protected HttpWebResponse response;

        public abstract Task<SMSAPIRunResultDto> Run(string _mobile);

        protected string ResponseStr(HttpWebResponse response)
        {
            var msg = "";
            try
            {
                Stream receiveStream = response.GetResponseStream();
                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                msg = readStream.ReadToEnd();
                readStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
