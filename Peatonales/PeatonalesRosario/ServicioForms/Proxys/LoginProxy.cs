using Newtonsoft.Json;
using ServicioForms.General;
using ServicioForms.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Proxys
{
    public class LoginProxy
    {
        protected string urlservice = EnvoirmentServices.urlservice;
        private HttpClient httpclient;
        private Uri url;
        private HttpClient Httpclient
        {
            get
            {
                if (httpclient == null)
                    httpclient = new HttpClient();
                return httpclient;
            }

            set
            {
                httpclient = value;
            }
        }

        public virtual string myserviceurl()
        {
            return urlservice + "/oauth/token";
        }



        public async Task<string> PerformLoginActions(string username, string password)
        {
            try
            {
                bool success = false;
                HttpStatusCode code;
                string responseBody = "";
                string ApiToken;
                using (Httpclient= new HttpClient())
                {
                    Httpclient.DefaultRequestHeaders.Clear();
                    Httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var values = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", username ),
                        new KeyValuePair<string, string> ( "Password", password )
                    };

                    FormUrlEncodedContent postBody = new FormUrlEncodedContent(values);
                    Task taskDownload = Httpclient.PostAsync((myserviceurl()), postBody)
                         .ContinueWith(task =>
                         {
                             if (task.Status == TaskStatus.RanToCompletion)
                             {
                                 var response = task.Result;

                                 if (response.IsSuccessStatusCode)
                                 {
                                     success = true;
                                     code = response.StatusCode;
                                     responseBody = response.Content.ReadAsStringAsync().Result;
                                     ApiToken = responseBody;
                                     TokenGrant token = JsonConvert.DeserializeObject<TokenGrant>
                                          (ApiToken.ToString());
                                     ApiToken = token.access_token;
                                     DataValues md = TokenDecode.GetInstance()
                                     .Decode(token);
                                     md.UserName = username;
                                     ApplicationsVariables.Username = username;
                                     ApplicationsVariables.Token = md.Token;
                                     ApplicationsVariables.Datavalues = md;
                                 }
                                 else
                                 {
                                     code = response.StatusCode;
                                     responseBody = response.Content.ReadAsStringAsync().Result;
                                 }
                             }
                         });
                    taskDownload.Wait();
                }
                if (success)
                    responseBody = "ok";
                return responseBody;
                //if (success)
                //    return "ok";
                //else if (responseBody.Contains("invalid_grant"))
                //    return responseBody;
                //else if (responseBody.Contains("no_confirmed"))
                //    return responseBody;
                throw new Exception();


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
