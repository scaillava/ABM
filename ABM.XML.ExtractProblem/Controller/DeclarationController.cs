using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace ABM.XML.ExtractProblem.Controller
{
    public class DeclarationController
    {
        public string[] getReferenceCodes(string xml)
        {
            try
            {
                ABM.XML.Model.Utils.Validation.DeclarationListSchemeValidation(xml);
                InputDocument inputDocument = new XmlSerializer(typeof(InputDocument)).Deserialize(new StringReader(xml)) as InputDocument;
                var allowedRefCodes = new[] { "MWB", "TRV", "CAR" };
                if (inputDocument.DeclarationList.Declaration.DeclarationHeader.Reference != null)
                {
                    return inputDocument.DeclarationList.Declaration.DeclarationHeader.Reference.ToList().Where(x => allowedRefCodes.Contains(x.RefCode)).Select(x => x.RefText).ToArray();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
