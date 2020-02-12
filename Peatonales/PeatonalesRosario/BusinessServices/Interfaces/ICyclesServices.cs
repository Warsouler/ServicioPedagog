using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface ICyclesServices
    {
        CyclesBE GetById(Int64 Id);
        List<CyclesBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending,String name, ref Int32 count);
        Int64 Create(CyclesBE Be);
        Boolean Update(Int64 Id, CyclesBE Be);
        Boolean Delete(Int64 Id);
    }
}
