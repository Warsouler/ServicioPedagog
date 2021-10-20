using DataModel.GenericRepository;
using DataModel.Interfaces;
using DataModel.Repositories;
//using DataModel.Infraestructure;
using Microsoft.AspNet.Identity.EntityFramework;
using Resolver.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace DataModel.UnitOfWork
{
    //
    public class UnitOfWork:IDisposable,IUnitOfWork
    {
        private ServicioContext context = null;

        #region Juan - 22
        ///23
        //private IPeatonUserRepository peatonuserRepository;
        //public IPeatonUserRepository PeatonuserRepository{get{if (peatonuserRepository == null)peatonuserRepository = new PeatonUserRepository(context);return peatonuserRepository;}set{peatonuserRepository = value;}}
        private ICyclesRepository cyclesRepository;
        public ICyclesRepository CyclesRepository { get { if (cyclesRepository == null) cyclesRepository = new CyclesRepository(context); return cyclesRepository; } set { cyclesRepository = value; } }
        private ICareersRepository careersRepository;
        public ICareersRepository CareersRepository { get { if (careersRepository == null) careersRepository = new CareersRepository(context); return careersRepository; } set { careersRepository = value; } }

        private ISubjectsRepository subjectsRepository;
        public ISubjectsRepository SubjectsRepository { get { if (subjectsRepository == null) subjectsRepository = new SubjectsRepository(context); return subjectsRepository; } set { subjectsRepository = value; } }














































































































































































        //284
        #endregion

        #region Develop1 = Leo - 287
        //288

        #region REGION AUXILIAR




































































































































































































































































































































































































        #endregion
        //1074
        #endregion









        //public GenericRepository<City> CityRepository
        //{
        //    get
        //    {
        //        if (cityRepository == null)
        //        {
        //            cityRepository = new GenericRepository<City>(context);
        //        }
        //        return cityRepository;
        //    }
        //    set
        //    {
        //        cityRepository = value;
        //    }
        //}
        //public GenericRepository<Book> BookRepository
        //{
        //    get
        //    {
        //        if (bookRepository == null)
        //        {
        //            bookRepository = new GenericRepository<Book>(context);
        //        }
        //        return bookRepository;
        //    }

        //    set
        //    {
        //        bookRepository = value;
        //    }
        //}
        //public IAuthorRepository AuthorRepository
        //{
        //    get
        //    {
        //        if (authorRepository == null)
        //        {
        //            authorRepository = new AuthorRepository(context);
        //        }
        //        return authorRepository;
        //    }

        //    set
        //    {
        //        authorRepository = value;
        //    }
        //}	

        public UnitOfWork()
        {
            context = new ServicioContext();
        }

        public ServicioContext GetNewContext()
        {
            return new ServicioContext();
        }

        public GenericRepository<T> getRepository<T>() where T:class 
        {
            return new GenericRepository<T>(context);
        }

        public void Commit()
        {

            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposed)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}