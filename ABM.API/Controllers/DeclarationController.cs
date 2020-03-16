using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ABM.API.Constants;
using ABM.XML.Model.Exception;
using Microsoft.AspNetCore.Mvc;

namespace ABM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclarationController : ControllerBase
    {

        [HttpPost]
        [Consumes("application/xml")]
        public ActionResult<int> Post([FromBody] XmlDocument xml)
        {
            try
            {
                ABM.XML.Model.Utils.Validation.DeclarationListSchemeValidation(xml.InnerXml);
                InputDocument inputDocument = new XmlSerializer(typeof(InputDocument)).Deserialize(new StringReader(xml.InnerXml)) as InputDocument;
                if (inputDocument.DeclarationList.Declaration.Command != "DEFAULT")
                {
                    return DeclarationStatusCodes.invalidCommandStatus;
                }
                else if (inputDocument.DeclarationList.Declaration.DeclarationHeader.SiteID != "DUB")
                {
                    return DeclarationStatusCodes.invalidSiteStatus;
                }
                else
                {
                    return DeclarationStatusCodes.correctStructureStatus;
                }
            }
            catch (SchemaValidationException ex)
            {
                return DeclarationStatusCodes.incorrectStructureStatus;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
