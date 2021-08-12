using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DemoAsync2
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            /*
            string uri = "https://viacep.com.br/ws/01001000/json/";
            var resposta = await client.GetAsync(uri);
            Console.WriteLine(resposta.StatusCode);
            Console.WriteLine(resposta.IsSuccessStatusCode);
            var tarefa = resposta.Content.ReadAsStringAsync();
            //var json = tarefa.Result;
            var json = await tarefa;
            Console.WriteLine(json);
            */
            /*
            try
            {
                string uri = "https://viacep.com.br/ws/01001000/json/";
                var resposta = await client.GetStringAsync(uri);
                Console.WriteLine(resposta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */
            try
            {
                string uri = "https://viacep.com.br/ws/01001000/json/";
                var resposta = await client.GetFromJsonAsync<ViaCep>(uri);
                Console.WriteLine(resposta.Logradouro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
