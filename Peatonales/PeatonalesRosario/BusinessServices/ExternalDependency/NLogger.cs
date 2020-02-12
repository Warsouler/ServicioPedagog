using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Resolver.Exceptions;
using System.Web;
using System.Web.Http.Tracing;
using NLog.Config;
using NLog.Targets;

namespace BusinessServices.ExternalDependency
{
    public sealed class NLogger : ITraceWriter
    {
        #region Private member variables.
        private static readonly Logger ClassLogger = LogManager.GetCurrentClassLogger();

        private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> LoggingMap = new Lazy<Dictionary<TraceLevel, Action<string>>>(() => new Dictionary<TraceLevel, Action<string>> { { TraceLevel.Info, ClassLogger.Info }, { TraceLevel.Debug, ClassLogger.Debug }, { TraceLevel.Error, ClassLogger.Error }, { TraceLevel.Fatal, ClassLogger.Fatal }, { TraceLevel.Warn, ClassLogger.Warn } });
        #endregion

        #region Private properties.
        private Dictionary<TraceLevel, Action<string>> Logger
        {
            get { return LoggingMap.Value; }
        }
        #endregion

        #region Public member methods.
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            // var logger = new NLogger();

            // GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());
            // var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            // trace.Error(context.Request, "Controller : "
            //+ context.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName +
            //Environment.NewLine + "Action : " + context.ActionContext.ActionDescriptor.ActionName, context.Exception
            //+ Environment.NewLine + "Status Code: " + HttpStatusCode.BadRequest
            //+ Environment.NewLine + "ReasonPhrase: " + HttpStatusCode.BadRequest.ToString()
            //+ Environment.NewLine + "Message: " + context.ActionContext.ModelState);
            // logger.Trace(new HttpRequestMessage().CreateResponse(ex.HResult), "1",)


            level = TraceLevel.Info;
            category = "Category";
            request = new HttpRequestMessage();

            if (level != TraceLevel.Off)
            {
                if (traceAction != null && traceAction.Target != null)
                {
                    category = category + Environment.NewLine + "Action Parameters : " + JsonConvert.SerializeObject(traceAction.Target);
                }
                var record = new TraceRecord(request, category, level);
                if (traceAction != null) traceAction(record);
                Log(record);
            }
        }
        #endregion

        #region Private member methods.
        private void Log(TraceRecord record)
        {
            var message = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append("").Append(record.Message + Environment.NewLine);

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append("Method: " + record.Request.Method + Environment.NewLine);

                if (record.Request.RequestUri != null)
                    message.Append("").Append("URL: " + record.Request.RequestUri + Environment.NewLine);

                if (record.Request.Headers != null && record.Request.Headers.Contains("Token") && record.Request.Headers.GetValues("Token") != null && record.Request.Headers.GetValues("Token").FirstOrDefault() != null)
                    message.Append("").Append("Token: " + record.Request.Headers.GetValues("Token").FirstOrDefault() + Environment.NewLine);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append("").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            if (record.Exception != null && !string.IsNullOrWhiteSpace(record.Exception.GetBaseException().Message))
            {
                var exceptionType = record.Exception.GetType();
                message.Append(Environment.NewLine);
                if (exceptionType == typeof(ApiException))
                {
                    var exception = record.Exception as ApiException;
                    if (exception != null)
                    {
                        message.Append("").Append("Error: " + exception.ErrorDescription + Environment.NewLine);
                        message.Append("").Append("Error Code: " + exception.ErrorCode + Environment.NewLine);
                    }
                }
                else if (exceptionType == typeof(ApiBusinessException))
                {
                    var exception = record.Exception as ApiBusinessException;
                    if (exception != null)
                    {
                        message.Append("").Append("Error: " + exception.ErrorDescription + Environment.NewLine);
                        message.Append("").Append("Error Code: " + exception.ErrorCode + Environment.NewLine);
                    }
                }
                else if (exceptionType == typeof(ApiDataException))
                {
                    var exception = record.Exception as ApiDataException;
                    if (exception != null)
                    {
                        message.Append("").Append("Error: " + exception.ErrorDescription + Environment.NewLine);
                        message.Append("").Append("Error Code: " + exception.ErrorCode + Environment.NewLine);
                    }
                }
                else
                    message.Append("").Append("Error: " + record.Exception.GetBaseException().Message + Environment.NewLine);
            }
            Logger[record.Level](Convert.ToString(message) + Environment.NewLine);
        }
        #endregion
        #region MercadoPago
        public void LogMercadoPago(Int64 idbusiness, String idcustomer, Int64 idlogmodel, String info, Int64 idmpidentity, Int64 idpayment, Int32 state)
        {
            var config = new LoggingConfiguration();

            // Step 2. Create targets and add them to the configuration
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);

            // Step 3. Set target properties
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            fileTarget.FileName = "${basedir}/PaymentLog/NLogger/${date:format=yyyy/MM/dd}-payment.log";
            fileTarget.Layout = "${message}";

            // Step 4. Define rules
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule2);

            // Step 5. Activate the configuration
            LogManager.Configuration = config;

            // Example usage
            Logger logger = LogManager.GetLogger("Example");
            var logMessage = "ID Log: " + idlogmodel
                + "\n | Date: " + DateTime.Now
                + "\n | ID MP Entity: " + idmpidentity
                + "\n | ID Customer: " + idcustomer
                + "\n | ID Payment: " + idpayment
                + "\n | ID Business: " + idbusiness
                + "\n | State: " + state
                + "\n | Info: " + info;
            logger.Trace(logMessage);


            //var message = new StringBuilder();

            //if (!string.IsNullOrWhiteSpace(Mensaje))
            //    message.Append("").Append(Mensaje);

            ////Logger.Trace(message, ex,"");
            
            //Logger[TraceLevel.Error](Convert.ToString(message) + Environment.NewLine);
        }
        #endregion

        #region LogHook
        public void LogHook(String id, Boolean live_mode, String type, String date_created, Int32 user_id, String api_version, String action, String data, String exMessage)
        {

            var config = new LoggingConfiguration();
            
            var consoleTarget = new ColoredConsoleTarget();
            config.AddTarget("console", consoleTarget);

            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            
            consoleTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            fileTarget.FileName = "${basedir}/PaymentLog/NLogger/${date:format=yyyy/MM/dd}-HOOK.log";
            fileTarget.Layout = "${message}";
            
            var rule1 = new LoggingRule("*", LogLevel.Trace, consoleTarget);
            config.LoggingRules.Add(rule1);

            var rule2 = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(rule2);
            
            LogManager.Configuration = config;
            
            Logger logger = LogManager.GetLogger("Example");
            var logMessage = "id: " + id
                + "\n | action: " + action.ToString()
                + "\n | api_version: " + api_version
                + "\n | date_created: " + date_created
                + "\n | live_mode: " + live_mode
                + "\n | type: " + type
                + "\n | user_id: " + user_id
                + "\n | data: " + data
                + "\n | exMessage: " + exMessage;
            logger.Trace(logMessage);
            
        }
        #endregion
    }
}