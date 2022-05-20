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
    public class 小智Logo : SMSAPIBase
    {
        public override async Task<SMSAPIRunResultDto> Run(string _mobile)
        {
            mobile = _mobile;
            SMSAPIRunResultDto result = new SMSAPIRunResultDto();

            await Task.Run(() => {
                result.IsSuccess = Request_api_xzlogo_com(out response);
                result.Message = ResponseStr(response);
            });
            return result;
        }

        private bool Request_api_xzlogo_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.xzlogo.com/auth/api/sms/sendCode");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://www.xzlogo.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.ContentType = "application/json";
                request.Accept = "*/*";
                request.Headers.Add("Sec-Fetch-Site", @"same-site");
                request.Referer = "https://www.xzlogo.com/signin";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"_ga=GA1.2.748901232.1578387907; _gid=GA1.2.598049588.1578387907; _gat_UA-92602697-1=1; Hm_lvt_6059b0f00a9052df10e8a8d56e3dcdda=1578387908; Hm_lpvt_6059b0f00a9052df10e8a8d56e3dcdda=1578387908; pyxz.sid=.eJxNj1tPgzAARv9Ln5VroS2JMcThrEEMBeb0ZSlQoHHcBg6G8b_Lk-57Puck3zd42zvRgxd4B7oBDhA21m3CbWHxFFoWJDYuIMw5MSDGnOjg5l-I6YsHHN1C2MSIaEgxINSQeUUkzF-b1Th2g6OqdadMQs6yUfpeydpazUp5m8pGHap26k9Zm4v7UWafYrwrw62Glsn9W2S1-RObXiU-58auE9vjl988zn4dnNOIzP7iXpI9o1nMWKx_1OFC50CrnrlZ6e9m4rplvIkYE-4UtnTNrjcOxUkMFXAKfhzEzy_17VH6.EPXbVQ.hjlu8pllR3eaPHa6b3gCGycGn-8");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"{""mobile"":""" + mobile + @"""}";
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
