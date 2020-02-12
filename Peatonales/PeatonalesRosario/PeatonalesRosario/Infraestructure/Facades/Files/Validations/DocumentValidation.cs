#region Usings

using Servicio.ErrorHelper;
using Servicio.Infraestructure;
using Resolver.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

#endregion

namespace Servicio.Infraestructure.Facades.Files
{
    public class DocumentValidation : FileValidation
    {

        #region Singleton

        /// <summary>
        /// Variable of class, type DocumentValidation.
        /// </summary>
        private static DocumentValidation documentValidation;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private DocumentValidation()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static DocumentValidation GetInstance()
        {
            if (documentValidation == null)
            {
                documentValidation = new DocumentValidation();
            }

            return documentValidation;
        }

        #endregion

        #region Implementation Method

        public override void ExtensionsValidations(string filename)
        {
            String mimeType = this.GetMimeMapping(filename);
            if (mimeType != FileConfig.MimesSupported["MIME_DOC"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_DOCX"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_ODT"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_PDF"].ToString())
                throw new ApiException(7773, filename
                    + "Tiene un tipo inválido para los documentos, los permititidos son : DOC , DOCX, ODT y PDF",
                      System.Net.HttpStatusCode.BadRequest, "NoLink");
         }


        #endregion
    }

}
