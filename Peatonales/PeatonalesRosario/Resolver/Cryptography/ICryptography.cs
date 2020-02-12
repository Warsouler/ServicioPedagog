#region Usings

using System;

#endregion


namespace GO.Fwk.Toolkits.Cryptography
{
    public interface ICryptography
    {
        /// <summary>
        /// Metodo de encriptacion
        /// </summary>
        /// <param name="stringToCypher"></param>
        /// <returns></returns>
        String Encypt(String stringToCypher);

        /// <summary>
        /// Metodo de desencriptacion
        /// </summary>
        /// <param name="stringToDecipher"></param>
        /// <returns></returns>
        String Decrypt(String stringToDecipher);
    }
}
