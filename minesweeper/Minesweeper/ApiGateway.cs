using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Dtos;
using Newtonsoft.Json;

namespace Minesweeper
{
    static class ApiGateway
    {

        private static HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:5000/");
            //client.BaseAddress = new Uri("http://0a53-14-245-127-129.ngrok.io");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<ActionDto> GetHintAsync(ProblemDto problem)
        {
            //prepareClient();

            var response = await ApiGateway.getClient().PostAsJsonAsync("", problem);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            var action = await response.Content.ReadAsAsync<ActionDto>();
            return action;
        }
    }
}
