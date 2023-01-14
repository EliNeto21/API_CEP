using Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Net;

namespace TratamentoDados
{
    public class DadosCEPController
    {

        public static DadosCEP BuscaDados(string cep)
        {
            try
            {
                var dados = new DadosCEP();

                if (!cep.Contains("-"))
                {
                    cep = cep.Insert(5, "-");
                }

                string json = RequisicaoWeb.GET(cep);

                dados = JsonConvert.DeserializeObject<DadosCEP>(json);
                
                return dados;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public static class RequisicaoWeb
    {

        public static string GET(string cep)
        {
            try
            {
                string url = $"https://cdn.apicep.com/file/apicep/{cep}.json";

                var restClient = new RestClient(url);
                restClient.Timeout = -1;

                var request = new RestRequest(Method.GET);
                IRestResponse response = restClient.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.StackTrace;
            }
        }
    }
}
