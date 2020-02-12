using Exceptions.Handlers;
using Newtonsoft.Json;
using ServicioForms.General;
using ServicioForms.Misc;
using ServicioForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Proxys
{
    public abstract class BaseProxy<VM> where VM : BaseVM
    {
        public BaseProxy()
        {
            url = new Uri(myserviceurl());
        }
        #region Variables
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
        #endregion

        #region OverridesMethods

        protected abstract string myspecificurl();

        protected abstract List<VM> FillCollection(string list);
        protected abstract VM Fill(string oneobject);
        #endregion

        #region Methods
        public virtual string myserviceurl()
        {
            return urlservice + "/api/" + myspecificurl();
        }

        public virtual VM Get(Int64 id)
        {
            using (Httpclient = new HttpClient())
            {

                Httpclient.BaseAddress = url;
                Httpclient.DefaultRequestHeaders.Clear();
                Httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
                if (!String.IsNullOrEmpty(ApplicationsVariables.Token))
                    Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationsVariables.Token);
                var response = Task.Run(() => Httpclient.GetAsync(new Uri(url + "/" + id))).Result;
               
                    if (response.IsSuccessStatusCode)
                        return this.Fill(response.Content.ReadAsStringAsync().Result);
                    else
                        JsonErrorHandler.HandleError(response);

                
                throw new Exception();
            }
        }

        public virtual async Task<List<VM>> GetAll(string filters)
        {
            using (Httpclient = new HttpClient())
            {
                Httpclient.BaseAddress = url;
                Httpclient.DefaultRequestHeaders.Clear();
                Httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
                if (!String.IsNullOrEmpty(ApplicationsVariables.Token))
                    Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationsVariables.Token);
                var response = Task.Run(() => Httpclient.GetAsync(new Uri(url + filters))).Result;
               
                    if (response.IsSuccessStatusCode)
                    {
                        // get the self link of the root resource
                        //var selfUri = response.Resource.Links["self"].First().Href;
                        //var findUri = response.Resource.Links["find"].First().Href;
                        //var next = response.Resource.Links.ContainsKey("next") ?
                        //    response.Resource.Links["next"].FirstOrDefault().Href : new Uri("Http://N/A");
                        //var prev = response.Resource.Links.ContainsKey("prev") ?
                        //    response.Resource.Links["prev"].FirstOrDefault().Href : new Uri("Http://N/A");
                        //var first = response.Resource.Links.ContainsKey("first") ?
                        //    response.Resource.Links["first"].FirstOrDefault().Href : new Uri("Http://N/A");
                        //var last = response.Resource.Links.ContainsKey("last") ?
                        //    response.Resource.Links["last"].FirstOrDefault().Href : new Uri("Http://N/A");
                        var listdto = FillCollection(response.Content.ReadAsStringAsync().Result);

                        return listdto;
                    }
                    else
                    {
                        JsonErrorHandler.HandleError(response);

                    }
                
                throw new Exception();
            }
        }




        public virtual void Create(VM model)
        {
            using (Httpclient = new HttpClient())
            {
                Httpclient.BaseAddress = url;
                Httpclient.DefaultRequestHeaders.Clear();
                Httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
                if (!String.IsNullOrEmpty(ApplicationsVariables.Token))
                    Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationsVariables.Token);
                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = Httpclient.PostAsync((url), new StringContent(postBody, Encoding.UTF8, "application/json"))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                                return;
                            else
                                JsonErrorHandler.HandleError(response);
                        }
                    });
                taskDownload.Wait();

            }

        }

        public virtual void Update(VM model)
        {
            using (Httpclient = new HttpClient())
            {
                Httpclient.BaseAddress = url;
                Httpclient.DefaultRequestHeaders.Clear();
                Httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
                if (!String.IsNullOrEmpty(ApplicationsVariables.Token))
                    Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationsVariables.Token);

                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = Httpclient.PutAsync((url + "/" + model.Id), new StringContent(postBody, Encoding.UTF8, "application/json"))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                                return;
                            else
                                JsonErrorHandler.HandleError(response);
                        }
                    });
                taskDownload.Wait();

            }

        }

        public virtual void Delete(VM model)
        {
            using (Httpclient = new HttpClient())
            {
                Httpclient.BaseAddress = url;
                Httpclient.DefaultRequestHeaders.Clear();
                Httpclient.DefaultRequestHeaders.Add("Accept", "application/json");
                if (!String.IsNullOrEmpty(ApplicationsVariables.Token))
                    Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApplicationsVariables.Token);
                string postBody = JsonConvert.SerializeObject(model);
                Task taskDownload = Httpclient.DeleteAsync((url + "/" + model.Id))
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.RanToCompletion)
                        {
                            var response = task.Result;

                            if (response.IsSuccessStatusCode)
                                return;
                            else
                                JsonErrorHandler.HandleError(response);
                        }
                    });
                taskDownload.Wait();

            }

        }
        #endregion




    }
}
