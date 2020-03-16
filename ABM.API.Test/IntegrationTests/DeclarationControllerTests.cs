using ABM.API.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;

namespace ABM.API.Test.IntegrationTests
{
    public class DeclarationControllerTests : IntegrationTests
    {

        const string api = "api/declaration/";

        [Theory]
        [InlineData(
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
                             "</DeclarationHeader>" +
                         "</Declaration>" +
                     "</DeclarationList>" +
                 "</InputDocument>")]
        [InlineData(
                  "<InputDocument>" +
                     "<DeclarationList>" +
                         "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                             "<DeclarationHeader>" +
                                 "<Jurisdiction>IE</Jurisdiction>" +
                                 "<CWProcedure>IMPORT</CWProcedure>" +
                                 "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                                 "<DocumentRef>71Q0019651</DocumentRef>" +
                                 "<SiteID>DUB</SiteID>" +
                                 "<AccountCode>G0773427</AccountCode>" +
                             "</DeclarationHeader>" +
                         "</Declaration>" +
                     "</DeclarationList>" +
                 "</InputDocument>")]
        [InlineData(
                  "<InputDocument>" +
                     "<DeclarationList>" +
                         "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                             "<DeclarationHeader>" +
                                 "<Jurisdiction>IE</Jurisdiction>" +
                                 "<CWProcedure>IMPORT</CWProcedure>" +
                                 "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                                 "<DocumentRef>71Q00123</DocumentRef>" +
                                 "<SiteID>DUB</SiteID>" +
                                 "<AccountCode>P24987</AccountCode>" +
                             "</DeclarationHeader>" +
                         "</Declaration>" +
                     "</DeclarationList>" +
                 "</InputDocument>")]
        [InlineData(
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
                  "</InputDocument>")]
        [InlineData(
                  "<InputDocument>" +
                     "<DeclarationList>" +
                         "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                             "<DeclarationHeader>" +
                                 "<Jurisdiction>IE</Jurisdiction>" +
                                 "<CWProcedure>IMPORT</CWProcedure>" +
                                 "<DeclarationDestination>CUSTOM</DeclarationDestination>" +
                                 "<DocumentRef>71Q0019681</DocumentRef>" +
                                 "<SiteID>DUB</SiteID>" +
                                 "<AccountCode>G0779837</AccountCode>" +
                             "</DeclarationHeader>" +
                         "</Declaration>" +
                     "</DeclarationList>" +
                 "</InputDocument>")]

        public async Task correctCases(string xml)
        {
            try
            {


                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, api);
                var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml");
                requestMessage.Content = stringContent;

                // Send the request to the server
                var response = await testhttpClient
                        .SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(DeclarationStatusCodes.correctStructureStatus.ToString(), responseBody);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Theory]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEF\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q0019681</DocumentRef>" +
                         "<SiteID>DUB</SiteID>" +
                         "<AccountCode>G0779837</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT1\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                          "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q0019651</DocumentRef>" +
                         "<SiteID>DUB</SiteID>" +
                         "<AccountCode>G0773427</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q00123</DocumentRef>" +
                         "<SiteID>DUB</SiteID>" +
                         "<AccountCode>P24987</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
            "<DeclarationList>" +
              "<Declaration Command=\"  DEFAULT   \" Version=\"5.13\">" +
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
          "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFFFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOM</DeclarationDestination>" +
                         "<DocumentRef>71Q0019681</DocumentRef>" +
                         "<SiteID>DUB</SiteID>" +
                         "<AccountCode>G0779837</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]

        public async Task invalidCommandCases(string xml)
        {
            try
            {


                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, api);
                var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml");
                requestMessage.Content = stringContent;

                // Send the request to the server
                var response = await testhttpClient
                        .SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(DeclarationStatusCodes.invalidCommandStatus.ToString(), responseBody);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Theory]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q0019681</DocumentRef>" +
                         "<SiteID>dub</SiteID>" +
                         "<AccountCode>G0779837</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q0019651</DocumentRef>" +
                         "<SiteID>DU2B</SiteID>" +
                         "<AccountCode>G0773427</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q00123</DocumentRef>" +
                         "<SiteID></SiteID>" +
                         "<AccountCode>P24987</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
            "<DeclarationList>" +
              "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                "<DeclarationHeader>" +
                  "<Jurisdiction>IE</Jurisdiction>" +
                  "<CWProcedure>IMPORT</CWProcedure>" +
                  "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                  "<DocumentRef>71Q0019681</DocumentRef>" +
                  "<SiteID> DUB</SiteID>" +
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
          "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOM</DeclarationDestination>" +
                         "<DocumentRef>71Q0019681</DocumentRef>" +
                         "<SiteID>DUB </SiteID>" +
                         "<AccountCode>G0779837</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]

        public async Task invalidSiteCases(string xml)
        {
            try
            {


                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, api);
                var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml");
                requestMessage.Content = stringContent;

                // Send the request to the server
                var response = await testhttpClient
                        .SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(DeclarationStatusCodes.invalidSiteStatus.ToString(), responseBody);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Theory]
        [InlineData(
          "<InputDocument>" +
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
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         "<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         //"<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q0019651</DocumentRef>" +
                         "<SiteID>DUB</SiteID>" +
                         "<AccountCode>G0773427</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     "<DeclarationHeader>" +
                         //"<Jurisdiction>IE</Jurisdiction>" +
                         "<CWProcedure>IMPORT</CWProcedure>" +
                         "<DeclarationDestination>CUSTOMSWAREIE</DeclarationDestination>" +
                         "<DocumentRef>71Q00123</DocumentRef>" +
                         "<SiteID>DUB</SiteID>" +
                         "<AccountCode>P24987</AccountCode>" +
                     "</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        [InlineData(
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
                    //"<RefText>586133622</RefText>" +
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
          "</InputDocument>")]
        [InlineData(
          "<InputDocument>" +
             "<DeclarationList>" +
                 "<Declaration Command=\"DEFAULT\" Version=\"5.13\">" +
                     //"<DeclarationHeader>" +
                     //    "<Jurisdiction>IE</Jurisdiction>" +
                     //    "<CWProcedure>IMPORT</CWProcedure>" +
                     //                "<DeclarationDestination>CUSTOM</DeclarationDestination>" +
                     //    "<DocumentRef>71Q0019681</DocumentRef>" +
                     //    "<SiteID>DUB</SiteID>" +
                     //    "<AccountCode>G0779837</AccountCode>" +
                     //"</DeclarationHeader>" +
                 "</Declaration>" +
             "</DeclarationList>" +
         "</InputDocument>")]
        public async Task incorrectStructureCases(string xml)
        {
            try
            {


                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, api);
                var stringContent = new StringContent(xml, Encoding.UTF8, "application/xml");
                requestMessage.Content = stringContent;

                // Send the request to the server
                var response = await testhttpClient
                        .SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Assert.Equal(DeclarationStatusCodes.incorrectStructureStatus.ToString(), responseBody);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
