using Newtonsoft.Json;
using ServicioForms.ViewModels;
using ServicioForms.ViewModels.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Builders
{
    public static class CareersBuilder
    {
        public static CareersVM Fill(string oneobject)
        {
            return JsonConvert.DeserializeObject<CareersVM>(oneobject);
        }

        public static List<CareersVM> FillCollection(string list)
        {
            List<CareersVM> _list = JsonConvert.DeserializeObject<CareersList>(list).mylist;
            foreach (CareersVM vm in _list)
                vm.CreateOwnStates();
            return _list;
        }
    }
}
