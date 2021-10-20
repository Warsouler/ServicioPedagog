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
    public static class SubjectsBuilder
    {
        public static SubjectsVM Fill(string oneobject)
        {
            return JsonConvert.DeserializeObject<SubjectsVM>(oneobject);
        }

        public static List<SubjectsVM> FillCollection(string list)
        {
            List<SubjectsVM> _list = JsonConvert.DeserializeObject<SubjectsList>(list).mylist;
            foreach (SubjectsVM vm in _list)
                vm.CreateOwnStates();
            return _list;
        }
    }
}
