using MySqlX.XDevAPI;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using Store.Models;

namespace Store.Helpers
{
    internal class Util
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

                if (data.ContainsKey("cnpj") == false) return null;

                // Captura as informações da 
                CnpjApiModel cnpjApiModel = new CnpjApiModel();
                cnpjApiModel.Cnpj = data["cnpj"] + "";
                cnpjApiModel.Name = data["nome"] + "";
                cnpjApiModel.Address = $"{data["logradouro"]}, {data["bairro"]} - {data["municipio"]} - {data["uf"]}";
   
                if (data.ContainsKey("atividade_principal"))
                {
                    cnpjApiModel.Description = data["atividade_principal"][0]["text"] + "";
                }

                return cnpjApiModel;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Erro ao consultar a API: {e.Message}");
                return null;
            }
        }

        public static string ExtractNumber(string texto)
        {
            // Remove tudo que não for número
            return System.Text.RegularExpressions.Regex.Replace(texto, @"\D", "");
        }

       public static string MaskCnpj(string cnpj)
        {
            if (cnpj.Length != 14)
                throw new ArgumentException("O CNPJ deve ter 14 dígitos.");

            return string.Format("{0}.{1}.{2}/{3}-{4}",
                cnpj.Substring(0, 2),
                cnpj.Substring(2, 3),
                cnpj.Substring(5, 3),
                cnpj.Substring(8, 4),
                cnpj.Substring(12, 2));
        }
    }
}
