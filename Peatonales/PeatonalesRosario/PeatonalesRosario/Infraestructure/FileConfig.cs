using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure
{
    public static class FileConfig
    {
        private static Dictionary<string, string> mimesSupported;
        private static Dictionary<string, string> directories;
        private static Dictionary<string, string> extensions;

        #region Singleton

        ///  summary>
        /// variable of class, type FileManager.
        ///  /summary>
        //private static FileConfig fileConfig;

        public static Dictionary<string, string> MimesSupported
        {
            get
            {
                if (mimesSupported == null)
                    chargeMimes();
                return mimesSupported;
            }

            set
            {
                ;
            }
        }

        public static Dictionary<string, string> Directories
        {
            get
            {
                if (directories == null)
                    chargedirectories();
                return directories;
            }

            set
            {
                directories = value;
            }
        }

        public static Dictionary<string, string> Extensions
        {
            get
            {
                if (extensions == null)
                    chargeextensions();
                return extensions;
            }

            set
            {
                extensions = value;
            }
        }

        ///  summary>
        /// Private Constractor.
        ///  /summary>
        //private FileConfig()
        //{
        //    chargeMimes();
        //    chargedirectories();
        //    chargeextensions();

        //}

        private static void chargeextensions()
        {
            extensions = new Dictionary<string, string>();
            extensions.Add("PDF", ".pdf");
            extensions.Add("JPE", ".jpe");
            extensions.Add("JPG", ".jpg");
            extensions.Add("JPEG", ".jpeg");
            extensions.Add("PNG", ".png");
            extensions.Add("DOC", ".doc");
            extensions.Add("DOCX", ".docx");
            extensions.Add("ODT", ".odt");
            extensions.Add("XLS", ".xls");
            extensions.Add("XLSX", ".xlsx");
            extensions.Add("ODS", ".ods");
            
        }

        private static void chargedirectories()
        {
            directories = new Dictionary<string, string>();
            //directories.Add("PRINCIPAL_PATH", "D:\\PeatonUp\\Peatonales\\Servicio\\Servicio\\MyFiles");
            directories.Add("PRINCIPAL_PATH", "E:\\PeatonUp\\Peatonales\\Servicio\\Servicio\\MyFiles");
            directories.Add("PICTURE_SUB" , "Pictures");
            directories.Add("DOCUMENT_SUB", "Documents");
            directories.Add("SPREEDSHEET_SUB", "Spreedsheet");
            directories.Add("PUBLICPICTURE_SUB", "PublicPictures");
            directories.Add("PUBLICDOCUMENT_SUB", "PublicDocuments");
            directories.Add("PUBLICSPREEDSHEET_SUB", "PublicSpreedsheet");
        }

        private static void chargeMimes()
        {
            mimesSupported = new Dictionary<string, string>();
            mimesSupported.Add("MIME_JPEG", "image/pjpeg");
            mimesSupported.Add("MIME_JPG", "image/jpeg");
            mimesSupported.Add("MIME_PNG", "image/png");
            mimesSupported.Add("MIME_DOC", "application/msword");
            mimesSupported.Add("MIME_DOCX", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
            mimesSupported.Add("MIME_XLS", "application/vnd.ms-excel");
            mimesSupported.Add("MIME_XLSX", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            mimesSupported.Add("MIME_PDF", "application/pdf");
            mimesSupported.Add("MIME_ODT", "application/vnd.oasis.opendocument.text");
            mimesSupported.Add("MIME_ODS", "application/vnd.oasis.opendocument.spreadsheet");
        }

        ///  summary>
        /// Method with lazy instantiation.
        ///  /summary>
        ///  returns> /returns>
        //public static FileConfig GetInstance()
        //{
        //    if (fileConfig == null)
        //    {
        //        fileConfig = new FileConfig();
        //    }

        //    return fileConfig;
        //}


        

        #endregion


    }
}