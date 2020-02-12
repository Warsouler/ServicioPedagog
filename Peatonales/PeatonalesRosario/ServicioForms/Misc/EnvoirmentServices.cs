using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Misc
{
    public static class EnvoirmentServices
    {
        public const string hostname = "localhost";
        public const string port = "8105";
        public const string scheme = "http";
        public const string urlservice = scheme + "://" + hostname + ":" + port;
    }
}
