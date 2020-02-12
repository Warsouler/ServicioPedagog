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
   public class CareersRepository : GenericRepository<Careers>, ICareersRepository
    {
        public CareersRepository(ServicioContext context) : base(context)
        {
        }
    }
}
