using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class SubjectsBE
    {

        private string pepe;
        public Int64 idsubject { get; set; }
        public String name { get; set; }
        public Int32 state { get; set; }
        public Int64 idcycle { get; set; }

        public string saraza { get => pepe; set => pepe = value; }
    }
}
