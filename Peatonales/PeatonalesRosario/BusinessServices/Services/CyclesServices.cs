using BusinessServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using Resolver.Exceptions;
using AutoMapper;
using DataModel.Models;
using System.Linq.Expressions;
using Resolver.Enumerations;
using Servicio.Resolver.QueryableExtensions;

namespace BusinessServices.Services
{
    public class CyclesServices : ICyclesServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CyclesServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public long Create(CyclesBE Be)
        {
            
            try
            {
                if (_unitOfWork.CyclesRepository.GetOneByFilters(t => t.name == Be.name, null) != null)
                    throw new ApiBusinessException(005, "Ya existe un ciclo con ese nombre, por favor elija otro nombre", System.Net.HttpStatusCode.BadRequest, "Http");

                Mapper.Initialize(cfg => {
                    cfg.CreateMap<CyclesBE, Cycles>();
                });
                Cycles entity = Mapper.Map<CyclesBE, Cycles>(Be);
                _unitOfWork.CyclesRepository.Insert(entity);
                _unitOfWork.Commit();
                return entity.idcycle;

            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public bool Delete(long Id)
        {
            try
            {
                Cycles entity = _unitOfWork.CyclesRepository.GetById(Id);
                entity.state = (Int32)StatesEnum.Annulled;
                _unitOfWork.CyclesRepository.Delete(entity, new List<String>() {"state"});
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<CyclesBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                Expression<Func<Cycles, Boolean>> exp = t => (t.name.ToLower().Contains(name.ToLower()) || String.IsNullOrEmpty(name)) && (t.state==state || state==0);
                IQueryable<Cycles> entities = _unitOfWork.CyclesRepository.GetAllByFilters(exp, null);
                count = entities.Count();
                var skipAmount = 0;
                if (page > 0)
                    skipAmount = pageSize * (page - 1);

                entities = entities
                    .OrderByPropertyOrField(orderBy, ascending)
                    .Skip(skipAmount)
                    .Take(pageSize);

                List<CyclesBE> ColBe;
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<List<Cycles>, List<CyclesBE>>();
                    cfg.CreateMap<Cycles, CyclesBE>();

                });
                ColBe = Mapper.Map<IEnumerable<Cycles>, IEnumerable<CyclesBE>>(entities.ToList()).ToList();

                return ColBe;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public CyclesBE GetById(long Id)
        {
            try
            {
                Expression<Func<Cycles, Boolean>> predicate = u => u.idcycle == Id;
                Cycles entity = _unitOfWork.CyclesRepository.GetOneByFilters(predicate, null);

                if (entity == null)
                    throw new ApiBusinessException(006, "No existe el ciclo", System.Net.HttpStatusCode.NotFound, "Http");

                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Cycles, CyclesBE>();
                    
                });
                CyclesBE be = Mapper.Map<Cycles, CyclesBE>(entity);
                return be;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public bool Update(long Id, CyclesBE Be)
        {
            try
            {
                if (Be == null)
                    throw new ApiBusinessException(007, "La entidad no está completa", System.Net.HttpStatusCode.NotFound, "Http");

                Cycles entity = _unitOfWork.CyclesRepository.GetAllByFilters(t => t.name.ToLower() == Be.name.ToLower(),null).FirstOrDefault();
                if(entity!=null && entity.idcycle!=Id)
                    throw new ApiBusinessException(005, "Ya existe un ciclo con ese nombre, por favor elija otro nombre", System.Net.HttpStatusCode.BadRequest, "Http");


                Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CyclesBE, Cycles>();
                    });
                    Cycles myentity = Mapper.Map<CyclesBE, Cycles>(Be);
                    _unitOfWork.CyclesRepository.Update(myentity, new List<String> { "name", "state" });
                _unitOfWork.Commit();
                return true;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        
    }
}
