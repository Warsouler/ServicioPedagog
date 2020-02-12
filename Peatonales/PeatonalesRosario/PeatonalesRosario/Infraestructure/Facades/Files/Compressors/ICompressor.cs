using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServices.Pocos.Facades.Files.Compressors
{
    interface ICompressor
    {
        Stream Compress(File poco);
       byte[] ResizeImage(byte[] source, int size = 0);
        int Size();
    }
}
