using System;
using System.Collections.Generic;
using System.Text;

namespace ABM.EDIFACT.Parser.Service
{
    public interface IEdifactParser
    {
        string[] getColumns(string EDIFACT, string segment, int column);
    }
}
