//using GO.Fwk.Toolkits.File;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.IO;
//using System.IO.Compression;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WCFServices.Pocos.Facades.Files.Compressors;

//namespace WCFServices.Pocos.Facades.Files.Compressors
//{
//    public class Compressor:ICompressor
//    {
//        private static Compressor _compressor;
//        private Compressor() { }

//        protected readonly Int32 _size=220;

//        public static Compressor GetInstance()
//        {
//            if (_compressor == null)
//            {
//                _compressor = new Compressor();
//            }
//            return _compressor;
//        }


//        public Stream Compress(File poco)
//        {


//            String filePath = Path.Combine(FileConfiguration.GetInstance().AppSettings["PRINCIPAL_PATH"],
//            String.Join(@"\", FileConfiguration.GetInstance().AppSettings["PICTURE_SUB"].ToString(), poco.UserName, poco.FileName));

//            Stream Output;

//            using (var input = System.IO.File.OpenRead(filePath))
//            {
//                //Stream stream = poco.FileByteStream;
//                //int size = Size();
//                //byte[] bytes = new byte[input.Length];

//                //bytes = ResizeImage(bytes, Size());
//                //stream.Read(bytes, 0, bytes);
//                using (var output = new MemoryStream())
//                {
//                    Resize(input, output, 640, 480);
//                    return output;
//                }
//            }

//            //poco.FileByteStream = new DeflateStream(new FileStream(filePath, FileMode.Open, FileAccess.Read),CompressionLevel.Optimal);
//            //using (Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//            //{
//            //    //Stream stream = poco.FileByteStream;
//            //    int size = Size();
//            //    byte[] bytes = new byte[stream.Length];

//            //    bytes = ResizeImage(bytes, Size());
//            //    stream.Read(bytes, 0, bytes);

//            //    return stream;
//            //}
//        }

//        public void Resize(Stream input, Stream output, int width, int height)
//        {
//            using (var image = Image.FromStream(input))
//            using (var bmp = new Bitmap(width, height))
//            using (var gr = Graphics.FromImage(bmp))
//            {
//                gr.CompositingQuality = CompositingQuality.HighSpeed;
//                gr.SmoothingMode = SmoothingMode.HighSpeed;
//                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
//                gr.DrawImage(image, new Rectangle(0, 0, width, height));
//                bmp.Save(output, ImageFormat.Png);
                
//            }
//        }



//        public byte[] ResizeImage(byte[] source, int size = 0)
//        {
//            byte[] res = null;

//            // Se define un tamaño predeterminado, para el caso de que no se le dé valor a la variable size
//            const int defaultSize = 100;

//            // El arreglo de bytes será convertido a un Stream dentro del método, el cual será vaciado al final de la operación para liberar la imagen.
//            // Esto es muy útil cuando se está leyendo la imagen desde un archivo del disco, pues si el objeto Stream queda abierto, el archivo puede ser bloqueado.
//            using (MemoryStream ms = new MemoryStream(source, 0, source.Length))
//            {
//                // Se utiliza un objeto Image para leer el contenido de la imagen
//                Image img = Image.FromStream(ms);

//                #region Dimensiones
//                // La variable max tendrá el valor en el que se va a dimensionar la imagen.
//                // En este método, este tamaño se aplicará a la anchura o a la altura, dependiendo cuál es la mayor.
//                // Si se necesita aplicar siempre a la altura o siempre a la anchura, se debe cambiar esta parte del código.
//                int
//                    max = size > 0 ? size : defaultSize,
//                    h = img.Height, // altura actual de la imagen
//                    w = img.Width, // anchura actual de la imagen
//                    newH, newW; // variables que tendrán el nuevo tamaño, según la variable size

//                if (h == w && h > max) // Si el tamaño es igual en ambos lados, las nuevas dimensiones reciben el mismo valor
//                {
//                    newH = newW = max;
//                }
//                else if (h > w && h > max) // Si la altura es mayor, max se aplica a la altura y la anchura se ajusta a este nuevo tamaño
//                {
//                    newH = max;
//                    newW = (w * max) / h;
//                }
//                else if (w > h && w > max) // Si la anchura es mayor que la altura, se hace lo contrario a la condición anterior
//                {
//                    newW = max;
//                    newH = (h * max) / w;
//                }
//                else
//                {
//                    // Si tanto la anchura como la altura son menores a la variable max, se deja su valor actual.
//                    // Si queremos forzar el redimensionamiento aunque la imagen sea menor al tamaño deseado, podemos omitir esta condición y cambiar la primera
//                    newH = h;
//                    newW = w;
//                }
//                #endregion

//                if (h != newH && w != newW)
//                {
//                    // Para cambiar el tamaño de la imagen, usamos un nuevo objeto Image, dentro del cual guardaremos la imagen redimensionada
//                    using (Bitmap newImg = new Bitmap(img, newW, newH))
//                    {
//                        using (Graphics g = Graphics.FromImage(newImg))
//                        {
//                            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
//                            g.DrawImage(img, 0, 0, newImg.Width, newImg.Height);
//                        }
//                        // El objeto res será el contenido en bytes de la imagen nueva
//                        res = (byte[])new ImageConverter().ConvertTo(newImg, typeof(byte[]));
//                    }
//                }
//                else
//                {
//                    // Si no hay diferencias entre el tamaño anterior y el nuevo, el objeto res será el contenido de la imagen original
//                    res = (byte[])new ImageConverter().ConvertTo(img, typeof(byte[]));
//                }
//                // Aquí cerramos el objeto Stream para liberar la imagen. Este paso es necesario para evitar que la imagen se bloquee.
//                ms.Flush();
//                ms.Close();
//            }

//            return res;
//        }

//        public int Size()
//        {
//            return _size;
//        }

//        public byte[] Compress(byte[] data)
//        {
//            byte[] compressArray = null;
//            try
//            {
//                using (MemoryStream memoryStream = new MemoryStream())
//                {
//                    using (DeflateStream deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress))
//                    {
//                        deflateStream.Write(data, 0, data.Length);
//                    }
//                    compressArray = memoryStream.ToArray();
//                }
//            }
//            catch (Exception exception)
//            {
//                // do something !
//            }
//            return compressArray;
//        }
//    }
//}
