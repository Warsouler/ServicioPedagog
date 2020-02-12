using Servicio.ErrorHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure.Facades.Files.Handling
{
    public class SpreedSheetHandling:FileHandling
    {
        #region Singleton

        /// <summary>
        /// Variable of class, type PictureValidation.
        /// </summary>
        private static SpreedSheetHandling handling;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private SpreedSheetHandling()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static SpreedSheetHandling GetInstance()
        {
            if (handling == null)
            {
                handling = new SpreedSheetHandling();
            }

            return handling;
        }

        public override FileValidation ChargeMyValidator()
        {
            return SpreedSheetValidation.GetInstance();
        }

        #endregion



        //#region Public
        //public override string HandlingUpdatePublicDirectories()
        //{
        //    String uploadPath = Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
        //              String.Join(@"\", FileConfig.Directories["PUBLICSPREEDSHEET_SUB"].ToString()
        //              /*, remoteFile.FileName*/));

        //    DirectoryInfo directoryInfo = new DirectoryInfo(uploadPath);

        //    // Creo el directorio si no existe.
        //    if (!directoryInfo.Exists)
        //        Directory.CreateDirectory(directoryInfo.FullName);

        //    return uploadPath;

        //}
        //public override string HandlingDownloadPublicDirectories(string filename)
        //{
        //    String filePath = Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
        //          String.Join(@"\", FileConfig.Directories["PUBLICSPREEDSHEET_SUB"].ToString()
        //           ));

        //    DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

        //    if (!directoryInfo.Exists)
        //        throw new ApiException(7778, filePath + "No es una ruta válida",
        //            System.Net.HttpStatusCode.BadGateway, "NoLink");
        //    filePath = Path.Combine(filePath,
        //          String.Join(@"\", filename));

        //    return filePath;
        //}
        //#endregion

        //#region Private
        //public override string HandlingUpdatePrivateDirectories(string username)
        //{
        //    String uploadPath = Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
        //              String.Join(@"\", FileConfig.Directories["SPREEDSHEET_SUB"].ToString(),
        //              username
        //              /*, remoteFile.FileName*/));

        //    DirectoryInfo directoryInfo = new DirectoryInfo(uploadPath);

        //    // Creo el directorio si no existe.
        //    if (!directoryInfo.Exists)
        //        Directory.CreateDirectory(directoryInfo.FullName);

        //    return uploadPath;

        //}

        //public override string HandlingDownloadPrivateDirectories(string username, string filename)
        //{
        //    String filePath = Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
        //          String.Join(@"\", FileConfig.Directories["SPREEDSHEET_SUB"].ToString(),
        //          username));

        //    DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

        //    if (!directoryInfo.Exists)
        //        throw new ApiException(7778, filePath + "No es una ruta válida",
        //            System.Net.HttpStatusCode.BadGateway, "NoLink");

        //    filePath = Path.Combine(filePath,
        //          String.Join(@"\", filename));

        //    return filePath;
        //}
        //#endregion


        public override string getPrivatePath(string username)
        {
            return Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
                      String.Join(@"\", FileConfig.Directories["SPREEDSHEET_SUB"].ToString(),
                      username));
        }

        public override string getPublicPath()
        {
            return Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
                      String.Join(@"\", FileConfig.Directories["PUBLICSPREEDSHEET_SUB"].ToString()
                      /*, remoteFile.FileName*/));
        }



    }
}