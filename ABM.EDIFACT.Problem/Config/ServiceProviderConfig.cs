using ABM.EDIFACT.Parser.Service;
using ABM.EDIFACT.Parser.Service.Implement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABM.EDIFACT.Problem.Config
{
    public static class ServiceProviderConfig
    {
        public static ServiceProvider getServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                   .AddSingleton<IEdifactParser, EdifactParserImpl>()
                   .BuildServiceProvider();
            return serviceProvider;
        }
    }
}
