using HalClient.Net;
using HalClient.Net.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebApiFileUpload.DesktopClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// Create the default parser
            //IHalJsonParser parser = new HalJsonParser();

            //// Create the factory
            //IHalHttpClientFactory factory = new HalHttpClientFactory(parser);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
