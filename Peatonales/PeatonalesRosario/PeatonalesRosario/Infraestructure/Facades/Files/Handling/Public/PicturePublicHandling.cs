//using GO.Fwk.Exceptions;
//using GO.Fwk.Exceptions.CustomException;
//using ImageResizer;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.IO;
//using System.Linq;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
//using WCFServices.Pocos.Facades.Files.Compressors;
//using WCFServices.Pocos.Files;

//namespace WCFServices.Pocos.Facades.Files.Handling.Public
//{
//   public class PicturePublicHandling : FileHandling<PictureStrategy>
//    { 
//    #region Singleton

//    /// <summary>
//    /// Variable of class, type PictureHandling.
//    /// </summary>
//    private static PicturePublicHandling pictureHandling;

//    /// <summary>
//    /// Private Constractor.
//    /// </summary>
//    private PicturePublicHandling()
//    { }

//    /// <summary>
//    /// Method with lazy instantiation.
//    /// </summary>
//    /// <returns></returns>
//    public static PicturePublicHandling GetInstance()
//    {
//        if (pictureHandling == null)
//        {
//            pictureHandling = new PicturePublicHandling();
//        }

//        return pictureHandling;
//    }

//    #endregion

//    #region Implementation Properties

//    protected override string SuDirectory
//    {
//        get
//        {
//            return FileConfiguration.GetInstance().AppSettings["PICTURE_SUB"].ToString();
//        }
//    }
//        public override File UploadFile(File remoteFile)
//        {

//            String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//        String.Join(@"\", DateTime.Now.Day+"-"+ DateTime.Now.Month+"-"+DateTime.Now.Year, @"\", FileConfiguration.GetInstance().AppSettings["PICTURE_SUB"].ToString()
//        , remoteFile.UserName+remoteFile.FileName));

//        //    String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//        //String.Join(@"\", DateTime.Now.ToShortDateString(), remoteFile.UserName, remoteFile.FileName));


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
//        public override File DownloadFile(File remoteFile)
//    {
//            //String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//            //String.Join(@"\", FileConfiguration.GetInstance().AppSettings["PICTURE_SUB"].ToString(), remoteFile.UserName, remoteFile.FileName));
//            String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//        String.Join(@"\", remoteFile.Path));

//            var input = System.IO.File.OpenRead(filePath);
//        var resultStream = new MemoryStream();

//        ImageJob job = new ImageJob(input, resultStream, new Instructions
//        {
//            Width = remoteFile.Qualitier.Widht,

//            Height = remoteFile.Qualitier.Height,
//            JpegQuality = remoteFile.Qualitier.Quality,

//            Mode = TypesComparision.GetInstance().Convert(remoteFile.Qualitier.Fitmode)
//        });

//        job.Build();
//        resultStream.Seek(0, SeekOrigin.Begin);

//        if (remoteFile.Compress.Typecompresser != TypeCompesser.None)
//        {

//        }
//        remoteFile.FileByteStream = resultStream;
//        return remoteFile;
//    }

//    public void Resize(Stream input, Stream output, int width, int height)
//    {
//        using (var image = Image.FromStream(input))
//        using (var bmp = new Bitmap(width, height))
//        using (var gr = Graphics.FromImage(bmp))
//        {
//            gr.CompositingQuality = CompositingQuality.HighSpeed;
//            gr.SmoothingMode = SmoothingMode.HighSpeed;
//            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
//            gr.DrawImage(image, new Rectangle(0, 0, width, height));
//            bmp.Save(output, ImageFormat.Png);
//        }
//    }


//    public List<byte[]> DownloadMultipleArray(string username, IEnumerable<string> fileIds, Qualitiers qual, Compresser compress)
//    {
//        if (fileIds == null)
//            return null;
//        //var selectedFiles = GetSelectedFilesByFileIds(username, fileIds);

//        List<byte[]> lista = new List<byte[]>();

//        foreach (string pathh in fileIds)
//        {
//            String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//            String.Join(@"\", FileConfiguration.GetInstance().AppSettings["PICTURE_SUB"].ToString(), username, pathh));

//            var input = System.IO.File.OpenRead(filePath);
//            var resultStream = new MemoryStream();

//            ImageJob job = new ImageJob(input, resultStream, new Instructions
//            {
//                Width = qual.Widht,

//                Height = qual.Height,
//                JpegQuality = qual.Quality,

//                Mode = TypesComparision.GetInstance().Convert(qual.Fitmode)
//            });

//            job.Build();
//            resultStream.Seek(0, SeekOrigin.Begin);

//            if (compress.Typecompresser != TypeCompesser.None)
//            {

//            }

//            BinaryReader reader = new BinaryReader(resultStream);

//            lista.Add(reader.ReadBytes(Convert.ToInt32(resultStream.Length)));



//            //if (remoteFile.Compress.Typecompresser != TypeCompesser.None)
//            //{

//            //}

//        }
//        return lista;


//        //if (fileIds == null)
//        //    return null;
//        //var selectedFiles = GetSelectedFilesByFileIds(username, fileIds);
//        //return Facades.Files.ZipHelper.ZipToMemoryStream(selectedFiles);
//    }




//    public Stream DownloadMultiple(string username, IEnumerable<string> fileIds)
//    {
//        if (fileIds == null)
//            return null;
//        var selectedFiles = GetSelectedFilesByFileIds(username, fileIds);
//        return Facades.Files.ZipHelper.ZipToMemoryStream(selectedFiles);
//    }

//    private string[] GetSelectedFilesByFileIds(string username, IEnumerable<string> fileIds)
//    {
//        if (fileIds == null)
//            throw new ArgumentNullException("fileIds");

//        var files = Directory.GetFiles(Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//                          String.Join(@"\", this.SuDirectory, username)));
//        return fileIds.Select(fileId => files.FirstOrDefault(name => name.IndexOf(fileId, StringComparison.Ordinal) > -1))
//            .Where(file => !string.IsNullOrEmpty(file)).ToArray();
//    }

//    #endregion
//}

//}
