#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Resolver.TypeDocuments
{
    public interface IDocumentValidation
    {
        Boolean ValidateNumber(String number);
    }
}
