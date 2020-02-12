using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure.Facades.Files
{
    public class Compresser
    {
        public TypeCompesser Typecompresser;
    }

    public enum TypeCompesser
    {
        None = 1,
        Gzip = 2,
        Tar = 3,
        Deflate = 4
    }
}