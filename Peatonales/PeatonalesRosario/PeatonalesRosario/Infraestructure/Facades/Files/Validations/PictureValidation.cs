#region Usings
using Servicio.ErrorHelper;
using Servicio.Infraestructure;
using Resolver.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

#endregion

namespace Servicio.Infraestructure.Facades.Files
{
    public class PictureValidation : FileValidation
    {

        #region Singleton

        /// <summary>
        /// Variable of class, type PictureValidation.
        /// </summary>
        private static PictureValidation pictureValidation;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private PictureValidation()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static PictureValidation GetInstance()
        {
            if (pictureValidation == null)
            {
                pictureValidation = new PictureValidation();
            }

            return pictureValidation;
        }

        #endregion

        #region Implementation Methods

        public override void ExtensionsValidations(string filename)
        {
            String mimeType = this.GetMimeMapping(filename);

            //if (mimeType != FileConfiguration.GetInstance().AppSettings["MIME_JPG"].ToString() &&
            //    mimeType != FileConfiguration.GetInstance().AppSettings["MIME_JPEG"].ToString() &&
            //    mimeType != FileConfiguration.GetInstance().AppSettings["MIME_PNG"].ToString())
            if (mimeType != FileConfig.MimesSupported["MIME_JPG"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_JPEG"].ToString() &&
                mimeType != FileConfig.MimesSupported["MIME_PNG"].ToString())
            {
                throw new ApiException(7773, filename
                + "Tiene un tipo inválido, los permititidos son : JPG , JPEG, PNG y JPE",
                      System.Net.HttpStatusCode.BadRequest, "NoLink");
            }
        }

        #endregion
    }
}
