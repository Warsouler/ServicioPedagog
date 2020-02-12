#region Usings

#endregion
using Servicio.ErrorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using Servicio.Infraestructure;
using System.IO;
using Resolver.Exceptions;

namespace Servicio.Infraestructure.Facades.Files
{
    public abstract class FileValidation 
    {
        //public HttpPostedFile File { get; set; }
        public void CompleteValidations(HttpFileCollection files)
        {
            HttpPostedFile file;

            if (files == null || files.Count<1)
                throw new ApiException(7775, "No hay ningun archivo",
                    System.Net.HttpStatusCode.BadRequest, "NoLink");

            for (int i=0; i<files.Count;i++)
            {
                file = files[i];
                if (String.IsNullOrEmpty(file.FileName))
                {
                    throw new ApiException(7770, "No se ha ingresado el nombre del archivo",
                        System.Net.HttpStatusCode.BadRequest, "NoLink");
                }

                if (file.ContentLength == 0)
                {
                    throw new ApiException(7771, "No existe el archivo",
                        System.Net.HttpStatusCode.BadRequest, "NoLink");
                }

                 if (file.ContentLength > 5242880)
                  {
                    throw new ApiException(7777, "No puede subir archivos superiores a 5MB",
                     System.Net.HttpStatusCode.BadRequest, "NoLink");
                    }

                    String extension = file.FileName.Split('.').LastOrDefault();

                if (extension == null)
                {
                    throw new ApiException(7772, "El archivo no tiene Extensión",
                        System.Net.HttpStatusCode.BadRequest, "NoLink");
                }

                    this.ExtensionsValidations(file.FileName);
               }
        }

        public abstract void ExtensionsValidations(String extension);
        public string GetMimeMapping(string filename)
        {
            return MimeMapping.GetMimeMapping(filename);
        }

        public void ValidateDownloadDirectory(DirectoryInfo directoryInfo, string filePath)
        {
            if (!directoryInfo.Exists)
                throw new ApiException(7778, filePath + "No es una ruta válida",
                    System.Net.HttpStatusCode.BadGateway, "NoLink");
        }

        public void ValidateFileExist(string path)
        {
            if (!File.Exists(path))
            {
                throw new ApiException(7779, "La imagen no existe",
                System.Net.HttpStatusCode.Gone, "NoLink");
            }
        }



    }
}
