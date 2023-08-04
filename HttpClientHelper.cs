using App6Yao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App6Yao
{
    public class HttpClientHelper
    {
        public static readonly HttpClient HttpClient;

        static HttpClientHelper()
        {
            // var httpclientHandler = new HttpClientHandler();

            //// httpclientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;
            // httpclientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
            // HttpClient = new HttpClient(httpclientHandler);


            try

            {

                //HttpClient热身
                var httpclientHandler = new HttpClientHandler();
                httpclientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
                HttpClient = new HttpClient(httpclientHandler) { BaseAddress = new Uri(BaseEntity.url) };

                HttpClient.DefaultRequestHeaders.Connection.Add("keep-alive");

                HttpClient.SendAsync(new HttpRequestMessage
                {

                    Method = new HttpMethod("HEAD"),

                    RequestUri = new Uri(BaseEntity.url + "/")

                }).Result.EnsureSuccessStatusCode();

            }

            catch (Exception)

            {



            }
        }
        public static async Task<bool> Gettocken(string userName, string pass)
        {
            bool t = false;
            string url = BaseEntity.url + "/api/Account/LoginingApp";
            try
            {

                var httpclientHandler = new HttpClientHandler();
                // httpclientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
                // using (var client = new HttpClient(httpclientHandler))
                // {
                // HttpClient.DefaultRequestHeaders.Clear();
                var client = HttpClient;
                var data = new Dictionary<string, string>();
                data["UserName"] = userName;
                data["Password"] = pass;
                data["t"] = "2";
                var content = new FormUrlEncodedContent(data);


                using (HttpResponseMessage response = await HttpClientHelper.HttpClient.PostAsync(url, content).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            string result = await response.Content.ReadAsStringAsync();

                            var items = JsonConvert.DeserializeObject<Models.UserEntity>(result);
                            if (items.id > 0)
                            {
                                BaseEntity.user = items;
                                BaseEntity.tockenStr = BaseEntity.user.tockenStr;
                                t = true;
                            }

                        }
                        catch { }


                    }
                }

                // }

                return t;


            }
            catch (Exception ex)
            {

            }
            return t;


        }
        public static async Task<int> GetVersion()
        {
            int r = 0;


            try
            {

                HttpClient.DefaultRequestHeaders.Clear();
                string url = BaseEntity.url + "/api/Account/GetVersion";
                // var httpclientHandler = new HttpClientHandler();
                // httpclientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
                //  using (var client = new HttpClient(httpclientHandler))
                //  {
                var client = HttpClient;
                using (var response = await HttpClientHelper.HttpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();
                    var placesJson = response.Content.ReadAsStringAsync().Result;

                    if (placesJson != "")
                    {

                        var items = JsonConvert.DeserializeObject<ReturnJson>(placesJson);
                        if (items.Status == "1")
                        {
                            r = int.Parse(items.Message); ;
                            BaseEntity.sevVCode = r;

                        }

                    }
                }
                // }


            }
            catch (Exception ex)
            {
                //  return null;
            }
            return r;

        }

        public static async Task<string> GetResponseByGet(string url)
        {

            try
            {
                HttpClient.DefaultRequestHeaders.Clear();
                HttpClient client = HttpClientHelper.HttpClient;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BaseEntity.tockenStr);
                using (var response = await HttpClientHelper.HttpClient.GetAsync(BaseEntity.url + url))
                {
                    response.EnsureSuccessStatusCode();
                    var placesJson = response.Content.ReadAsStringAsync().Result;

                    if (placesJson != "")
                    {


                        return placesJson.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                //  return null;
            }
            return "";

        }

        /// <summary>
        /// get请求，可以对请求头进行多项设置
        /// </summary>
        /// <param name="paramArray"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetResponseByGet(List<KeyValuePair<string, string>> paramArray, string url)
        {
            string result = "";

            var httpclient = HttpClientHelper.HttpClient;
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BaseEntity.tockenStr);
            url = url + "?" + BuildParam(paramArray);
            var response = httpclient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Stream myResponseStream = response.Content.ReadAsStreamAsync().Result;
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                result = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }

            return result;
        }
        public static async Task<string> GetResponseByPost(HttpContent content, string url)
        {

            string result = "";

            try
            {
                var httpclientHandler = new HttpClientHandler();
                httpclientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
                //  using (var httpclient = new HttpClient(httpclientHandler))
                //  {
                HttpClient.DefaultRequestHeaders.Clear();
                var httpclient = HttpClient;

                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BaseEntity.tockenStr);
                //HttpContent content = new StringContent("{pageIndex:1,pageSize:30}");
                //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                using (var response = await httpclient.PostAsync(url, content))
                    if (response.IsSuccessStatusCode)
                    {
                        Stream myResponseStream = response.Content.ReadAsStreamAsync().Result;
                        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                        result = myStreamReader.ReadToEnd();
                        myStreamReader.Close();
                        myResponseStream.Close();
                    }
                // }
            }
            catch (Exception ex)
            { }

            return result;
        }

        public static string GetPost(HttpContent content, string url)
        {
            string result = "";
            var httpclientHandler = new HttpClientHandler();
            httpclientHandler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
            using (var httpclient = new HttpClient(httpclientHandler))
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BaseEntity.tockenStr);
                //HttpContent content = new StringContent("{pageIndex:1,pageSize:30}");
                //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                var task = httpclient.PostAsync(url, content);

                task.Wait();
                if (task.Result.IsSuccessStatusCode)
                    task.Result.EnsureSuccessStatusCode();
                else
                {
                    return "0";
                }
                HttpResponseMessage response = task.Result;
                var r = response.Content.ReadAsStringAsync().Result;
                result = r;


            }
            return result;
        }
        public static string GetResponseBySimpleGet(List<KeyValuePair<string, string>> paramArray, string url)
        {

            var httpclient = HttpClientHelper.HttpClient;

            url = url + "?" + BuildParam(paramArray);
            var result = httpclient.GetStringAsync(url).Result;
            return result;
        }
        public static async Task<string> UploadFileAsync(string url, string path)
        {
            var client = HttpClientHelper.HttpClient;

            using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.Ticks.ToString("x")))
            {
                var upfilebytes = File.ReadAllBytes(path);
                var ms = new MemoryStream(upfilebytes);
                content.Add(new StreamContent(ms), "file", "upload.jpg");
                using (var httpResponseMessage = await client.PostAsync(url, content))
                {
                    var responseContent = "";
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
                    }
                    return responseContent;
                }
            }

        }
        private static string BuildParam(List<KeyValuePair<string, string>> paramArray, Encoding encode = null)
        {
            string url = "";

            if (encode == null) encode = Encoding.UTF8;

            if (paramArray != null && paramArray.Count > 0)
            {
                var parms = "";
                foreach (var item in paramArray)
                {
                    parms += string.Format("{0}={1}&", Encode(item.Key, encode), Encode(item.Value, encode));
                }
                if (parms != "")
                {
                    parms = parms.TrimEnd('&');
                }
                url += parms;

            }
            return url;
        }
        private static string Encode(string content, Encoding encode = null)
        {
            if (encode == null) return content;

            return System.Web.HttpUtility.UrlEncode(content, Encoding.UTF8);

        }
    }
    public class ReturnJson
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
