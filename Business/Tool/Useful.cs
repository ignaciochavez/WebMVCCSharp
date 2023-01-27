using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Tool
{
    public static class Useful
    {
        #region Gets

        public static string GetApplicationDirectory()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory.Replace("WebAppUnitTests\\bin\\Debug", "WebApp\\");
        }

        public static string GetAppSettings(string keyWebConfig)
        {
            return ConfigurationManager.AppSettings[keyWebConfig];
        }

        public static string GetPngToBase64String(string path)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(imageBytes);
            return String.Format("data:image/png;base64,{0}", base64String);
        }

        public static int GetPageSizeMaximun()
        {
            int pageSixeMaximun = Convert.ToInt32(Useful.GetAppSettings("PageSizeMaximun"));
            return pageSixeMaximun;
        }

        public static string GetRutCheckDigit(int rut)
        {
            int count = 2;
            int accumulator = 0;

            while (rut != 0)
            {
                int multiple = (rut % 10) * count;
                accumulator = accumulator + multiple;
                rut = rut / 10;
                count = count + 1;
                if (count == 8)
                {
                    count = 2;
                }
            }

            int digit = 11 - (accumulator % 11);
            string rutDigit = digit.ToString().Trim();
            if (digit == 10)
            {
                rutDigit = "K";
            }
            if (digit == 11)
            {
                rutDigit = "0";
            }

            return rutDigit;
        }

        public static string OpenAPICSharpNameHeader()
        {
            return "API-KEY";
        }

        public static string OpenAPICSharpValueHeader()
        {
            return GetAppSettings("OpenAPICSharpAPIKey");
        }

        public static string OpenAPICSharpURL()
        {
            return GetAppSettings("OpenAPICSharpURL");
        }

        #endregion

        #region Validate

        public static bool ValidateRut(string rut)
        {
            rut = rut.Replace(".", "").ToUpper();
            Regex expression = new Regex(GetAppSettings("IsRut"));
            string dv = rut.Substring(rut.Length - 1, 1);
            if (!expression.IsMatch(rut))
            {
                return false;
            }
            char[] charCut = { '-' };
            string[] arrayRut = rut.Split(charCut);
            if (dv != GetRutCheckDigit(Convert.ToInt32(arrayRut[0])))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            if (dateTimeOffset == DateTimeOffset.MinValue)
                return false;
            else
                return true;
        }

        public static bool ValidateBase64String(string base64String)
        {
            base64String = base64String.Trim();
            return (base64String.Length % 4 == 0) && Regex.IsMatch(base64String, @GetAppSettings("IsBase64String"), RegexOptions.None);
        }

        #endregion

        #region API
        public static HttpResponseMessage APIGetRequest(string requestUrl, string nameHeader = null, string valueHeader = null)
        {
            HttpClient httpClient = new HttpClient();
            APIRequestVerifyHttps(requestUrl);
            if (!string.IsNullOrWhiteSpace(nameHeader) && !string.IsNullOrWhiteSpace(valueHeader))
                httpClient.DefaultRequestHeaders.Add(nameHeader, valueHeader);
            Task<HttpResponseMessage> response = httpClient.GetAsync(requestUrl);
            HttpResponseMessage content = response.Result;
            return content;
        }

        public static HttpResponseMessage APIPostRequest<T>(string requestUrl, T element, string nameHeader = null, string valueHeader = null)
        {
            HttpClient httpClient = new HttpClient();
            APIRequestVerifyHttps(requestUrl);
            StringContent stringContent = APIHttpContentJsonRequest(element);
            if (!string.IsNullOrWhiteSpace(nameHeader) && !string.IsNullOrWhiteSpace(valueHeader))
                httpClient.DefaultRequestHeaders.Add(nameHeader, valueHeader);
            Task<HttpResponseMessage> response = httpClient.PostAsync(requestUrl, stringContent);
            HttpResponseMessage content = response.Result;
            return content;
        }

        public static HttpResponseMessage APIPutRequest<T>(string requestUrl, T element, string nameHeader = null, string valueHeader = null)
        {
            HttpClient httpClient = new HttpClient();
            APIRequestVerifyHttps(requestUrl);
            StringContent stringContent = APIHttpContentJsonRequest(element);
            if (!string.IsNullOrWhiteSpace(nameHeader) && !string.IsNullOrWhiteSpace(valueHeader))
                httpClient.DefaultRequestHeaders.Add(nameHeader, valueHeader);
            Task<HttpResponseMessage> response = httpClient.PutAsync(requestUrl, stringContent);
            HttpResponseMessage content = response.Result;
            return content;
        }

        public static HttpResponseMessage APIDeleteRequest(string requestUrl, string nameHeader = null, string valueHeader = null)
        {
            HttpClient httpClient = new HttpClient();
            APIRequestVerifyHttps(requestUrl);
            if (!string.IsNullOrWhiteSpace(nameHeader) && !string.IsNullOrWhiteSpace(valueHeader))
                httpClient.DefaultRequestHeaders.Add(nameHeader, valueHeader);
            Task<HttpResponseMessage> response = httpClient.DeleteAsync(requestUrl);
            HttpResponseMessage content = response.Result;
            return content;
        }

        private static void APIRequestVerifyHttps(string requestUrl)
        {
            if (requestUrl.ToLower().Contains("https"))
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            }
        }

        private static StringContent APIHttpContentJsonRequest<T>(T element)
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string json = JsonConvert.SerializeObject(element, jsonSerializerSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static string APIJsonDeserializeObjectToSampleString(HttpResponseMessage httpResponseMessage)
        {
            Task<string> jsonResp = httpResponseMessage.Content.ReadAsStringAsync();
            string obj = jsonResp.Result;
            return obj;
        }

        public static T APIJsonDeserializeObject<T>(HttpResponseMessage httpResponseMessage)
        {
            Task<string> jsonResp = httpResponseMessage.Content.ReadAsStringAsync();
            T obj = JsonConvert.DeserializeObject<T>(jsonResp.Result);
            return obj;
        }
        #endregion

        #region Replace
        public static string ReplaceConventionImageFromBase64String(string base64String)
        {
            base64String = base64String.Replace("data:image/bmp;base64,", "");
            base64String = base64String.Replace("data:image/emf;base64,", "");
            base64String = base64String.Replace("data:image/exif;base64,", "");
            base64String = base64String.Replace("data:image/gif;base64,", "");
            base64String = base64String.Replace("data:image/icon;base64,", "");
            base64String = base64String.Replace("data:image/jpeg;base64,", "");
            base64String = base64String.Replace("data:image/jpg;base64,", "");
            base64String = base64String.Replace("data:image/png;base64,", "");
            base64String = base64String.Replace("data:image/tiff;base64,", "");
            base64String = base64String.Replace("data:image/wmf;base64,", "");
            return base64String;
        }
        #endregion
    }
}
