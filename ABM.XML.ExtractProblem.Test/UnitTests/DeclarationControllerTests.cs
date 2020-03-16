using ABM.XML.ExtractProblem.Controller;
using NUnit.Framework;
using System.Collections;

namespace ABM.XML.ExtractProblem.Test.UnitTests
{
    [TestFixture]
    public class DeclarationControllerTests
    {


        [TestCase(
            "<InputDocument>" +
                    "<DeclarationList>" +
                      "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                        "<DeclarationHeader>" +
                          "<Jurisdiction>IE</Jurisdiction>" +
                          "<CWProcedure>IMPORT</CWProcedure>" +
                          "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                          "<DocumentRef>71Q0019681</DocumentRef>" +
                          "<SiteID>DUB</SiteID>" +
                          "<AccountCode>G0779837</AccountCode>" +
                          "<Reference RefCode=\"MWB\" > " +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"KEY\" > " +
                            "<RefText>DUB16049</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"CAR\" > " +
                            "<RefText>71Q0019681</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"COM\">" +
                            "<RefText>71Q0019681</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"SRC\">" +
                            "<RefText>ECUS</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"TRV\">" +
                            "<RefText>1</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"CAS\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"HWB\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"UCR\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Destination\" >IE</Country>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Dispatch\">CN</Country>" +
                            "</DeclarationHeader>" +
                            "</Declaration>" +
                  "</DeclarationList>" +
                  "</InputDocument>", new string[] { "586133622", "71Q0019681", "1" })]

        [TestCase(
            "<InputDocument>" +
                    "<DeclarationList>" +
                      "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                        "<DeclarationHeader>" +
                          "<Jurisdiction>IE</Jurisdiction>" +
                          "<CWProcedure>IMPORT</CWProcedure>" +
                          "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                          "<DocumentRef>71Q0019681</DocumentRef>" +
                          "<SiteID>DUB</SiteID>" +
                          "<AccountCode>G0779837</AccountCode>" +
                          "<Reference RefCode=\"MWB\" > " +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"KEY\" > " +
                            "<RefText>DUB16049</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"CAR\" > " +
                            "<RefText>71Q0019681</RefText>" +
                          "</Reference>" +
                           "<Reference RefCode=\"CAR\" > " +
                            "<RefText>2213123</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"COM\">" +
                            "<RefText>71Q0019681</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"SRC\">" +
                            "<RefText>ECUS</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"TRV\">" +
                            "<RefText>99999</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"CAS\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"HWB\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"UCR\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Destination\" >IE</Country>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Dispatch\">CN</Country>" +
                            "</DeclarationHeader>" +
                            "</Declaration>" +
                  "</DeclarationList>" +
                  "</InputDocument>", new string[] { "586133622", "71Q0019681", "2213123", "99999" })]

        [TestCase(
            "<InputDocument>" +
                    "<DeclarationList>" +
                      "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                        "<DeclarationHeader>" +
                          "<Jurisdiction>IE</Jurisdiction>" +
                          "<CWProcedure>IMPORT</CWProcedure>" +
                          "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                          "<DocumentRef>71Q0019681</DocumentRef>" +
                          "<SiteID>DUB</SiteID>" +
                          "<AccountCode>G0779837</AccountCode>" +
                          //"<Reference RefCode=\"MWB\" > " +
                          //  "<RefText>586133622</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"KEY\" > " +
                          //  "<RefText>DUB16049</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"CAR\" > " +
                          //  "<RefText>71Q0019681</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"COM\">" +
                          //  "<RefText>71Q0019681</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"SRC\">" +
                          //  "<RefText>ECUS</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"TRV\">" +
                          //  "<RefText>1</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"CAS\">" +
                          //  "<RefText>586133622</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"HWB\">" +
                          //  "<RefText>586133622</RefText>" +
                          //"</Reference>" +
                          //"<Reference RefCode=\"UCR\">" +
                          //  "<RefText>586133622</RefText>" +
                          //"</Reference>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Destination\" >IE</Country>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Dispatch\">CN</Country>" +
                            "</DeclarationHeader>" +
                            "</Declaration>" +
                  "</DeclarationList>" +
                  "</InputDocument>", null)]
        [TestCase(
            "<InputDocument>" +
                    "<DeclarationList>" +
                      "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                        "<DeclarationHeader>" +
                          "<Jurisdiction>IE</Jurisdiction>" +
                          "<CWProcedure>IMPORT</CWProcedure>" +
                          "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                          "<DocumentRef>71Q0019681</DocumentRef>" +
                          "<SiteID>DUB</SiteID>" +
                          "<AccountCode>G0779837</AccountCode>" +
                          "<Reference RefCode=\"KEY\" > " +
                            "<RefText>DUB16049</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"CAR\" > " +
                            "<RefText>5</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"COM\">" +
                            "<RefText>71Q0019681</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"SRC\">" +
                            "<RefText>ECUS</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"TRV\">" +
                            "<RefText>2</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"CAS\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"HWB\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Reference RefCode=\"UCR\">" +
                            "<RefText>586133622</RefText>" +
                          "</Reference>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Destination\" >IE</Country>" +
                          "<Country CodeType=\"NUM\" CountryType=\"Dispatch\">CN</Country>" +
                            "</DeclarationHeader>" +
                            "</Declaration>" +
                  "</DeclarationList>" +
                  "</InputDocument>", new string[] { "5", "2" })]
        public void correctCases(string xml, string[] arrayResult)
        {
            DeclarationController dc = new DeclarationController();
            Assert.AreEqual(arrayResult, dc.getReferenceCodes(xml));
        }


    }
}