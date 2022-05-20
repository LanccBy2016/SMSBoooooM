using SMSAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API1
{
    public class 玫瑰里 : SMSAPIBase
    {
        public override async Task<SMSAPIRunResultDto> Run(string _mobile)
        {
            mobile = _mobile;
            SMSAPIRunResultDto result = new SMSAPIRunResultDto();

            await Task.Run(() => {
                result.IsSuccess = Request_www_lavin_com_cn(out response);
                result.Message = ResponseStr(response);
            });
            return result;
        }

        private bool Request_www_lavin_com_cn(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.lavin.com.cn/portal/index/sendRegister");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"http://www.lavin.com.cn");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "http://www.lavin.com.cn/user/register";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"PHPSESSID=d2ac70sop2r7egu7bi2gr9faig; Hm_lvt_12cf124592d99b7fb0ad22e6604d04db=1570777257; nb-referrer-hostname=www.lavin.com.cn; Hm_lpvt_12cf124592d99b7fb0ad22e6604d04db=1570777271; nb-start-page-url=http%3A%2F%2Fwww.lavin.com.cn%2Fuser%2Fregister");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = string.Format(@"phone={0}&template=SMS_152505627", mobile);
                byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(body);
                request.ContentLength = postBytes.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(postBytes, 0, postBytes.Length);
                stream.Close();

                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError) response = (HttpWebResponse)e.Response;
                else return false;
            }
            catch (Exception)
            {
                if (response != null) response.Close();
                return false;
            }

            return true;
        }
    }
}
