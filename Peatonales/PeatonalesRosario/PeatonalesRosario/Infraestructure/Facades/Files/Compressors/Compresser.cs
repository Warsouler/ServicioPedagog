using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices.Pocos.Facades.Files.Compressors
{
    public class Compresser
    {
         public TypeCompesser Typecompresser;
    }

    public enum TypeCompesser
    {
      None=1,
      Gzip=2,
      Tar=3,
      Deflate=4
    }
}
