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
    public class PetMedicalInfoTests
    {
        private static HttpClient client;
        static LoginInfo info;
        static PetMedicalInfo petMedicalInfo = new PetMedicalInfo();
        static PetMedicalInfo empty = new PetMedicalInfo();

        [ClassInitialize]
        public static void prep(TestContext context)
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
            client.BaseAddress = new Uri("https://127.0.0.1:5001/api/V1/");
            SetBearer();

            petMedicalInfo.id = "integrationtesting2";
            petMedicalInfo.chipped = true;
            petMedicalInfo.sterilized = false;
            petMedicalInfo.vaccinesUptodate = true;
            petMedicalInfo.medicalComplications = true;
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
            var request = "petmedicalinfo";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task PutOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(petMedicalInfo), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Put,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/PetMedicalInfo")
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
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/PetMedicalInfo")
            };
            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task GetByIdOk()
        {
            var request = "PetMedicalInfo/integrationtest";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetByIdBadRequest()
        {
            var request = "PetMedicalInfo/integrationtest123";

            var response = await client.GetAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task DeleteOk()
        {

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(petMedicalInfo), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/PetMedicalInfo")
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
                RequestUri = new Uri("https://127.0.0.1:5001/api/v1/PetMedicalInfo")
            };

            var response = await client.SendAsync(request);

            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
