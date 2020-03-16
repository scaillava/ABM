using ABM.EDIFACT.Parser.Service;
using ABM.EDIFACT.Problem.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABM.EDIFACT.Problem.Controller
{
    public class EdifactController
    {
        ServiceProvider serviceProvider;
        public EdifactController(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public EdifactLOCColumsResult getLOCColums(string EDIFACT)
        {
            try
            {
                var parser = serviceProvider.GetService<IEdifactParser>();
                return new EdifactLOCColumsResult(parser.getColumns(EDIFACT, "LOC", 1), parser.getColumns(EDIFACT, "LOC", 2));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
