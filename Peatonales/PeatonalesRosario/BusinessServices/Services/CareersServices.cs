using AutoMapper;
using BusinessEntities;
using BusinessServices.Interfaces;
using DataModel.Models;
using DataModel.UnitOfWork;
using Resolver.Enumerations;
using Resolver.Exceptions;
using Servicio.Resolver.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services
{
    public class CareersServices : ICareersServices
    {
        private readonly UnitOfWork _unitOfWork;

        public CareersServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public long Create(CareersBE Be)
        {

            try
            {
                if (_unitOfWork.CareersRepository.GetOneByFilters(t => t.name == Be.name, null) != null)
                    throw new ApiBusinessException(005, "Ya existe una carrera con ese nombre, por favor elija otro nombre.", System.Net.HttpStatusCode.BadRequest, "Http");

                Be.state = (Int32)StatesEnum.Valid;
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<CareersBE, Careers>();
                });
                Careers entity = Mapper.Map<CareersBE, Careers>(Be);
                _unitOfWork.CareersRepository.Insert(entity);
                _unitOfWork.Commit();
                return entity.idcareers;

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
                Careers entity = _unitOfWork.CareersRepository.GetById(Id);
                if(entity.state==1)
                entity.state = (Int32)StatesEnum.Annulled;
                _unitOfWork.CareersRepository.Delete(entity, new List<String>() { "state" });
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<CareersBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                Expression<Func<Careers, Boolean>> exp = t => (t.name.ToLower().Contains(name.ToLower()) || String.IsNullOrEmpty(name)) && (t.state == state || state == 0);
                IQueryable<Careers> entities = _unitOfWork.CareersRepository.GetAllByFilters(exp, null);
                count = entities.Count();
                var skipAmount = 0;
                if (page > 0)
                    skipAmount = pageSize * (page - 1);

                entities = entities
                    .OrderByPropertyOrField(orderBy, ascending)
                    .Skip(skipAmount)
                    .Take(pageSize);

                List<CareersBE> ColBe;
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<List<Careers>, List<CareersBE>>();
                    cfg.CreateMap<Careers, CareersBE>();

                });
                ColBe = Mapper.Map<IEnumerable<Careers>, IEnumerable<CareersBE>>(entities.ToList()).ToList();

                return ColBe;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public CareersBE GetById(long Id)
        {
            try
            {
                Expression<Func<Careers, Boolean>> predicate = u => u.idcareers == Id;
                Careers entity = _unitOfWork.CareersRepository.GetOneByFilters(predicate, null);

                if (entity == null)
                    throw new ApiBusinessException(006, "No existe la carrera.", System.Net.HttpStatusCode.NotFound, "Http");

                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Careers, CareersBE>();

                });
                CareersBE be = Mapper.Map<Careers, CareersBE>(entity);
                return be;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public bool Update(long Id, CareersBE Be)
        {
            try
            {
                if (Be == null)
                    throw new ApiBusinessException(007, "La entidad no está completa.", System.Net.HttpStatusCode.NotFound, "Http");

                Careers entity = _unitOfWork.CareersRepository.GetAllByFilters(t => t.name.ToLower() == Be.name.ToLower(), null).FirstOrDefault();
                if (entity != null && entity.idcareers != Id)
                    throw new ApiBusinessException(005, "Ya existe una carrera con ese nombre, por favor elija otro nombre.", System.Net.HttpStatusCode.BadRequest, "Http");

                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<CareersBE, Careers>();
                });
                Careers myentity = Mapper.Map<CareersBE, Careers>(Be);
                _unitOfWork.CareersRepository.Update(myentity, new List<String> { "name", "state" });
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
