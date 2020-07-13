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
    public class CareersProxy : BaseProxy<CareersVM>,IProxy<CareersVM>
    {
        

        protected override CareersVM Fill(string oneobject)
        {
            throw new NotImplementedException();
        }

        protected override List<CareersVM> FillCollection(string list)
        {
            return CareersBuilder.FillCollection(list);
        }

        protected override string myspecificurl()
        {
            return "Careers";
        }

    }
}
