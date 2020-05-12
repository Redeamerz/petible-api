using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Petible_api_testing.setup_logic
{
    public class SetAuthHeader
    {
        public async Task<HttpClient> SetAuthorizationHeader(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync(client));
            return client;
        }

        private async Task<string> GetJwtAsync(HttpClient _client)
        {
            var info = new MockLoginInfo
            {
                email = "test@petible.nl",
                password = "test123",
                returnSecureToken = true
            };
            var json = JsonConvert.SerializeObject(info);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var token = await _client.PostAsync("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCUCz3zW6Q21Qf4tuKmCL9vYT6AlygCH1M", content);
            var tokenresponse = await token.Content.ReadAsStringAsync();

            return tokenresponse;
        }
    }
}
