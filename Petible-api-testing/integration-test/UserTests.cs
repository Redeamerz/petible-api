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
    public class UserTests
    {
        private static HttpClient client;
        static LoginInfo info;
        static User user = new User();
        static User empty = new User();

        [ClassInitialize]
        public static void prep(TestContext context)
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
            client.BaseAddress = new Uri("https://127.0.0.1:5001/");
            SetBearer();

            user.id = "integrationtesting";
            user.email = "integrationtestcreation@outlook.com";
            user.role = 2;
        }

        private static async void SetBearer()
        {
            SetAuthHeader auth = new SetAuthHeader();
            info = await auth.GetJwtAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", info.idToken);
        }

        [TestMethod]
        public async Task GetAllUserOk()
        {
            //Arrange

            var request = "api/v1/User";

            //Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetUserInfoOk()
        {
            //Arrange
            var request = "api/v1/User/" + info.localId;
            //Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetUserInfoBadRequest()
        {
            //Arrange
            var request = "api/v1/User/" + info.localId + "2";
            //Act
            var response = await client.GetAsync(request);

            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task PutOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/user")
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
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/user")
            };
            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/user")
            };

            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.NoContent, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteBadRequest()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent("1", Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/user")
            };

            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
