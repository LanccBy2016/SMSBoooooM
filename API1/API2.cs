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
    public class API2 : SMSAPIBase
    {
        public override SMSAPIRunResultDto Run(string _mobile)
        {
            return new SMSAPIRunResultDto
            {
                IsSuccess = true,
                Message = this.GetType().Name
            };


            //mobile = _mobile;
            //return new SMSAPIRunResultDto
            //{
            //    IsSuccess = Request_m_client_10010_com(out response),
            //    Message = ResponseStr(response)
            //};
        }

        private bool Request_m_client_10010_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://m.client.10010.com/fiveGOrder/fiveGOrder/getVerificationCode.do");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"http://m.client.10010.com");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Linux; U; Android 9; zh-cn; Mi Note 3 Build/PKQ1.181007.001) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/71.0.3578.141 Mobile Safari/537.36 XiaoMi/MiuiBrowser/11.0.6";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "http://m.client.10010.com/fiveGOrder/fiveGOrder/orderInit.do";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,en-US;q=0.9");
                request.Headers.Set(HttpRequestHeader.Cookie, @"fiveGOrder=98705c4b799d113cc5e5d5e20ffe4ace; JSESSIONID=F45ACAA68755B09D2AA0CEF224FC40F9; mobileService1=caBn2863XYhfn8K1NblAeEWL_8rvIESK1EZg52wTMYk-_zG01bqZ!1504281042; c_sfbm=234g_00; ecs_acc=; req_mobile=; req_serial=; req_wheel=ssss; clientid=98|0");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = string.Format("phone={0}", mobile);
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
