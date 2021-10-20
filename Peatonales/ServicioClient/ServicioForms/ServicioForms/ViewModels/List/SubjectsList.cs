using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.ViewModels.List
{
    public class SubjectsList
    {
            public Int32 total { get; set; }
            public List<SubjectsVM> mylist;
            public SubjectsList(List<SubjectsVM> _mylist, Int32 _total)
            {
                mylist = _mylist;
                total = _total;
            }
        
    }
}
