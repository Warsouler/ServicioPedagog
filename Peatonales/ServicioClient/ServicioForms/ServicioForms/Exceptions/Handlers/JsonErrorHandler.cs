using Exceptions.CustomFormaterExceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Handlers
{
    public class JsonErrorHandler : BaseExceptionClientHandler
    {
        [JsonProperty]
        public int ErrorCode { get; set; }
        [JsonProperty]
        public string ErrorDescription { get; set; }
        [JsonProperty]
        public HttpStatusCode HttpStatus { get; set; }

        string reasonPhrase;

        [JsonProperty]
        public string ReasonPhrase
        {
            get
            {
                return this.HttpStatus.ToString();
            }

            set { this.reasonPhrase = value; }
        }

        [JsonProperty]
        public string ReferenceLink { get; set; }


        public override CompositeFillErrors HandleExceptions(Exception ex)
        {
            if (ex.InnerException is JsonErrorHandler)
                return Run(ex);
            return Mychainhandler.HandleExceptions(ex);
        }

        public override CompositeFillErrors Run(Exception ex)
        {
            int code;
            string message = "";
            JsonErrorHandler myex = (JsonErrorHandler)ex.InnerException;
            code = myex.ErrorCode;
            message = myex.ErrorDescription;
            KeyValuePair<int, string> rowerror = ClientCodeHandler.GetInstance().CodeExceptions.FirstOrDefault(t => t.Key.Equals(code));
            CompositeFillErrors cfe = new CompositeFillErrors() { Field = rowerror.Value, Message = message };
            return cfe;
        }

        public static void HandleError(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new JsonErrorHandler
                ()
                {
                    ErrorCode = (int)HttpStatusCode.Unauthorized,
                    ReferenceLink = "",
                    ErrorDescription = "No está authorizado para realizar esta acción",
                    HttpStatus = HttpStatusCode.Unauthorized,
                };

            JsonError ap = JsonConvert.DeserializeObject<JsonError>(response.Content.ReadAsStringAsync().Result);
            throw new JsonErrorHandler
            ()
            {
                ErrorCode = ap.ErrorCode,
                ReferenceLink = ap.ReferenceLink,
                ErrorDescription = ap.ErrorDescription,
                HttpStatus = ap.HttpStatus
            };
        }

        static JsonErrorHandler _instance;
        private JsonErrorHandler() { }
        public static JsonErrorHandler GetInstance()
        {
            if (_instance == null)
                _instance = new JsonErrorHandler();
            return _instance;
        }
    }
}
