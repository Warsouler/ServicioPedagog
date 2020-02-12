using ServicioForms.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.ViewModels
{
    public class CareersVM:BaseVM
    {
        public Int64 idcareers { get; set; }
        public String name { get; set; }
        public Int32 state { get; set; }
        public String statevalue { get; set; }

        public override long Id
        {
            get
            {
                return idcareers;
            }

            set
            {
                idcareers = value;
            }
        }
        public void CreateOwnStates()
        {
            statevalue = ((EnumStates)state).ToString();
        }
    }
}
