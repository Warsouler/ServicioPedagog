using Newtonsoft.Json;
using Servicio.ActionFilters;
using Servicio.ErrorHelper;
using Servicio.Infraestructure;
using Servicio.Infraestructure.Facades.Files;
using Servicio.Infraestructure.Facades.Files.Handling;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Servicio.Controllers
{
    [GlobalException]
    public class MyFilesController : ApiController
    {

        #region Public
        [AllowAnonymous]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PublicPicture")]
        [HttpPost]
        public async Task<string> UploadPublicPicture()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            PictureValidation.GetInstance().CompleteValidations(filecol);

            string uploadPath = PictureHandling.GetInstance().HandlingUpdatePublicDirectories();

            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();
            //string a = uploadPath.Substring(uploadPath.LastIndexOf("PublicPictures"));
            //a = a.Substring(a.IndexOf("\\"));

            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        [AllowAnonymous]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PublicPictureGUID")]
        [HttpPost]
        public async Task<string> UploadPublicPictureWithGUID()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            HttpPostedFile a = filecol.Get("FileUpload");
            PictureValidation.GetInstance().CompleteValidations(filecol);

            string uploadPath = PictureHandling.GetInstance().HandlingUpdatePublicDirectories();

            Guid Guided = Guid.NewGuid();
            uploadPath += "\\" + Guided.ToString("N") + ".jpg";

            //a.SaveAs(uploadPath);
            MemoryStream mss = new MemoryStream();
            a.InputStream.CopyTo(mss);
            


            using (mss)
            {
                ////with no compress;
                //Image img = System.Drawing.Image.FromStream(ms);

                //img.Save(withoutextension + "-th" + ".jpg");

                //with compress;
                Image img = System.Drawing.Image.FromStream(mss);
                EncoderParameters eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                string mimetype = GetMimeType(new System.IO.FileInfo(uploadPath).Extension);
                ImageCodecInfo ici = GetEncoderInfo(mimetype);
                img.Save(uploadPath, ici, eps);
            }


            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(uploadPath),
                FileLength = new FileInfo(uploadPath).Length,
                LocalFilePath = Cryptography.Encrypt(uploadPath),

            });
        }

        [AllowAnonymous]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/UploadPublicPictureCompresser")]
        [HttpPost]
        public async Task<string> UploadPublicPictureCompresser()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            PictureValidation.GetInstance().CompleteValidations(filecol);
            string uploadPath = PictureHandling.GetInstance().HandlingUpdatePublicDirectories();

            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

            string withoutextension = _localFileName.Split('.')[0];

            #region Qualitier
            var qualitiesparam = HttpContext.Current.Request.Params["qualitier"];
            Qualitiers q = JsonConvert.DeserializeObject<Qualitiers>(qualitiesparam);
            #endregion

            using (System.IO.MemoryStream ms = PictureHandling.GetInstance().Resize(_localFileName, q))
            {
                ////with no compress;
                //Image img = System.Drawing.Image.FromStream(ms);

                //img.Save(withoutextension + "-th" + ".jpg");

                //with compress;
                Image img = System.Drawing.Image.FromStream(ms);
                EncoderParameters eps = new EncoderParameters(1);
                eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                string mimetype = GetMimeType(new System.IO.FileInfo(_localFileName).Extension);
                ImageCodecInfo ici = GetEncoderInfo(mimetype);
                img.Save(withoutextension + "-th" + ".jpg", ici, eps);
            }

            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        static string GetMimeType(string ext)
        {
            //    CodecName FilenameExtension FormatDescription MimeType 
            //    .BMP;*.DIB;*.RLE BMP ==> image/bmp 
            //    .JPG;*.JPEG;*.JPE;*.JFIF JPEG ==> image/jpeg 
            //    *.GIF GIF ==> image/gif 
            //    *.TIF;*.TIFF TIFF ==> image/tiff 
            //    *.PNG PNG ==> image/png 
            switch (ext.ToLower())
            {
                case ".bmp":
                case ".dib":
                case ".rle":
                    return "image/bmp";

                case ".jpg":
                case ".jpeg":
                case ".jpe":
                case ".fif":
                    return "image/jpeg";

                case "gif":
                    return "image/gif";
                case ".tif":
                case ".tiff":
                    return "image/tiff";
                case "png":
                    return "image/png";
                default:
                    return "image/jpeg";
            }
        }

        static ImageCodecInfo GetEncoderInfo(string mimeType)
        {

            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();

            ImageCodecInfo encoder = (from enc in encoders
                                      where enc.MimeType == mimeType
                                      select enc).First();
            return encoder;

        }

        [AllowAnonymous]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PublicDocument")]
        [HttpPost]
        public async Task<string> UploadPublicDocument()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            DocumentValidation.GetInstance().CompleteValidations(filecol);

            string uploadPath = DocumentHandling.GetInstance().HandlingUpdatePublicDirectories();
            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        [AllowAnonymous]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PublicSpreedsheet")]
        [HttpPost]
        public async Task<string> UploadPublicSpreedSheet()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            SpreedSheetValidation.GetInstance().CompleteValidations(filecol);

            string uploadPath = SpreedSheetHandling.GetInstance().HandlingUpdatePublicDirectories();
            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPublicPicture")]
        public HttpResponseMessage DownloadPublicPicture(FileResult file)
        {
            HttpResponseMessage result = null;
            //string filename = "hh.jpg";
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            //filename = Path.GetFileName(filename);
            //filename = Path.GetFileName(filename);
            string path = PictureHandling.GetInstance().HandlingDownloadPublicDirectories(filename);

            PictureValidation.GetInstance().ValidateFileExist(path);
            //if (!File.Exists(path))
            //{
            //    throw new ApiException(7779, "La imagen no existe",
            //    System.Net.HttpStatusCode.Gone, "NoLink");
            //}
            //else
            //{
            // Serve the file to the client
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(PictureHandling.GetInstance().Resize(path, file.Qualitier));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename.Substring(filename.LastIndexOf("\\") + 1, filename.Length - filename.LastIndexOf("\\") - 1);
            //result.Content.Headers.ContentDisposition.FileName = filename;

            //}

            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPublicPicture64")]
        public string DownloadPublicPicture64(FileResult file)
        {
            HttpResponseMessage result = null;
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            if (!File.Exists(filename))
                return "";
            string path = PictureHandling.GetInstance().HandlingDownloadPublicDirectories(filename);
            PictureValidation.GetInstance().ValidateFileExist(path);
            //result = Request.CreateResponse(HttpStatusCode.OK);
            //result.Content = new StreamContent(PictureHandling.GetInstance().Resize(path, file.Qualitier));
            //result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //result.Content.Headers.ContentDisposition.FileName = filename.Substring(filename.LastIndexOf("\\") + 1, filename.Length - filename.LastIndexOf("\\") - 1);
            string src = Convert.ToBase64String(PictureHandling.GetInstance().Resize(path, file.Qualitier).ToArray());
            return src;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPublicPictureSrc")]
        public string DownloadPublicPictureSrc(FileResult file)
        {
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            string path = PictureHandling.GetInstance().HandlingDownloadPublicDirectories(filename);
            if (!File.Exists(filename))
                return "";
            String url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
            Int32 indexpath = path.IndexOf("\\MyFiles\\PublicPictures\\");
            String myrelativepath2 = path.Substring(indexpath);
            myrelativepath2 = myrelativepath2.Replace("\\", "/");
            string mypath2 = url + myrelativepath2;
            return mypath2;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPublicPictureSrcThumb")]
        public string DownloadPublicPictureSrcThumb(FileResult file)
        {
            #region Local
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            string path = PictureHandling.GetInstance().HandlingDownloadPublicDirectories(filename);
            Int32 indexextensionLocal = filename.IndexOf(".jpg");
            if (indexextensionLocal == -1)
                indexextensionLocal = filename.IndexOf(".png");
            if (indexextensionLocal == -1)
                indexextensionLocal = filename.IndexOf(".jpeg");
            if (indexextensionLocal == -1)
                throw new Exception("Error con la extensión");
            String filenametoverify = filename.Insert(indexextensionLocal, "-th");
            if (!File.Exists(filenametoverify))
                return DownloadPublicPictureSrc(file);
            #endregion

            #region Public
            String url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
            Int32 indexpath = path.IndexOf("\\MyFiles\\PublicPictures\\");
            String myrelativepath2 = path.Substring(indexpath);
            myrelativepath2 = myrelativepath2.Replace("\\", "/");
            Int32 indexextension = myrelativepath2.IndexOf(".jpg");
            myrelativepath2 = myrelativepath2.Insert(indexextension, "-th");
            string mypath2 = url + myrelativepath2;
            #endregion

            return mypath2;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //[Route("~/api/MyFiles/DownloadPublicPictureSrc")]
        //public string DownloadPublicPictureSrc(string filepath)
        //{
        //    FileResult file = new FileResult();
        //    file.LocalFilePath = filepath;
        //    file.Qualitier = new Qualitiers() { Fitmode = FitMode.Stretch, Widht = 430, Height = 270, Quality = 100 };
        //    HttpResponseMessage result = null;
        //    string filename = Cryptography.Decrypt(file.LocalFilePath);
        //    string path = PictureHandling.GetInstance().HandlingDownloadPublicDirectories(filename);
        //    string myrelativepath = path.Replace("E:\\PeatonUp\\Peatonales\\Servicio\\Servicio\\MyFiles\\PublicPictures\\", "");
        //    myrelativepath=myrelativepath.Replace("\\","/");
        //    //string mypath = "http://localhost:8089/MyFiles/PublicPictures/31-10-2017/000b6e82c0a5405bad4f55358ae96906.jpg";
        //    string mypath = "http://localhost:8089/MyFiles/PublicPictures/"+myrelativepath;
        //    //path = path.Replace("E:/PeatonUp/Peatonales/Servicio/Servicio/", "http://localhost:8089/");
        //    //PictureValidation.GetInstance().ValidateFileExist(path);
        //    //result = Request.CreateResponse(HttpStatusCode.OK);
        //    //result.Content = new StreamContent(PictureHandling.GetInstance().Resize(path, file.Qualitier));
        //    //result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
        //    //result.Content.Headers.ContentDisposition.FileName = filename.Substring(filename.LastIndexOf("\\") + 1, filename.Length - filename.LastIndexOf("\\") - 1);
        //    //string src = Convert.ToBase64String(PictureHandling.GetInstance().Resize(path, file.Qualitier).ToArray());
        //    //return src;
        //    return mypath;
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPublicDocument")]
        public HttpResponseMessage DownloadPublicDocument(FileResult file)
        {
            HttpResponseMessage result = null;

            //string filename = "36430309-imagenes-hd.jpg";
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            filename = Path.GetFileName(filename);
            string path = DocumentHandling.GetInstance().HandlingDownloadPublicDirectories(filename);
            DocumentValidation.GetInstance().ValidateFileExist(path);
            //if (!File.Exists(path))
            //{
            //    throw new ApiException(7779, "El documento no existe",
            //        System.Net.HttpStatusCode.Gone, "NoLink");
            //}
            //else
            //{
            // Serve the file to the client
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename;
            //}

            return result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPublicSpreedSheet")]
        public HttpResponseMessage DownloadPublicSpreedSheet(FileResult file)
        {
            HttpResponseMessage result = null;
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            filename = Path.GetFileName(filename);
            string path = SpreedSheetHandling.GetInstance().HandlingDownloadPublicDirectories(filename);
            SpreedSheetValidation.GetInstance().ValidateFileExist(path);
            //if (!File.Exists(path))
            //{
            //    throw new ApiException(7779, "La hoja de cálculo no existe",
            //        System.Net.HttpStatusCode.Gone, "NoLink");
            //}
            //else
            //{
            // Serve the file to the client
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename;
            //}

            return result;
        }
        #endregion

        #region Private
        [Authorize]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PrivatePicture")]
        [HttpPost]
        public async Task<string> UploadPrivatePicture()
        {

            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            PictureValidation.GetInstance().CompleteValidations(filecol);

            string username = User.Identity.Name;


            string uploadPath = PictureHandling.GetInstance().HandlingUpdatePrivateDirectories(username);

            //var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

            // Generate a provider with a custom class, passing the path( later pass the path to base class).
            // This support a multipart upload.
            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();


            //_localFileName = Cryptography.Decrypt(_localFileName);
            //Encrypt
            //_localFileName = Cryptography.Encrypt(_localFileName);
            // Create response
            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        [Authorize]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PrivateDocument")]
        [HttpPost]
        public async Task<string> UploadPrivateDocument()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            DocumentValidation.GetInstance().CompleteValidations(filecol);
            string username = User.Identity.Name;
            string uploadPath = DocumentHandling.GetInstance().HandlingUpdatePrivateDirectories(username);
            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();
            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        [Authorize]
        [MimeMultipartFilter]
        [Route("~/api/MyFiles/PrivateSpreedsheet")]
        [HttpPost]
        public async Task<string> UploadPrivateSpreedSheet()
        {
            HttpFileCollection filecol = HttpContext.Current.Request.Files;
            SpreedSheetValidation.GetInstance().CompleteValidations(filecol);
            string username = User.Identity.Name;

            string uploadPath = SpreedSheetHandling.GetInstance().HandlingUpdatePrivateDirectories(username);
            var multipartFormDataStreamProvider = new UploadMultipartFormProvider(uploadPath);
            await Request.Content.ReadAsMultipartAsync(multipartFormDataStreamProvider);

            string _localFileName = multipartFormDataStreamProvider
                .FileData.Select(multiPartData => multiPartData.LocalFileName).FirstOrDefault();

            return JsonConvert.SerializeObject(new FileResult
            {
                FileName = Path.GetFileName(_localFileName),
                FileLength = new FileInfo(_localFileName).Length,
                LocalFilePath = Cryptography.Encrypt(_localFileName),

            });
        }

        [Authorize]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPrivatePicture")]
        public HttpResponseMessage DownloadPrivatePicture(FileResult file)
        {
            HttpResponseMessage result = null;
            string username = User.Identity.Name;
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            filename = Path.GetFileName(filename);
            string path = PictureHandling.GetInstance().HandlingDownloadPrivateDirectories(username, filename);
            PictureValidation.GetInstance().ValidateFileExist(path);
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(PictureHandling.GetInstance().Resize(path, file.Qualitier));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename;

            return result;
        }

        [Authorize]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPrivateDocument")]
        public HttpResponseMessage DownloadPrivateDocument(FileResult file)
        {
            HttpResponseMessage result = null;

            string username = User.Identity.Name;
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            filename = Path.GetFileName(filename);
            string path = DocumentHandling.GetInstance().HandlingDownloadPrivateDirectories(username, filename);
            DocumentValidation.GetInstance().ValidateFileExist(path);
            // Serve the file to the client
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename;
            //}

            return result;
        }

        [Authorize]
        [HttpPost]
        [Route("~/api/MyFiles/DownloadPrivateSpreedSheet")]
        public HttpResponseMessage DownloadPrivateSpreedSheet(FileResult file)
        {
            HttpResponseMessage result = null;

            string username = User.Identity.Name;
            string filename = Cryptography.Decrypt(file.LocalFilePath);
            filename = Path.GetFileName(filename);
            string path = SpreedSheetHandling.GetInstance().HandlingDownloadPrivateDirectories(username, filename);
            SpreedSheetValidation.GetInstance().ValidateFileExist(path);
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(path, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filename;
            return result;
        }
        #endregion






    }
}
