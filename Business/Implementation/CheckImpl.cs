using Business.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public static class CheckImpl
    {
        private static string OpenAPICSharpUrl = $"{Useful.GetAppSettings("OpenAPICSharpURL")}Check/";

        public static Tuple<string, MessageVO> Check()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{OpenAPICSharpUrl}Check");
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObject<string>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK || httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }

            Tuple<string, MessageVO> tuple = new Tuple<string, MessageVO>(response, messageVO);
            return tuple;
        }

        public static Tuple<string, MessageVO> CheckAuth()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{OpenAPICSharpUrl}CheckAuth", "API-KEY", Useful.GetAppSettings("OpenAPICSharpAPIKey"));
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                response = Useful.APIJsonDeserializeObject<string>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK || httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError || httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }

            Tuple<string, MessageVO> tuple = new Tuple<string, MessageVO>(response, messageVO);
            return tuple;
        }
    }
}
