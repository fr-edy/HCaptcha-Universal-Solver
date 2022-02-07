using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Reflection;
using System.IO;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using System.Web;

public class HCaptchaSolver
{
    public static string Solve(string sitekey, string host, string page, string widgetId, string siteOrigin, string siteReferer, string version, HCaptchaMovementsIntensity movementsIntensity, string hc_accessibility = "", HCatpchaProxy proxy = null)
    {
        string captchaResult = "";

        while (captchaResult == "" || captchaResult == null)
        {
            try
            {
                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-challenge.html");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Upgrade-Insecure-Requests"] = "1",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                            ["Sec-Fetch-Site"] = "cross-site",
                            ["Sec-Fetch-Mode"] = "navigate",
                            ["Sec-Fetch-Dest"] = "iframe",
                            ["Referer"] = siteReferer,
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Upgrade-Insecure-Requests"] = "1",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                            ["Sec-Fetch-Site"] = "cross-site",
                            ["Sec-Fetch-Mode"] = "navigate",
                            ["Sec-Fetch-Dest"] = "iframe",
                            ["Referer"] = siteReferer,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    response.Close();
                    response.Dispose();
                }

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/i18n/it.json");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Origin"] = siteOrigin,
                            ["Sec-Fetch-Site"] = "cross-site",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = siteReferer,
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Origin"] = siteOrigin,
                            ["Sec-Fetch-Site"] = "cross-site",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = siteReferer,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    response.Close();
                    response.Dispose();
                }

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-checkbox.html");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>()
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Upgrade-Insecure-Requests"] = "1",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                            ["Sec-Fetch-Site"] = "cross-site",
                            ["Sec-Fetch-Mode"] = "navigate",
                            ["Sec-Fetch-Dest"] = "iframe",
                            ["Referer"] = siteReferer,
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>()
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Upgrade-Insecure-Requests"] = "1",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9",
                            ["Sec-Fetch-Site"] = "cross-site",
                            ["Sec-Fetch-Mode"] = "navigate",
                            ["Sec-Fetch-Dest"] = "iframe",
                            ["Referer"] = siteReferer,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    response.Close();
                    response.Dispose();
                }

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://newassets.hcaptcha.com/captcha/v1/" + version + "/hcaptcha-checkbox.js");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Sec-Fetch-Site"] = "same-origin",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "script",
                            ["Referer"] = "https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-checkbox.html",
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Sec-Fetch-Site"] = "same-origin",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "script",
                            ["Referer"] = "https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-checkbox.html",
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    response.Close();
                    response.Dispose();
                }

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://newassets.hcaptcha.com/captcha/v1/" + version + "/hcaptcha-challenge.js");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Sec-Fetch-Site"] = "same-origin",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "script",
                            ["Referer"] = "https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-challenge.html",
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Sec-Fetch-Site"] = "same-origin",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "script",
                            ["Referer"] = "https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-challenge.html",
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    response.Close();
                    response.Dispose();
                }

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://hcaptcha.com/checksiteconfig?v=" + version + "&host=" + host + "&sitekey=" + sitekey + "&sc=1&swa=1");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "OPTIONS";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["Accept"] = "*/*",
                            ["Access-Control-Request-Method"] = "GET",
                            ["Access-Control-Request-Headers"] = "cache-control,content-type",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Site"] = "same-site",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = "https://newassets.hcaptcha.com/",
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["Accept"] = "*/*",
                            ["Access-Control-Request-Method"] = "GET",
                            ["Access-Control-Request-Headers"] = "cache-control,content-type",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Site"] = "same-site",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = "https://newassets.hcaptcha.com/",
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    response.Close();
                    response.Dispose();
                }

                string req = "";

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://hcaptcha.com/checksiteconfig?v=" + version + "&host=" + host + "&sitekey=" + sitekey + "&sc=1&swa=1");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";


                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Cache-Control"] = "no-cache",
                            ["Content-Type"] = "application/json; charset=utf-8",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["Sec-Fetch-Site"] = "same-site",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = "https://newassets.hcaptcha.com/",
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Cache-Control"] = "no-cache",
                            ["Content-Type"] = "application/json; charset=utf-8",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["Sec-Fetch-Site"] = "same-site",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = "https://newassets.hcaptcha.com/",
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    dynamic jss = JObject.Parse(Encoding.UTF8.GetString(Utils.Decompress(Utils.ReadFully(response.GetResponseStream()))));
                    req = jss.c.req;
                    response.Close();
                    response.Dispose();
                }

                string hsw = "";

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://newassets.hcaptcha.com/c/9449fda8/hsw.js");

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "GET";

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Sec-Fetch-Site"] = "same-origin",
                            ["Sec-Fetch-Mode"] = "no-cors",
                            ["Sec-Fetch-Dest"] = "script",
                            ["Referer"] = "https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-challenge.html",
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "newassets.hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Accept"] = "*/*",
                            ["Sec-Fetch-Site"] = "same-origin",
                            ["Sec-Fetch-Mode"] = "no-cors",
                            ["Sec-Fetch-Dest"] = "script",
                            ["Referer"] = "https://newassets.hcaptcha.com/captcha/v1/" + version + "/static/hcaptcha-challenge.html",
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    hsw = Encoding.UTF8.GetString(Utils.Decompress(Utils.ReadFully(response.GetResponseStream())));
                    response.Close();
                    response.Dispose();
                }

                ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                service.HideCommandPromptWindow = true;
                service.SuppressInitialDiagnosticInformation = true;
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("disable-infobars", "--disable-plugins", "--no-experiments", "--disk-cache-dir=null", "--disable-geolocation", "--disable-search-geolocation-disclosure", "--headless");
                ChromeDriver driver = new ChromeDriver(service, options);
                string n = driver.ExecuteScript(hsw + Environment.NewLine + "return hsw(\"" + req + "\");").ToString();
                driver.Quit();
                driver.Dispose();

                {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://hcaptcha.com/getcaptcha?s=" + sitekey);

                    if (proxy != null)
                    {
                        request.Proxy = proxy.GetProxy();
                    }

                    request.UseDefaultCredentials = false;
                    request.AllowAutoRedirect = false;

                    FieldInfo field = typeof(HttpWebRequest).GetField("_HttpRequestHeaders", BindingFlags.Instance | BindingFlags.NonPublic);

                    request.Method = "POST";

                    string motionData = Utils.GetMotionData(page, widgetId, movementsIntensity);
                    string content = "v=" + version + "&sitekey=" + sitekey + "&host=" + host + "&hl=it&motionData=" + HttpUtility.UrlEncode(motionData) + "&n=" + HttpUtility.UrlEncode(n) + "&c=" + HttpUtility.UrlEncode("{\"type\":\"hsw\",\"req\":\"" + req + "\"}");

                    byte[] requestBytes = Encoding.UTF8.GetBytes(content);
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Close();

                    CustomWebHeaderCollection headers = null;

                    if (hc_accessibility != "")
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["Content-Length"] = requestBytes.Length.ToString(),
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Accept"] = "application/json",
                            ["Content-Type"] = "application/x-www-form-urlencoded",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["Sec-Fetch-Site"] = "same-site",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = "https://newassets.hcaptcha.com/",
                            ["Cookie"] = "hc_accessibility=" + hc_accessibility,
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }
                    else
                    {
                        headers = new CustomWebHeaderCollection(new Dictionary<string, string>
                        {
                            ["Host"] = "hcaptcha.com",
                            ["Connection"] = "keep-alive",
                            ["Content-Length"] = requestBytes.Length.ToString(),
                            ["sec-ch-ua"] = "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"96\", \"Google Chrome\";v=\"96\"",
                            ["Accept"] = "application/json",
                            ["Content-Type"] = "application/x-www-form-urlencoded",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.110 Safari/537.36",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["Origin"] = "https://newassets.hcaptcha.com",
                            ["Sec-Fetch-Site"] = "same-site",
                            ["Sec-Fetch-Mode"] = "cors",
                            ["Sec-Fetch-Dest"] = "empty",
                            ["Referer"] = "https://newassets.hcaptcha.com/",
                            ["Accept-Encoding"] = "gzip, deflate, br",
                            ["Accept-Language"] = "it-IT,it;q=0.9,en-US;q=0.8,en;q=0.7"
                        });
                    }

                    field.SetValue(request, headers);

                    WebResponse response = request.GetResponse();
                    dynamic jss = JObject.Parse(Encoding.UTF8.GetString(Utils.Decompress(Utils.ReadFully(response.GetResponseStream()))));
                    captchaResult = jss.generated_pass_UUID;
                    response.Close();
                    response.Dispose();
                }
            }
            catch
            {

            }
        }

        return captchaResult;
    }
}