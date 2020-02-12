//using GO.Fwk.Exceptions;
//using GO.Fwk.Exceptions.CustomException;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
//using WCFServices.Pocos.Files;

//namespace WCFServices.Pocos.Facades.Files.Handling.Public
//{
//    public class SpreadSheetPublicHandling : FileHandling<SpreadSheetStrategy>
//    {
//        #region Singleton

//        /// <summary>
//        /// Variable of class, type SpreadSheetHandling.
//        /// </summary>
//        private static SpreadSheetPublicHandling spreadSheetHandling;

//        /// <summary>
//        /// Private Constractor.
//        /// </summary>
//        private SpreadSheetPublicHandling()
//        { }

//        /// <summary>
//        /// Method with lazy instantiation.
//        /// </summary>
//        /// <returns></returns>
//        public static SpreadSheetPublicHandling GetInstance()
//        {
//            if (spreadSheetHandling == null)
//            {
//                spreadSheetHandling = new SpreadSheetPublicHandling();
//            }

//            return spreadSheetHandling;
//        }

//        #endregion

//        protected override string SuDirectory
//        {
//            get
//            {
//                return FileConfiguration.GetInstance().AppSettings["DOCUMENT_SUB"].ToString();
//            }
//        }

//        public override File DownloadFile(File remoteFile)
//        {
//            String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//      String.Join(@"\", remoteFile.Path));

//            FileInfo fileInfo = new FileInfo(filePath);

//            this.DirectoryExistenceValidation(fileInfo);

//            this.FileExistenceValidation(fileInfo);

//            this.FileStrategy.Validate(fileInfo);

//            remoteFile.Length = fileInfo.Length;
//            remoteFile.FileByteStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

//            return remoteFile;
//        }

//        public override File UploadFile(File remoteFile)
//        {
//            String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//      String.Join(@"\", DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year, @"\",
//      FileConfiguration.GetInstance().AppSettings["DOCUMENT_SUB"].ToString()
//      , remoteFile.UserName + remoteFile.FileName));

//            //    String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//            //String.Join(@"\", DateTime.Now.ToShortDateString(), remoteFile.UserName, remoteFile.FileName));


//            //String filePath = this.getPath(remoteFile);

//            FileInfo fileInfo = new FileInfo(filePath);

//            // Creo el directorio si no existe.
//            if (!fileInfo.Directory.Exists)
//                Directory.CreateDirectory(fileInfo.DirectoryName);

//            // Elimino el archivo si existe.
//            if (fileInfo.Exists)
//            {
//                BusinessException techEx = new BusinessException(ExceptionConfiguration.GetInstance().AppSettings["xxx_028"].ToString(), ExceptionConfiguration.GetInstance().AppSettings["xxx_div_002"].First().ToString());

//                throw new FaultException<BusinessException>(techEx);
//            }

//            this.FileStrategy.Validate(fileInfo);

//            using (FileStream targetStream =
//                new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
//            {
//                //Se lee de a trozos de 64Kb del Stream.
//                const int bufferLen = 65000;
//                byte[] buffer = new byte[bufferLen];
//                int count = 0;
//                while ((count = remoteFile.FileByteStream.Read(buffer, 0, bufferLen)) > 0)
//                {
//                    // save to output stream
//                    targetStream.Write(buffer, 0, count);
//                }
//            }
//            remoteFile.Path = filePath;
//            return remoteFile;
//        }
//    }
//}

