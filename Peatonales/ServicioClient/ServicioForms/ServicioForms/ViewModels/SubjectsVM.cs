using ServicioForms.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.ViewModels
{
    public class SubjectsVM:BaseVM
    {
        public Int64 idsubject { get; set; }
        
        public String name { get; set; }

        public Int32 state { get; set; }

        public Int64 idcycle { get; set; }


        public String statevalue { get; set; }

        public override long Id
        {
            get
            {
                return idsubject;
            }

            set
            {
                idsubject = value;
            }
        }
        public void CreateOwnStates()
        {
            statevalue = ((EnumStates)state).ToString();
        }
    }
}
