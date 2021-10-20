using Newtonsoft.Json;
using ServicioForms.Builders;
using ServicioForms.ViewModels;
using ServicioForms.ViewModels.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Proxys
{
    public class SubjectsProxy : BaseProxy<SubjectsVM>,IProxy<SubjectsVM>
    {
        

        protected override SubjectsVM Fill(string oneobject)
        {
            throw new NotImplementedException();
        }

        protected override List<SubjectsVM> FillCollection(string list)
        {
            return SubjectsBuilder.FillCollection(list);
        }

        protected override string myspecificurl()
        {
            return "Subjects";
        }

    }
}
