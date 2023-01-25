using Business.DTO;
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
    public static class HeroeImpl
    {
        public static Tuple<string, MessageVO, Heroe> Select(int id)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            Heroe heroe = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{URLHeroe()}Select?id={id}", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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
                heroe = Useful.APIJsonDeserializeObject<Heroe>(httpResponseMessage);
            }

            Tuple<string, MessageVO, Heroe> tuple = new Tuple<string, MessageVO, Heroe>(response, messageVO, heroe);
            return tuple;
        }

        public static Tuple<string, MessageVO, Heroe> Insert(HeroeInsertDTO heroeInsertDTO)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            Heroe heroe = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest<HeroeInsertDTO>($"{URLHeroe()}Insert", heroeInsertDTO, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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
                heroe = Useful.APIJsonDeserializeObject<Heroe>(httpResponseMessage);
            }

            Tuple<string, MessageVO, Heroe> tuple = new Tuple<string, MessageVO, Heroe>(response, messageVO, heroe);
            return tuple;
        }

        public static Tuple<string, MessageVO, bool?> Update(Heroe heroe)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            bool? update = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPutRequest<Heroe>($"{URLHeroe()}Update", heroe, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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
            HttpResponseMessage httpResponseMessage = Useful.APIDeleteRequest($"{URLHeroe()}Delete?id={id}", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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

        public static Tuple<string, MessageVO, List<Heroe>> List(HeroeListDTO heroeListDTO)
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            List<Heroe> listHeroe = new List<Heroe>();
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest<HeroeListDTO>($"{URLHeroe()}List", heroeListDTO, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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
                listHeroe = Useful.APIJsonDeserializeObject<List<Heroe>>(httpResponseMessage);
            }

            Tuple<string, MessageVO, List<Heroe>> tuple = new Tuple<string, MessageVO, List<Heroe>>(response, messageVO, listHeroe);
            return tuple;
        }

        public static Tuple<string, MessageVO, long?> TotalRecords()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            long? count = null;
            HttpResponseMessage httpResponseMessage = Useful.APIGetRequest($"{URLHeroe()}TotalRecords", Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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

        public static Tuple<string, MessageVO, HeroeExcelDTO> Excel()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            HeroeExcelDTO heroeExcelDTO = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest($"{URLHeroe()}Excel", string.Empty, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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
                heroeExcelDTO = Useful.APIJsonDeserializeObject<HeroeExcelDTO>(httpResponseMessage);
            }

            Tuple<string, MessageVO, HeroeExcelDTO> tuple = new Tuple<string, MessageVO, HeroeExcelDTO>(response, messageVO, heroeExcelDTO);
            return tuple;
        }

        public static Tuple<string, MessageVO, HeroePDFDTO> PDF()
        {
            string response = string.Empty;
            MessageVO messageVO = null;
            HeroePDFDTO heroePDFDTO = null;
            HttpResponseMessage httpResponseMessage = Useful.APIPostRequest($"{URLHeroe()}PDF", string.Empty, Useful.OpenAPICSharpNameHeader(), Useful.OpenAPICSharpValueHeader());
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
                heroePDFDTO = Useful.APIJsonDeserializeObject<HeroePDFDTO>(httpResponseMessage);
            }

            Tuple<string, MessageVO, HeroePDFDTO> tuple = new Tuple<string, MessageVO, HeroePDFDTO>(response, messageVO, heroePDFDTO);
            return tuple;
        }

        private static string URLHeroe()
        {
            return $"{Useful.OpenAPICSharpURL()}Heroe/";
        }
    }
}
