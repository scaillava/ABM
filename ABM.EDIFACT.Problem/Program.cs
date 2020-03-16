using ABM.EDIFACT.Parser.Service;
using ABM.EDIFACT.Parser.Service.Implement;
using ABM.EDIFACT.Problem.Config;
using ABM.EDIFACT.Problem.Controller;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ABM.EDIFACT.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //setup our DI

                ServiceProviderConfig.getServiceProvider();
                var serviceProvider = new ServiceCollection()
                 .AddSingleton<IEdifactParser, EdifactParserImpl>()
                 .BuildServiceProvider();


                //// add StructureMap
                //var container = new Container();
                //container.Configure(config =>
                //{
                //    // Register stuff in container, using the StructureMap APIs...
                //    config.Scan(_ =>
                //    {
                //        _.AssemblyContainingType(typeof(Program));
                //        _.WithDefaultConventions();
                //    });
                //    // Populate the container using the service collection
                //    config.Populate(services);
                //});

                EdifactController edifactController = new EdifactController(serviceProvider);

                var result = edifactController.getLOCColums("UNA:+.? 'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH+EDIFACT+CUSDEC:D:96B:UN:145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'LOC+17+IT044100'LOC+18+SOL'LOC+35+SE'LOC+36+TZ'LOC+116+SE003033'DTM+9:20090527:102'DTM+268:20090626:102'DTM+182:20090527:102'");
                Console.WriteLine("Second element of each LOC row");
                foreach(string s in result.secondColumn)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Third element of each LOC row");
                foreach (string s in result.thirdColumn)
                {
                    Console.WriteLine(s);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
