using ABM.EDIFACT.Parser.Service;
using ABM.EDIFACT.Parser.Service.Implement;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABM.EDIFACT.Parser.Test.UnitTests
{
    [TestFixture]
    public class EdifactParserTest
    {
        private IEdifactParser edifactParser;

        [SetUp]
        public void SetUp()
        {
            edifactParser = new EdifactParserImpl();
        }


        [TestCase("UNA:+.? '" +
         "UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'" +
         "UNH+EDIFACT+CUSDEC:D:96B:UN:145050'" +
         "BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'" +
         "LOC+17+IT044100'" +
         "LOC+18+SOL'" +
         "LOC+35+SE'" +
         "LOC+36+TZ'" +
         "LOC+116+SE003033'" +
         "DTM+9:20090527:102'" +
         "DTM+268:20090626:102'" +
         "DTM+182:20090527:102'", "LOC", 1, new string[] { "17", "18", "35", "36", "116" })]
    [TestCase("UNA:+.? '" +
         "UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'" +
         "UNH+EDIFACT+CUSDEC:D:96B:UN:145050'" +
         "BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'" +
         "LOC+17+IT044100'" +
         "LOC+18+SOL'" +
         "LOC+35+SE'" +
         "LOC+36+TZ'" +
         "LOC+116+SE003033'" +
         "DTM+9:20090527:102'" +
         "DTM+268:20090626:102'" +
         "DTM+182:20090527:102'", "LOC", 2, new string[] { "IT044100", "SOL", "SE", "TZ", "SE003033" })]
    [TestCase("UNA:+.? '" +
         "UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'" +
         "UNH+EDIFACT+CUSDEC:D:96B:UN:145050'" +
         "BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'" +
         "LOC+17+IT044100'" +
         "LOC+18+SOL'" +
         "LOC+35+SE'" +
         "LOC+36+TZ'" +
         "LOC+116+SE003033'" +
         "DTM+9:20090527:102'" +
         "DTM+268:20090626:102'" +
         "DTM+182:20090527:102'", "DTM", 1, new string[] { "9:20090527:102", "268:20090626:102", "182:20090527:102" })]
    public void correctCases(string edifactText, string typeSegment, int column, string[] result)
    {
        try
        {
            Assert.AreEqual(result, edifactParser.getColumns(edifactText, typeSegment, column));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}
}
