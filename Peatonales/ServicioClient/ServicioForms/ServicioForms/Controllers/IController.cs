using ServicioForms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioForms.Controllers
{
    public interface IController<VM> where VM: BaseVM
    {
        void Create(VM viewmodel);

        void Update(VM viewmodel);

        void Delete(VM viewmodel);

        List<VM> GetAll(string filters);

        VM GetOne(Int64 id);
    }
}
