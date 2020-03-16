using ABM.EDIFACT.Parser.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABM.EDIFACT.Parser.Service.Implement
{
    public class EdifactParserImpl : IEdifactParser
    {
        public string[] getColumns(string EDIFACT, string segment, int column)
        {
            try
            {
                List<string> segments = EDIFACT.Split(EdifactSerparators.segmentTerminator).ToList().Where(x => x.StartsWith(segment)).ToList();
                return segments.Select(x => x.Split(EdifactSerparators.elementSeparator)[column]).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
