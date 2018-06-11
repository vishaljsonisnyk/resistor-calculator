using ResistorRating.Library.Contracts;
using ResistorRating.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResistorRating.Api.Controllers
{
    public class LookupController : ApiController
    {
        private ILookupService _lookupService;
        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }
        // GET: api/Lookup
        public IQueryable<ElectronicColorRing> Get()
        {
            return _lookupService.GetAllColorRingTypes();
        }
    }
}
