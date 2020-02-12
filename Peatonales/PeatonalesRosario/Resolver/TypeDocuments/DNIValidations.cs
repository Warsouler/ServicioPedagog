#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Resolver.TypeDocuments
{
    public class DNIValidations : IDocumentValidation
    {
        public Boolean ValidateNumber(String number)
        {
            if (number == null)
                return false;

            return !(number.Trim().Length != 7 && number.Trim().Length != 8);
        }
    }
}
