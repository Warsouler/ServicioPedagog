using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver.TypeDocuments
{
    public class PassportValidation : IDocumentValidation
    {
        public bool ValidateNumber(string number)
        {
            if (number == null)
                return false;

            return !(number.Trim().Length != 9 && number.Trim().Length != 10);
        }
    }
}
