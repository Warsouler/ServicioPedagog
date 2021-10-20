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
    public class SubjectsServices : ISubjectsServices
    {
        private readonly UnitOfWork _unitOfWork;

        public SubjectsServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public long Create(SubjectsBE Be)
        {

            try
            {                   //Aca poner SubjectsRepository, hay que crearlo en unitofwork
                if (_unitOfWork.SubjectsRepository.GetOneByFilters(t => t.name == Be.name, null) != null)
                    throw new ApiBusinessException(005, "Ya existe una carrera con ese nombre, por favor elija otro nombre.", System.Net.HttpStatusCode.BadRequest, "Http");

                Be.state = (Int32)StatesEnum.Valid;
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<SubjectsBE, Subjects>();
                });
                Subjects entity = Mapper.Map<SubjectsBE, Subjects>(Be);
                _unitOfWork.SubjectsRepository.Insert(entity);//aca cambiar repository
                _unitOfWork.Commit();
                return entity.idsubject;

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
                Subjects entity = _unitOfWork.SubjectsRepository.GetById(Id);//cambiar repositorio
                if(entity.state==1)
                entity.state = (Int32)StatesEnum.Annulled;
                _unitOfWork.SubjectsRepository.Delete(entity, new List<String>() { "state" });//cambiar repositrory
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<SubjectsBE> GetAll(int state, int page, int pageSize, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                Expression<Func<Subjects, Boolean>> exp = t => (t.name.ToLower().Contains(name.ToLower()) || String.IsNullOrEmpty(name)) && (t.state == state || state == 0);
                IQueryable<Subjects> entities = _unitOfWork.SubjectsRepository.GetAllByFilters(exp, null);//cambiar repositorio
                count = entities.Count();
                var skipAmount = 0;
                if (page > 0)
                    skipAmount = pageSize * (page - 1);

                entities = entities
                    .OrderByPropertyOrField(orderBy, ascending)
                    .Skip(skipAmount)
                    .Take(pageSize);

                List<SubjectsBE> ColBe;
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<List<Subjects>, List<SubjectsBE>>();
                    cfg.CreateMap<Subjects, SubjectsBE>();

                });
                ColBe = Mapper.Map<IEnumerable<Subjects>, IEnumerable<SubjectsBE>>(entities.ToList()).ToList();

                return ColBe;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public SubjectsBE GetById(long Id)
        {
            try
            {
                Expression<Func<Subjects, Boolean>> predicate = u => u.idsubject == Id;
                Subjects entity = _unitOfWork.SubjectsRepository.GetOneByFilters(predicate, null);//cambiar repositorio

                if (entity == null)
                    throw new ApiBusinessException(006, "No existe la materia.", System.Net.HttpStatusCode.NotFound, "Http");

                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Subjects, SubjectsBE>();

                });
                SubjectsBE be = Mapper.Map<Subjects, SubjectsBE>(entity);
                return be;
            }


            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public bool Update(long Id, SubjectsBE Be)
        {
            try
            {
                if (Be == null)
                    throw new ApiBusinessException(007, "La entidad no está completa.", System.Net.HttpStatusCode.NotFound, "Http");

                Subjects entity = _unitOfWork.SubjectsRepository.GetAllByFilters(t => t.name.ToLower() == Be.name.ToLower(), null).FirstOrDefault();//cambiar repositorio
                if (entity != null && entity.idsubject != Id)
                    throw new ApiBusinessException(005, "Ya existe una materia con ese nombre, por favor elija otro nombre.", System.Net.HttpStatusCode.BadRequest, "Http");

                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SubjectsBE, Subjects>();
                });
                Subjects myentity = Mapper.Map<SubjectsBE, Subjects>(Be);
                _unitOfWork.SubjectsRepository.Update(myentity, new List<String> { "name", "state" });//cambiar repo
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
