using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface ISubjectsServices
    {
        SubjectsBE GetById(Int64 Id);
        List<SubjectsBE> GetAll(Int32 state, Int32 page, Int32 pageSize, String orderBy, String ascending, String name, ref Int32 count);
        Int64 Create(SubjectsBE Be);
        Boolean Update(Int64 Id, SubjectsBE Be);
        Boolean Delete(Int64 Id);
    }





}
