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
        public override async Task<SMSAPIRunResultDto> Run(string _mobile)
        {
            mobile = _mobile;
            SMSAPIRunResultDto result = new SMSAPIRunResultDto();

            await Task.Run(() => {
                result.IsSuccess = Request_www_tffwzl_com(out response);
                result.Message = ResponseStr(response);
            });
            return result;
        }

        private bool Request_www_tffwzl_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.tffwzl.com/sms/send");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"http://www.tffwzl.com");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "http://www.tffwzl.com/register";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"XSRF-TOKEN=eyJpdiI6Ijc0eXNqd1NOM1wvRWVsQnhOcmQ1am9RPT0iLCJ2YWx1ZSI6IjBBTmVkZVdtWXlFbzh1ZkkwY1JIekdqXC9nQjYzRlhPVm11c0JjcEFYUlJtQlNrY3FXaWdtOUNNQVVrdUhUbUpOWHNhOTFpUzlsSElUT1wvQlVpR1ZEQUE9PSIsIm1hYyI6ImFiZmY2MDk2MjdhOWEyOWQ3MWU2NzEwM2FkMWViNDk1MmM2OTE3ZjRhMjNkOGU5YTUzZWY4NTk0MWUzNDVjOTIifQ%3D%3D; tffwzl_session=eyJpdiI6InFEVEpheGhWcHpPa0ptN3p4NFpxekE9PSIsInZhbHVlIjoiSjU3SFZONWxNa25zTkhFbU5yZU82VFNYc0NONnpPZUVcL0oyU1h5Z01WcCtUdTVvRjZmQ3pEbUtUc2RTdkFjcklsU2VWMFFtUEVkYU5aajJEUmU4RFd3PT0iLCJtYWMiOiJiNWZlMjY3YWMxYjE2MzU0MDFmMTFkNmFjNTFiMGNlNGY4ZWVjMGY1MzBjNDQ2N2MzOTg0OWIzMDE5ZjkxNzcwIn0%3D");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = string.Format(@"mobile={0}&type=register", mobile);
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
