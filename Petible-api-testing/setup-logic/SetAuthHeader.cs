using Newtonsoft.Json;
using Petible_api_testing.mock_models;
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
        HttpClient client = new HttpClient();
        public async Task<LoginInfo> GetJwtAsync()
        {
            var info = new MockLoginInfo
            {
                email = "hayate12345@outlook.com",
                password = "test123",
                role = 2,
                returnSecureToken = true
            };
            var json = JsonConvert.SerializeObject(info);
            

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var token = client.PostAsync("https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyCUCz3zW6Q21Qf4tuKmCL9vYT6AlygCH1M", content).Result;

            string result = await token.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<LoginInfo>(result);
            
            return response;
        }
    }
}
