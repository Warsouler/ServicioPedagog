using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.Models.Security
{
    public class EmployeeAccountBindingModel
    {
        #region Members
        // Members
        private Int64 _idemployeeaccount;
        private String _username;
        private String _password;
        private Int32 _state;

        //// ForeignKey
        //private Int64 _idbusinessconfiguration;

        //// Navigation property
        //private BusinessConfiguration _BusinessConfiguration;
        #endregion

        #region Properties
        // Properties
        public Int64 idemployeeaccount
        {
            get
            {
                return _idemployeeaccount;
            }

            set
            {
                _idemployeeaccount = value;
            }
        }

        public String username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public String password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public Int32 state
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        //// ForeignKey
        //public Int64 idbusinessconfiguration
        //{
        //    get
        //    {
        //        return _idbusinessconfiguration;
        //    }

        //    set
        //    {
        //        _idbusinessconfiguration = value;
        //    }
        //}

        //// Navigation property
        //public BusinessConfigurationBE BusinessConfiguration
        //{
        //    get
        //    {
        //        return _BusinessConfiguration;
        //    }

        //    set
        //    {
        //        _BusinessConfiguration = value;
        //    }
        //}
        #endregion
    }
}