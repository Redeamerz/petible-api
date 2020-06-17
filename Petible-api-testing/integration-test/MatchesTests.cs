using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Petible_api;
using Petible_api.Models;
using Petible_api_testing.mock_models;
using Petible_api_testing.setup_logic;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Petible_api_testing.integration_test
{
    [TestClass]
    public class MatchesTests
    {
        private static HttpClient client;
        static LoginInfo info;
        static Match match = new Match();
        static Match empty = new Match();

        [ClassInitialize]
        public static void prep(TestContext context)
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
            client.BaseAddress = new Uri("https://127.0.0.1:5001/api/V1/");
            SetBearer();

            match.id = "integrationtest1";
            match.pet_id = "integrationtesting2";
            match.user_id = "integrationtesting";
            match.status = 3;
        }

        private static async void SetBearer()
        {
            SetAuthHeader auth = new SetAuthHeader();
            info = await auth.GetJwtAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", info.idToken);
        }

        [TestMethod]
        public async Task GetAllTestOk()
        {
            var request = "animalshelter";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task PutOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(match), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/match")
            };
            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public async Task PutBadRequest()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(empty), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/match")
            };
            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task GetByIdOk()
        {
            var request = "match/integrationtest";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetByIdBadRequest()
        {
            var request = "match/integrationtest123";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(match), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/match")
            };

            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteBadRequest()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent("00000000000000000000", Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/match")
            };

            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
