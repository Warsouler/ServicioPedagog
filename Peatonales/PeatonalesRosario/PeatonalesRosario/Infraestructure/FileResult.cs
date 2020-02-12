using Newtonsoft.Json;
using Servicio.Infraestructure.Facades.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Infraestructure
{
    public class FileResult
    {
        
        public string LocalFilePath { get; set; }
        public string FileName { get; set; }
        public long FileLength { get; set; }
        public string UserName { get; set; }
        public Qualitiers Qualitier { get; set; }

    }
}