#region Usings

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Resolver.TypeDocuments
{
    public static class DocumentTypeFactory
    {
        private static Int32 DNI_TYPE = 96;
        private static Int32 CUIT_TYPE = 80;
        private static Int32 CUIL_TYPE = 86;
        private static Int32 CDI_TYPE = 87;
        public static IDocumentValidation GetInstance(Int64 type)
        {
            if (DNI_TYPE == type)
                return new DNIValidations();

            if (type == CUIT_TYPE)
                return new CUITValidations();

            if (type == CUIL_TYPE)
                return new CUITValidations();

            if (CDI_TYPE == type)
                return new CUITValidations();

            throw new NullReferenceException();
        }
    }
}
