#region Usings

using System;
using System.Collections.Specialized;
using System.Xml;

#endregion

namespace GO.Fwk.Exceptions
{
    public abstract class BaseConfiguration
    {
        #region Members

        private NameValueCollection appSettings;
        protected String configPath;

        #endregion

        #region Properties

        protected abstract String ConfigPath
        {
            get;
        }

        public NameValueCollection AppSettings
        {
            get
            {
                if (this.appSettings == null)
                {
                    this.appSettings = new NameValueCollection();
                    this.Load(this.ConfigPath);
                }

                return this.appSettings;
            }
        }

        #endregion

        #region Methods

        private void Load(String path)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path);
            XmlNode xnodes = xdoc.SelectSingleNode("/configuration/appSettings");

            foreach (XmlNode xnn in xnodes.ChildNodes)
            {
                if (xnn.Attributes != null)
                    this.AppSettings[xnn.Attributes[0].Value] = xnn.Attributes[1].Value;
            }
        }

        #endregion
    }
}
