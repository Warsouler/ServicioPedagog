#region Usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

using Servicio.Infraestructure;
using System.Web;
using Servicio.ErrorHelper;


#endregion

namespace Servicio.Infraestructure.Facades.Files
{
    public abstract class FileHandling /*: IFile*/

    {
        #region Property 
        FileValidation fileValidation;

        public FileValidation FileValidation
        {
            get
            {
                if (fileValidation == null)
                    fileValidation = ChargeMyValidator();
                return fileValidation;
            }

            set
            {
                ;
            }
        }

        public abstract FileValidation ChargeMyValidator();
        #endregion
        #region Public
        //public virtual string HandlingUpdatePublicDirectories()
        //{
        //    String uploadPath = this.getPublicPath();

        //    DirectoryInfo directoryInfo = new DirectoryInfo(uploadPath);

        //    // Creo el directorio si no existe.
        //    this.CreateOrNotDirectory(directoryInfo);
        //    //if (!directoryInfo.Exists)
        //    //    Directory.CreateDirectory(directoryInfo.FullName);
        //    return uploadPath;

        //}

        public virtual string HandlingUpdatePublicDirectories()
        {
            String uploadPath = this.getPublicPath();

            DirectoryInfo directoryInfo = new DirectoryInfo(uploadPath);

            // Creo el directorio si no existe.
            this.CreateOrNotDirectory(directoryInfo);

            uploadPath = uploadPath + "\\" + DateTime.Now.Day + "-" +
               DateTime.Now.Month + "-" + DateTime.Now.Year;

            directoryInfo = new DirectoryInfo(uploadPath);
            this.CreateOrNotDirectory(directoryInfo);

            return uploadPath;

        }
        public virtual string HandlingDownloadPublicDirectories(string filename)
        {
            String filePath = this.getPublicPath();

            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

            this.FileValidation.ValidateDownloadDirectory(directoryInfo, filePath);


            //if (!directoryInfo.Exists)
            //    throw new ApiException(7778, filePath + "No es una ruta válida",
            //        System.Net.HttpStatusCode.BadGateway, "NoLink");
            //filename.IndexOf(filePath)
            filename = filename.Substring(filePath.Length);

            //filePath = Path.Combine(filePath,
            //      String.Join(@"\", filename));
            filePath = filePath + filename;



            return filePath;
        }
        #endregion
        #region Private
        public virtual string HandlingUpdatePrivateDirectories(string username)
        {
            String uploadPath = this.getPrivatePath(username);

            DirectoryInfo directoryInfo = new DirectoryInfo(uploadPath);

            // Creo el directorio si no existe.
            this.CreateOrNotDirectory(directoryInfo);
            //if (!directoryInfo.Exists)
            //    Directory.CreateDirectory(directoryInfo.FullName);

            return uploadPath;

        }
        public virtual string HandlingDownloadPrivateDirectories(string username, string filename)
        {
            String filePath = this.getPrivatePath(username);

            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);

            this.FileValidation.ValidateDownloadDirectory(directoryInfo, filePath);
            //if (!directoryInfo.Exists)
            //    throw new ApiException(7778, filePath + "No es una ruta válida",
            //        System.Net.HttpStatusCode.BadGateway, "NoLink");

            filePath = Path.Combine(filePath,
                  String.Join(@"\", filename));

            return filePath;
        }
        #endregion
        public abstract string getPrivatePath(string username);
        public abstract string getPublicPath();
        //#region Singleton

        ///// <summary>
        ///// Variable of class, type PictureValidation.
        ///// </summary>
        //private static FileHandling fileHandling;

        ///// <summary>
        ///// Private Constractor.
        ///// </summary>
        //private FileHandling()
        //{ }

        ///// <summary>
        ///// Method with lazy instantiation.
        ///// </summary>
        ///// <returns></returns>
        //public static FileHandling GetInstance()
        //{
        //    if (fileHandling == null)
        //    {
        //        fileHandling = new FileHandling();
        //    }

        //    return fileHandling;
        //}

        //#endregion

        public void RemoveFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Elimino el archivo si existe.
            if (fileInfo.Exists)
                fileInfo.Delete();
        }


        public void CreateOrNotDirectory(DirectoryInfo directoryInfo)
        {
            if (!directoryInfo.Exists)
                Directory.CreateDirectory(directoryInfo.FullName);
        }








    }
}
