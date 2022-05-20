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
    public class 多粉 : SMSAPIBase
    {
        public override async Task<SMSAPIRunResultDto> Run(string _mobile)
        {
            mobile = _mobile;
            SMSAPIRunResultDto result = new SMSAPIRunResultDto();

            await Task.Run(() => {
                result.IsSuccess = Request_login_duofriend_com(out response);
                result.Message = ResponseStr(response);
            });
            return result;
        }

        private bool Request_login_duofriend_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://login.duofriend.com/busReg/sendSMS1");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://login.duofriend.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://login.duofriend.com/jsp/login/repc.jsp";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"JSESSIONID=1616364FC26566E45AC84F4367A83637; code=21560889");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"phone=" + mobile;
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
