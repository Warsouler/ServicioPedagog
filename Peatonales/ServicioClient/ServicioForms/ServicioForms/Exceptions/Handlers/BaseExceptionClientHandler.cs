using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exceptions.Handlers
{
    public abstract class BaseExceptionClientHandler:Exception
    {
        private BaseExceptionClientHandler mychainhandler;

        public BaseExceptionClientHandler Mychainhandler
        {
            get
            {
                //if (mychainhandler == null)
                //    mychainhandler = configureMyChainHandler();
                return mychainhandler;
            }

            set
            {
                mychainhandler = value;
            }
        }

        //public abstract BaseExceptionClientHandler configureMyChainHandler();
        

        public abstract CompositeFillErrors HandleExceptions(Exception ex);

        public abstract CompositeFillErrors Run(Exception ex);
    }
}