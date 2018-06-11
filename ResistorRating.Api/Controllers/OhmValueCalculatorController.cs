using ResistorRating.Library.Contracts;
using ResistorRating.Library.Exceptions;
using ResistorRating.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ResistorRating.Api.Controllers
{
    public class OhmValueCalculatorController : ApiController
    {
        private IOhmValueCalculator _ohmValueCalculatorService;

        public OhmValueCalculatorController(IOhmValueCalculator ohmValueCalculator)
        {
            _ohmValueCalculatorService = ohmValueCalculator;
        }

        [HttpGet]
        [Route("api/{OhmValueCalculator}/{bandACode}/{bandDCode}/{bandBCode?}/{bandCCode?}")]
        [ActionName("GetOhmValueWithTolerance")]
        [ResponseType(typeof(CalculatedOhmForResistor))]
        public CalculatedOhmForResistor Get(string bandACode, string bandDCode, string bandBCode = "", string bandCCode = "")
        {
            CalculatedOhmForResistor returnValue;
            try
            {
                returnValue = _ohmValueCalculatorService.CalculateOhmValue(bandACode, bandDCode, bandBCode, bandCCode);
            }
            catch (BandNotFoundException ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent(ex.ExceptionMessage),
                    ReasonPhrase = "Color band not found."
                };
                throw new HttpResponseException(resp);
            }
            catch (WrongColorBandSelectedException ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NoContent)
                {
                    Content = new StringContent(ex.ExceptionMessage),
                    ReasonPhrase = "Wrong Color band selected. We can't rate the resistor."
                };
                throw new HttpResponseException(resp);
            }
            return returnValue;
        }
    }
}
