using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.General
{
   public static class ApplicationsVariables
    {
        private static string token = "";
        public static string Token
        {
            get { return token; }
            set { token = value; }
        }

        private static string username = "";
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        private static DataValues datavalues;

        public static DataValues Datavalues
        {
            get
            {
                if (datavalues == null)
                    datavalues = new DataValues();
                return datavalues;
            }

            set
            {
                datavalues = value;
            }
        }

        
    }
}
