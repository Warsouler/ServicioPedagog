using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.ViewModels.List
{
    public class CareersList
    {
            public Int32 total { get; set; }
            public List<CareersVM> mylist;
            public CareersList(List<CareersVM> _mylist, Int32 _total)
            {
                mylist = _mylist;
                total = _total;
            }
        
    }
}
