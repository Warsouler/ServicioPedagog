using Servicio.ErrorHelper;
using Resolver.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio.ActionFilters
{
    public static class ConverterToJsonException
    {
        public static JsonCustomException ConvertToReadableException(IApiExceptions ex)
        {
            return new ErrorHelper.JsonCustomException()
            {
                ErrorCode = ex.ErrorCode,
                ErrorDescription = ex.ErrorDescription,
                HttpStatus = ex.HttpStatus,
                ReasonPhrase = ex.ReasonPhrase,
                ReferenceLink = ex.ReferenceLink
            };

        }
    }
}