﻿using Business.DTO;
using Business.Entity;
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
    public static class ExampleImpl
    {
        public static Tuple<string, MessageVO, Example> Select(int id)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            Example example = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{URLExample()}Select?id={id}", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                example = Useful.APIJsonDeserializeObject<Example>(httpResponseMessage);
            }

            Tuple<string, MessageVO, Example> tuple = new Tuple<string, MessageVO, Example>(response, messageVO, example);
            return tuple;
        }
        
        public static Tuple<string, MessageVO, Example> Insert(ExampleInsertDTO exampleInsertDTO)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            Example example = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest<ExampleInsertDTO>($"{URLExample()}Insert", exampleInsertDTO, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                example = Useful.APIJsonDeserializeObject<Example>(httpResponseMessage);
            }

            Tuple<string, MessageVO, Example> tuple = new Tuple<string, MessageVO, Example>(response, messageVO, example);            
            return tuple;
        }

        public static Tuple<string, MessageVO, bool?> Update(Example example)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            bool? update = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPutRequest<Example>($"{URLExample()}Update", example, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                update = Useful.APIJsonDeserializeObject<bool>(httpResponseMessage);
            }

            Tuple<string, MessageVO, bool?> tuple = new Tuple<string, MessageVO, bool?>(response, messageVO, update);
            return tuple;
        }

        public static Tuple<string, MessageVO, bool?> Delete(int id)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            bool? delete = null;
            HttpResponseMessage httpResponseMessage = Useful.APIDeleteRequest($"{URLExample()}Delete?id={id}", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                delete = Useful.APIJsonDeserializeObject<bool>(httpResponseMessage);
            }

            Tuple<string, MessageVO, bool?> tuple = new Tuple<string, MessageVO, bool?>(response, messageVO, delete);
            return tuple;
        }

        public static Tuple<string, MessageVO, List<Example>> List(ExampleListDTO exampleListDTO)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            List<Example> listExample = new List<Example>();
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest<ExampleListDTO>($"{URLExample()}List", exampleListDTO, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                listExample = Useful.APIJsonDeserializeObject<List<Example>>(httpResponseMessage);
            }

            Tuple<string, MessageVO, List<Example>> tuple = new Tuple<string, MessageVO, List<Example>>(response, messageVO, listExample);
            return tuple;
        }

        public static Tuple<string, MessageVO, long?> TotalRecords()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            long? count = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{URLExample()}TotalRecords", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                count = Useful.APIJsonDeserializeObject<long>(httpResponseMessage);
            }

            Tuple<string, MessageVO, long?> tuple = new Tuple<string, MessageVO, long?>(response, messageVO, count);
            return tuple;
        }

        public static Tuple<string, MessageVO, ExampleExcelDTO> Excel()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            ExampleExcelDTO exampleExcelDTO = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest($"{URLExample()}Excel", string.Empty, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                exampleExcelDTO = Useful.APIJsonDeserializeObject<ExampleExcelDTO>(httpResponseMessage);
            }

            Tuple<string, MessageVO, ExampleExcelDTO> tuple = new Tuple<string, MessageVO, ExampleExcelDTO>(response, messageVO, exampleExcelDTO);
            return tuple;
        }

        public static Tuple<string, MessageVO, ExamplePDFDTO> PDF()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            ExamplePDFDTO examplePDFDTO = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest($"{URLExample()}PDF", string.Empty, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
            if (httpResponseMessage.StatusCode != HttpStatusCode.OK && httpResponseMessage.StatusCode != HttpStatusCode.BadRequest && httpResponseMessage.StatusCode != HttpStatusCode.Unauthorized && httpResponseMessage.StatusCode != HttpStatusCode.InternalServerError)
            {
                response = Useful.APIJsonDeserializeObjectToSampleString(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.BadRequest || httpResponseMessage.StatusCode == HttpStatusCode.Unauthorized || httpResponseMessage.StatusCode == HttpStatusCode.InternalServerError)
            {
                messageVO = Useful.APIJsonDeserializeObject<MessageVO>(httpResponseMessage);
            }
            else if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                examplePDFDTO = Useful.APIJsonDeserializeObject<ExamplePDFDTO>(httpResponseMessage);
            }

            Tuple<string, MessageVO, ExamplePDFDTO> tuple = new Tuple<string, MessageVO, ExamplePDFDTO>(response, messageVO, examplePDFDTO);
            return tuple;
        }

        private static string URLExample()
        {
            return $"{Useful.OpenAPICSharpURL()}Example/";
        }
    }
}
