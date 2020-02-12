using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolver.Enumerations
{
    public static class ClaimConverter
    {
        public static Int32 Convert(string typeclaim)
        {
            switch (typeclaim)
            {
                case "Comprar combos":
                    return 1;
                case "Adquirir servicios destacados":
                    return 2;
                case "Gestionar servicios":
                    return 3;
                case "Gestionar servicios destacados":
                    return 4;
                case "Gestionar pantalla":
                    return 5;
                case "Gestionar regalos":
                    return 6;
                case "Gestionar canjes puntos":
                    return 7;
                case "Ingresar códigos":
                    return 8;
                case "Ver reportes/estadísticos":
                    return 9;
                case "Gestionar perfil":
                    return 10;
               
                default:
                    return 0;

                    throw new Exception();


            }

        }

        //public static string ConvertClaim(string typeclaim)
        //{
        //    switch (typeclaim)
        //    {
        //        //case "1":
        //        //    return "Comprar combos";
        //        //case "2":
        //        //    return "Adquirir servicios destacados";
        //        //case "3":
        //        //    return "Gestionar servicios";
        //        //case "4":
        //        //    return "Gestionar servicios destacados";
        //        //case "5":
        //        //    return "Gestionar pantalla";
        //        //case "6":
        //        //    return "Gestionar regalos";
        //        //case "7":
        //        //    return "Gestionar canjes puntos";
        //        //case "8":
        //        //    return "Ingresar códigos";
        //        //case "9":
        //        //    return "Ver reportes/estadísticos";
        //        //case "10":
        //        //    return "Gestionar perfil";


        //        //default:
        //        //    return "";

        //        //    throw new Exception();
        //        case "Comprar combos":
        //            return "1";
        //        case "Adquirir servicios destacados":
        //            return "2";
        //        case "Gestionar servicios":
        //            return "3";
        //        case "Gestionar servicios destacados":
        //            return "4";
        //        case "Gestionar pantalla":
        //            return "5";
        //        case "Gestionar regalos":
        //            return "6";
        //        case "Gestionar canjes puntos":
        //            return "7";
        //        case "Ingresar códigos":
        //            return "8";
        //        case "Ver reportes/estadísticos":
        //            return "9";
        //        case "Gestionar perfil":
        //            return "10";

        //        default:
        //            return "0";

        //            throw new Exception();


        //    }

        //}
    }
}
