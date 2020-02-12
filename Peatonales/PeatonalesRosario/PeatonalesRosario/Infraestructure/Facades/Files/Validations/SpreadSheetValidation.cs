#region Usings

#endregion
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

namespace Servicio.Infraestructure.Facades.Files
{
    public class SpreedSheetValidation : FileValidation
    {
        
        #region Singleton

        /// <summary>
        /// Variable of class, type SpreadSheetValidation.
        /// </summary>
        private static SpreedSheetValidation spreadSheetValidation;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private SpreedSheetValidation()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static SpreedSheetValidation GetInstance()
        {
            if (spreadSheetValidation == null)
            {
                spreadSheetValidation = new SpreedSheetValidation();
            }

            return spreadSheetValidation;
        }

        #endregion

        #region Implementation Methods

        public override void ExtensionsValidations(string filename)
        {
            String mimeType = this.GetMimeMapping(filename);

            if (mimeType != FileConfig.MimesSupported["MIME_XLS"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_XLSX"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_ODS"].ToString())
            {
                throw new ApiException(7773, filename
                + "Tiene tipo inválido para las hojas de cálculos, los permititidos son " +
                 ": XLS , ODS y XLSX",
                      System.Net.HttpStatusCode.BadRequest, "NoLink");
            }
        }

        #endregion
    }
}
