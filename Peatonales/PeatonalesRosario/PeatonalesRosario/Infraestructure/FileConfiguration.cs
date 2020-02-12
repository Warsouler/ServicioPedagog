#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


#endregion

namespace Servicio.Infraestructure
{
    public class FileConfiguration : BaseConfiguration
    {
        #region Singleton

        /// <summary>
        /// variable of class, type FileManager.
        /// </summary>
        private static FileConfiguration fileManager;

        /// <summary>
        /// Private Constractor.
        /// </summary>
        private FileConfiguration()
        { }

        /// <summary>
        /// Method with lazy instantiation.
        /// </summary>
        /// <returns></returns>
        public static FileConfiguration GetInstance()
        {
            if (fileManager == null)
            {
                fileManager = new FileConfiguration();
            }

            return fileManager;
        }

        #endregion

        #region Properties Implementation

        protected override string ConfigPath
        {
            get
            {
                if (this.configPath == null)
                {
                    this.configPath = ConfigurationManager.AppSettings["FILE_PATH"];
                }

                return this.configPath;
            }
        }

        #endregion
    }
}
