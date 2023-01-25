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
        public static Tuple<string, MessageVO, MessageVO> Check()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            MessageVO messageVOOk = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{URLCheck()}Check");
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                messageVOOk = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }

            Tuple<string, MessageVO, MessageVO> tuple = new Tuple<string, MessageVO, MessageVO>(response, messageVO, messageVOOk);
            return tuple;
        }

        public static Tuple<string, MessageVO, MessageVO> CheckAuth()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            MessageVO messageVOOk = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{URLCheck()}CheckAuth", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                messageVOOk = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }

            Tuple<string, MessageVO, MessageVO> tuple = new Tuple<string, MessageVO, MessageVO>(response, messageVO, messageVOOk);
            return tuple;
        }

        private static string URLCheck()
        {
            return $"{Useful.OpenAPICSharpURL()}Check/";
        }
    }
}
