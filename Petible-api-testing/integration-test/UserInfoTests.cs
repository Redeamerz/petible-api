using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Petible_api;
using Petible_api.Controllers;
using Petible_api.Models;
using Petible_api.Repository;
using Petible_api_testing.mock_models;
using Petible_api_testing.setup_logic;

namespace Petible_api_testing.integration_test
{
    [TestClass]
    public class UserInfoTests
    {
        private HttpClient client;
        LoginInfo info;
        
        [TestInitialize]
        public void prep()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            client = appFactory.CreateClient();
            client.BaseAddress = new Uri("https://127.0.0.1:5001/");
            SetBearer();
        }

        private async void SetBearer()
        {
            SetAuthHeader auth = new SetAuthHeader();
            info = await auth.GetJwtAsync();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", info.idToken);
        }

        [TestMethod]
        public async Task GetAllUserInfoOk()
        {
            //Arrange
            
            var request = "api/v1/UserInfo";

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
            var request = "api/v1/UserInfo/" + info.localId;
            //Act
            var response = await client.GetAsync(request);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task GetUserInfoBad()
        {
            //Arrange
            var request = "api/v1/UserInfo/" + info.localId + "2";
            //Act
            var response = await client.GetAsync(request);

            //Assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        
    }
}
