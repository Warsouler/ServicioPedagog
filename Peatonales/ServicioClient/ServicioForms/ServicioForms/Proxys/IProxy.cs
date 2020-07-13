using ServicioForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Proxys
{
    public interface IProxy<VM> where VM:BaseVM
    {
        VM Get(Int64 id);
        Task<List<VM>> GetAll(string filters);
        void Create(VM model);
        void Update(VM model);
        void Delete(VM model);
    }
}
