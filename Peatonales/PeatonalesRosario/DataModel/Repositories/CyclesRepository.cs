using DataModel.GenericRepository;
using DataModel.Interfaces;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repositories
{
    public class CyclesRepository : GenericRepository<Cycles>, ICyclesRepository
    {
        public CyclesRepository(ServicioContext context) : base(context)
        {
        }
    }
}
