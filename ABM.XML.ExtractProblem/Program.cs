using ABM.XML.ExtractProblem.Controller;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ABM.XML.ExtractProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string asd = "<InputDocument>" +
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
  "</InputDocument>";


                string asd2 = "<InputDocument>" +
     "<DeclarationList>" +
         "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
             "<DeclarationHeader>" +
                 "<Jurisdiction>IE</Jurisdiction>" +
                 "<CWProcedure>IMPORT</CWProcedure>" +
                             "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                 "<DocumentRef>71Q0019681</DocumentRef>" +
                 //"<SiteID>DUB</SiteID>" +
                 "<AccountCode>G0779837</AccountCode>" +
             "</DeclarationHeader>" +
         "</Declaration>" +
     "</DeclarationList>" +
 "</InputDocument>";


                DeclarationController dc = new DeclarationController();
                var codes = dc.getReferenceCodes(asd);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }



        }
    }
}
