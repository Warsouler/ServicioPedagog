using ImageResizer;
using Servicio.ErrorHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure.Facades.Files.Handling
{
    public class PictureHandling :FileHandling
    {
        #region Singleton

        /// <summary>
        /// Variable of class, type PictureValidation.
        /// </summary>
        private static PictureHandling handling;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private PictureHandling()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static PictureHandling GetInstance()
        {
            if (handling == null)
            {
                handling = new PictureHandling();
            }

            return handling;
        }

        #endregion
        #region Public


        //public override string HandlingUpdatePublicDirectories()
        //{
        //    String uploadPath = Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
        //              String.Join(@"\", FileConfig.Directories["PUBLICPICTURE_SUB"].ToString()
        //              ));

        //    DirectoryInfo directoryInfo = new DirectoryInfo(uploadPath);

        //    // Creo el directorio si no existe.
        //    this.CreateOrNotDirectory(directoryInfo);
        //    //if (!directoryInfo.Exists)
        //    //    Directory.CreateDirectory(directoryInfo.FullName);
        //    return uploadPath;
        //}



        //public override string HandlingDownloadPublicDirectories(string filename)
        //{
        //    String filePath = Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
        //          String.Join(@"\", FileConfig.Directories["PUBLICPICTURE_SUB"].ToString()
        //           ));

        //    DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

        //    this.FileValidation.ValidateDownloadDirectory(directoryInfo, filePath);

        //    //if (!directoryInfo.Exists)
        //    //    throw new ApiException(7778, filePath + "No es una ruta válida",
        //    //        System.Net.HttpStatusCode.BadGateway, "NoLink");

        //    filePath = Path.Combine(filePath,
        //          String.Join(@"\", filename));

        //    return filePath;
        //}
        #endregion
        public override string getPrivatePath(string username)
        {
            return Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
                  String.Join(@"\", FileConfig.Directories["PICTURE_SUB"].ToString(),
                  username));
        }

        public override string getPublicPath()
        {
            return Path.Combine(FileConfig.Directories["PRINCIPAL_PATH"].ToString(),
                   String.Join(@"\", FileConfig.Directories["PUBLICPICTURE_SUB"].ToString()
                    ));
        }


        //public MemoryStream Resize(string path, Qualitiers qualitier)
        //{
        //    FileStream input = System.IO.File.OpenRead(path);
        //    MemoryStream resultStream = new MemoryStream();
        //    if (qualitier.Height==0 && qualitier.Widht==0)
        //    {
        //        input.CopyTo(resultStream);
        //    }
        //    else
        //    {
        //        ImageJob job = new ImageJob(input, resultStream, new Instructions
        //        {
        //            Width = qualitier.Widht,

        //            Height = qualitier.Height,
        //            JpegQuality = qualitier.Quality,

        //            Mode = TypesComparision.GetInstance().Convert(qualitier.Fitmode)
        //        });

        //        job.Build();
        //    }

        //    resultStream.Seek(0, SeekOrigin.Begin);

        //    return resultStream;
        //}

        public MemoryStream Resize(string path, Qualitiers qualitier)
        {
            FileStream input = System.IO.File.OpenRead(path);
            MemoryStream resultStream = new MemoryStream();
            ImageJob job;
            if (qualitier.Height == 0 && qualitier.Widht == 0)
            {
                job = new ImageJob(input, resultStream, new Instructions
                {
                    JpegQuality = qualitier.Quality,

                    Mode = TypesComparision.GetInstance().Convert(qualitier.Fitmode)
                });
            }
            else
            {
             job = new ImageJob(input, resultStream, new Instructions
                {

                    Width = qualitier.Widht,

                    Height = qualitier.Height,
                    JpegQuality = qualitier.Quality,

                    Mode = TypesComparision.GetInstance().Convert(qualitier.Fitmode)
                });
            }
            job.Build();

            resultStream.Seek(0, SeekOrigin.Begin);

            return resultStream;
        }



        public override FileValidation ChargeMyValidator()
        {
            return PictureValidation.GetInstance();
        }
    }
}