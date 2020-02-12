using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver.Enumerations
{
    public enum StatesPaymentsEnum
    {
        #region Usadas
        pending = 1,
        approved = 2,
        rejected = 3,
        cancelled = 4,
        #endregion

        #region No usadas
        authorized = 5,
        in_process = 6,
        in_mediation = 7,
        refunded = 8,
        charged_back = 9
        #endregion
    }
}
