using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace BusinessServices
{
    public class OwinSecurityServer:IOwinSecurityService
    {
        private readonly UnitOfWork _unitOfWork;

        public OwinSecurityServer(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ServicioContext Create()
        {
            return _unitOfWork.GetNewContext();
        }

        
    }
}
