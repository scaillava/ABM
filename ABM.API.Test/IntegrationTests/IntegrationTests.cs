using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ABM.API.Test.IntegrationTests
{
    public class IntegrationTests
    {
        protected readonly HttpClient testhttpClient;
        protected IntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            testhttpClient = appFactory.CreateClient();
        }

        //protected async Task AuthenticateAsync()
        //{
        //    testhttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        //}

        //private async Task<string> GetJwtAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
