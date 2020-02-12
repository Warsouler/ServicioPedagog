#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace Resolver.TypeDocuments
{
    public class CUITValidations : IDocumentValidation
    {
        public Boolean ValidateNumber(String number)
        {
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            number = number.Trim();
            number = number.Replace("-", String.Empty);

            if (number.Length != 11)
                return false;

            return ValidaCuit(number);
            //int calculado = ComputeCUITDigit(number);
            //int digito = Convert.ToInt32(number.ToCharArray()[10]);
            //return (calculado == digito);
        }

        /// <summary>
        /// Compute the last digit´s CUIL
        /// </summary>
        /// <param name="cuit"></param>
        /// <returns></returns>
        public int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
        }

        public bool ValidaCuit(string cuit)
        {
            if (cuit == null)
            {
                return false;
            }
            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;
            }
        }
    }
}
