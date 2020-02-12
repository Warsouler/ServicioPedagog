#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace GO.Fwk.Toolkits.Mailing
{
    public interface IStateMail
    {
        String[] To();
        String Subject();
        String Body();
    }
}
