using BusinessEntities;
using BusinessServices.Interfaces;
using Servicio.ActionFilters;
using Servicio.Helpers;
using Servicio.Models.Generals;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Servicio.Controllers
{
    [GlobalException]
    public class CyclesController : ApiController
    {
        private ICyclesServices _services;
        public CyclesController(ICyclesServices services)
        {
            _services = services;
        }

        #region Get 0ne
        /// <summary>
        /// Get the challenge with given ID.
        /// </summary>
        /// <param name="id">Filter by Id</param>
        /// <returns>Single Cycle entity</returns>
        [Authorize]
        [ResponseType(typeof(CyclesBE))]
        public async Task<IHttpActionResult> Get(int id)
        {
            CyclesBE Be = _services.GetById(id);
            if (Be == null)
            {
                return NotFound();
            }
            return Ok(Be);
        }
        #endregion

        #region Get All
        /// <summary>
        /// Get every challenge in the context
        /// [Roles: Admin, Empresas, Usuarios]
        /// </summary>
        /// <param name="state">Filter by state: 1 Saved, 2 published</param>
        /// <param name="page">Page filter(if it has more than 1 page)</param>
        /// <param name="top">Max amount of entities to be obtained</param>
        /// <param name="orderby">Order by this property</param>
        /// <param name="ascending">Order asc(ascending) or desc(descending)</param>
        /// <param name="name">Name to be filter</param>

        /// <returns>List of challenges
        /// FinalType: 1) Sujeto a stock, 2) Cantidad de dias.
        /// </returns>
        //[Authorize(Roles = "Admin, Empresas, Usuarios")]
        //[ClaimsAuthorizationAttribute(ClaimType = "Gestionar servicios")]
        [Authorize]
        [ResponseType(typeof(PaginationList<CyclesBE>))]
        //[PlayableAuthorizationFilter]
        public async Task<IHttpActionResult> GetCycles(Int32 state=0, Int32 page = 1,
        Int32 top = 5, String orderby = nameof(CyclesBE.idcycle), String ascending = "asc", String name="")
        {
            var count = 0;
            List<CyclesBE> query = _services.GetAll(state, page, top, orderby, ascending, name, ref count);
            //HybridDictionary myfilters = new HybridDictionary();
            //if (state != 0)
            //    myfilters.Add("state", state);
            //if (idprincipal != 0) myfilters.Add("idbusiness", idprincipal);
            //ChallengeDTOCollectionRepresentation dt = new ChallengeDTOCollectionRepresentation(dtos.ToList(),
            //FilterHelper.GenerateFilter(myfilters, top, orderby, ascending), page, count, top);
            PaginationList<CyclesBE> mylist = new PaginationList<CyclesBE>(query,count);
            return Ok(mylist);

        }
        #endregion

        #region CRUD
        /// <summary>
        /// Insert given challenge in the context
        /// [Roles: Empresas, Admin]
        /// </summary>
        /// <param name="challenge">The challenge to be inserted</param>
        /// <returns>Created link</returns>
        [Authorize]
        //[ClaimsAuthorizationAttribute(ClaimType = "Gestionar servicios")]
        public async Task<IHttpActionResult> PostCycles(CyclesBE Be)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _services.Create(Be);
            return Created(new Uri(Url.Link("DefaultApi", new { Id = Be.idcycle })), Be);
        }

        /// <summary>
        /// Update given challenge
        /// [Roles: Empresas, Admin]
        /// </summary>
        /// <param name="id">Filter by Id</param>
        /// <param name="challenge">The challenge to be inserted</param>
        /// <returns>Json OK</returns>
        [Authorize]
        public async Task<IHttpActionResult> PutChallenge(int id, CyclesBE Be)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _services.Update(id, Be);
            return Ok();
        }

        /// <summary>
        /// Delete given challenge  
        /// [Roles: Admin, Empresas]
        /// </summary>
        /// <param name="id">The primary key of the challenge</param>
        /// <returns>Json OK</returns>
        [Authorize]
        public async Task<IHttpActionResult> DeleteChallenge(Int32 id)
        {
            _services.Delete(id);
            return Ok();
        }
        #endregion
    }
}
