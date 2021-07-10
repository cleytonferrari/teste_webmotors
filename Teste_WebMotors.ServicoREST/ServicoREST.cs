using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Teste_WebMotors.ServicoREST
{
    public static class ServicoREST<T> where T : class
    {
        public static async Task<T> Get(string url)
        {
            T retorno = null;
            using (var httpClient = new HttpClient())
            {
                var resposta = httpClient.GetAsync(new Uri(url)).Result;

                resposta.EnsureSuccessStatusCode();
                await resposta.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                        throw x.Exception;

                    retorno = JsonSerializer.Deserialize<T>(x.Result);
                });
            }

            return retorno;
        }
    }
}
