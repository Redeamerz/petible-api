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
    public class ReviewTests
    {
        private HttpClient client;
        LoginInfo info;
        Review review = new Review();
        Review empty = new Review();

        [TestInitialize]
        public void prep()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
            client.BaseAddress = new Uri("https://127.0.0.1:5001/api/V1/");
            SetBearer();

            review.id = "integrationtest";
            review.rating = 4;
            review.title = "Test";
            review.text = "Net";
            review.user_id_source = "sR92IvBqCydObNPgQrjLcCp2cV42";
            review.user_id_target = "YR8gmUIMOVXz1R4R1a8OZdmjxtJ2";
        }

        private async void SetBearer()
        {
            SetAuthHeader auth = new SetAuthHeader();
            info = await auth.GetJwtAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", info.idToken);
        }

        [TestMethod]
        public async Task GetAllTestOk()
        {
            var request = "review";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task PutOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/review")
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
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/review")
            };
            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task GetByIdOk()
        {
            var request = "review/integrationtest1";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetByIdBadRequest()
        {
            var request = "review/integrationtest123";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(review), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/review")
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
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/review")
            };

            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
