using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Petible_api;
using Petible_api.Repository;

namespace Petible_api_testing.integration_test
{
    [TestClass]
    public class UserInfoTests
    {
        private readonly HttpClient _client;
        public UserInfoTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
        [TestMethod]
        public void TestMethod1()
        {

        }
    }
}
