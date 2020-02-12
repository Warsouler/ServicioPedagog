using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver.Enumerations
{
    public enum StatesReservationsEnum
    {
        Reserved = 1,
        PreReserved = 2,
        Annulled = 3,
        Available = 4,
        ReserverByMe = 5,
        Consumed = 6
    }
}
