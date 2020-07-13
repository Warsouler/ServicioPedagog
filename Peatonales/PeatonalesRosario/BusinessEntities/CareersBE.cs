using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CareersBE
    {

        private string pepe;
        public Int64 idcareers { get; set; }
        public String name { get; set; }
        public Int32 state { get; set; }
        public string saraza { get => pepe; set => pepe = value; }
    }
}
