#region Usings

using GO.Fwk.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using static System.Net.Mime.MediaTypeNames;

#endregion

namespace GO.Fwk.Toolkits.Mailing
{
    public class MailConfiguration : BaseConfiguration
    {
        #region Singleton

        /// <summary>
        /// variable of class, type MailConfiguration.
        /// </summary>
        private static MailConfiguration mailConfiguration;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private MailConfiguration()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static MailConfiguration GetInstance()
        {
            if (mailConfiguration == null)
            {
                mailConfiguration = new MailConfiguration();
            }

            return mailConfiguration;
        }

        #endregion

        #region Properties Implementation

        public string a()
        {
            string b = this.ConfigPath;
            return b;
        } 

        protected override string ConfigPath
        {
            get
            {
                if (this.configPath == null)
                {
                    
                    this.configPath = ConfigurationManager.AppSettings["MAIL_PATH"];
                }
                return this.configPath;
            }
        }

        #endregion
    }
}
