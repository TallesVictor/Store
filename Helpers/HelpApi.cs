using MySqlX.XDevAPI;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using Store.Models;

namespace Store.Helpers
{
    internal class HelpApi
    {
        private static readonly HttpClient client = new HttpClient();



        public static async Task<CnpjApiModel> GetCnpjApi(string cnpj)
        {
            CnpjApiModel cnpjApiModel = await searchCnpj(cnpj);

            return cnpjApiModel;

        }

        public static async Task<CnpjApiModel> searchCnpj(string cnpj)
        {

            // URL da API com o CNPJ
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

            try
            {
                // Faz a requisição HTTP GET para a API
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Lê o conteúdo da resposta
                string responseBody = await response.Content.ReadAsStringAsync();

                // Analisa o JSON retornado pela API
                var data = JObject.Parse(responseBody);

                // Captura as informações da 
                CnpjApiModel cnpjApiModel = new CnpjApiModel();
                cnpjApiModel.Cnpj = data["cnpj"] + "";
                cnpjApiModel.Name = data["nome"] + "";
                cnpjApiModel.Address = $"{data["logradouro"]}, {data["bairro"]} - {data["municipio"]} - {data["uf"]}";
                cnpjApiModel.Description = data["atividade_principal"][0]["text"] + "";

                return cnpjApiModel;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Erro ao consultar a API: {e.Message}");
                return null;
            }
        }
    }
}
