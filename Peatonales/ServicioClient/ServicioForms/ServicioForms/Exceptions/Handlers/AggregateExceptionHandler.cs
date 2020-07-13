using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace MVCPeaton.Tools.Exceptions.Handlers
{
    public class AggregateExceptionHandler: BaseExceptionClientHandler
    {
        static AggregateExceptionHandler _instance;
        private AggregateExceptionHandler() { }
        public static AggregateExceptionHandler GetInstance()
        {
            if (_instance == null)
                _instance = new AggregateExceptionHandler();
            return _instance;
        }

        ModelStateDictionary _modelstate { get; set; }
        public AggregateExceptionHandler(ModelStateDictionary modelstate)
        {
            _modelstate = modelstate;
        }

        public override CompositeFillErrors HandleExceptions(Exception ex)
        {
            if (ex is AggregateException && ex.InnerException is AggregateException)
                return Run(ex.InnerException);
            return Mychainhandler.HandleExceptions(ex);
        }

        public override CompositeFillErrors Run(Exception ex)
        {
            int code;
            string message = "";
            HalHttpRequestException myex = (HalHttpRequestException)ex.InnerException;
            code = Int32.Parse(myex.Resource.State.Values.First(t => t.Name.Equals("ErrorCode")).Value.ToString());
            message = myex.Resource.State.Values.First(t => t.Name.Equals("ErrorDescription")).Value;
            KeyValuePair<int, string> rowerror = ClientCodeHandler.GetInstance().CodeExceptions.FirstOrDefault(t => t.Key.Equals(code));
            CompositeFillErrors cfe = new CompositeFillErrors() { Field = rowerror.Value, Message = message };
            return cfe;
        }

        public BaseExceptionClientHandler configureMyChainHandler()
        {
            return new AggregateExceptionHandler();
        }
    }
}