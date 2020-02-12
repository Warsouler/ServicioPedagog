using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApiFileUpload.DesktopClient.MercadoModels.Erros
{
    public class BadRequest : BaseMercadoError
    {
        private static List<ErrorApiResponse> errorApis;

        public List<ErrorApiResponse> ErrorApis
        {
            get
            {
                if (errorApis == null)
                    errorApis = ChargeErrorApi();
                return errorApis;
            }

            set
            {
                errorApis = value;
            }
        }

        public override string Canhandle(Hashtable htable)
        {
            if (htable["status"].ToString().Equals(Status()))
            {
                Hashtable response= ((Hashtable)htable["response"]);
                return ErrorApis.FirstOrDefault(t => t.Error == response["error"].ToString()
                && t.ApiMessage== response["message"].ToString())
                    .Message;
            }
            return String.Empty;
        }

        public override string Message()
        {
            throw new NotImplementedException();
        }

        public override string Status()
        {
            return "400";
        }

        private List<ErrorApiResponse> ChargeErrorApi()
        {
            errorApis = new List<ErrorApiResponse>();
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_id",
                InternalCode = 1,
                ApiMessage = "collector_id must be a number",
                Message = "El id del coleccionista debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_id",
                InternalCode = 2,
                ApiMessage = "collector_id invalid",
                Message = "El id del coleccionista es inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 3,
                ApiMessage = "sponsor_id not found",
                Message = "El id del sponsor no se encuentra",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 4,
                ApiMessage = "sponsor_id must be a number",
                Message = "El id del sponsor debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 5,
                ApiMessage = "sponsor_id should be different than collector_id",
                Message = "El id del sponsor debe ser diferente al id del coleccionista",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 6,
                ApiMessage = "sponsor_id site must be the same as collector_id",
                Message = "El id del sitio del sponsor debe ser el mismo al id del coleccionista",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 7,
                ApiMessage = "sponsor_id didn't accept MercadoPago's Terms and Conditions",
                Message = "El id del sponsor no aceptó los terminos y condiciones",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_sponsor_id",
                InternalCode = 8,
                ApiMessage = "sponsor_id is not an active user",
                Message = "El id del sponsor no es un usuario activo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_email",
                InternalCode = 9,
                ApiMessage = "collector is not collector_email(secure) owner",
                Message = "El coleccionista no tiene un email seguro de propietario",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_collector_email",
                InternalCode = 10,
                ApiMessage = "collector is not collector_email owner",
                Message = "El coleccionista no tiene un email de propietario",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_operation_type",
                InternalCode = 11,
                ApiMessage = "operation_type invalid",
                Message = "Tipo de operación inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_expiration_date_to",
                InternalCode = 12,
                ApiMessage = "expiration_date_to invalid",
                Message = "Fecha de expiración hasta inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_expiration_date_from",
                InternalCode = 13,
                ApiMessage = "invalid_expiration_date_from",
                Message = "Fecha de expiración desde inválida",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 15,
                ApiMessage = "amount cannot be paid with MercadoPago",
                Message = "Esa cantidad no puede ser pagada con MercadoPago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 16,
                ApiMessage = "items needed",
                Message = "Debe cargar items",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 17,
                ApiMessage = "items invalid. Wrong format",
                Message = "Items inválidos, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 18,
                ApiMessage = "currency_id needed",
                Message = "Se requiere el Id de la moneda",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 19,
                ApiMessage = "currency_id invalid",
                Message = "El Id de la moneda es inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 20,
                ApiMessage = "quantity needed",
                Message = "No ha ingresado la cantidad",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 21,
                ApiMessage = "quantity must be a number",
                Message = "La cantidad debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 22,
                ApiMessage = "quantity must be a number",
                Message = "La cantidad debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 23,
                ApiMessage = "unit_price needed",
                Message = "Ingrese el precio unitario",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 24,
                ApiMessage = "unit_price must be a number",
                Message = "El precio unitario debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 25,
                ApiMessage = "unit_price invalid",
                Message = "Precio unitario inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_items",
                InternalCode = 26,
                ApiMessage = "unit_price invalid",
                Message = "Precio unitario inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 27,
                ApiMessage = "payer invalid. Wrong format",
                Message = "Comprador inválido, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 28,
                ApiMessage = "payer name invalid. Max length 100",
                Message = "Nombre del comprador inválido, longitud máxima de 100",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 29,
                ApiMessage = "payer surname invalid. Max length 100",
                Message = "Apellido del comprador inválido, longitud máxima de 100",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payer",
                InternalCode = 30,
                ApiMessage = "payer email invalid. Max length 150",
                Message = "Email del comprador inválido, longitud máxima de 150",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_back_urls",
                InternalCode = 30,
                ApiMessage = "back_urls invalid. Wrong format",
                Message = "Urls de vuelta inválidas, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "payment_methods invalid. Wrong format",
                Message = "Métodos de pago inválidos, formao incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "the combination of payment methods and payment types cannot exclude all payment methods",
                Message = "La combinación de métodos de pago y tipos de pagos no pueden excluir todos los metodos de pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "amount cannot be paid with MercadoPago",
                Message = "Esa cantidad no puede ser pagada por MercadoPago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "excluded_payment_methods invalid. Wrong format",
                Message = "Metodos de pago excluídos inválidos, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "id needed",
                Message = "Se requiere el id",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "account_money cannot be excluded",
                Message = "account_money no puede ser excluída",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "cannot exclude all payments methods",
                Message = "No se puede excluir todos los métodos de pago",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "excluded_payment_types invalid. Wrong format",
                Message = "Tipos de pagos excluídos inválidos, formato incorrecto",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "cannot exclude all payments types",
                Message = "No puede excluir todos los tipos de pagos",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "client_id invalid",
                Message = "Id del cliente inválido",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_payment_methods",
                InternalCode = 30,
                ApiMessage = "client_id must be a number",
                Message = "El id del cliente debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_installments",
                InternalCode = 30,
                ApiMessage = "installments invalid. Should be only 1, 3, 6, 9, 12, 15, 18, 21 or 24",
                Message = "Cuotas inválidas. Debe ser solo 1, 3, 6, 9, 12, 15, 18, 21 o 24",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_installments",
                InternalCode = 30,
                ApiMessage = "installments must be a number",
                Message = "Cuotas debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_marketplace_fee",
                InternalCode = 30,
                ApiMessage = "marketplace_fee must be a number",
                Message = "La cuota del mercado debe ser un número",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_marketplace_fee",
                InternalCode = 30,
                ApiMessage = "marketplace_fee must be a positive number",
                Message = "La cuota del mercado debe ser un número positivo",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_marketplace_fee",
                InternalCode = 30,
                ApiMessage = "marketplace_fee must not be greater than total amount",
                Message = "La cuota del mercado no debe ser un mayor al total",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_id",
                InternalCode = 30,
                ApiMessage = "preference_id not found",
                Message = "El id de la preferencia no se encontró",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_access_token",
                InternalCode = 30,
                ApiMessage = "access denied",
                Message = "Acceso denegado",
                Status = "400"
            });
            errorApis.Add(new ErrorApiResponse()
            {
                Error = "invalid_shipments",
                InternalCode = 30,
                ApiMessage = "access denied",
                Message = "Acceso denegado",
                Status = "400"
            });
            //Shipments not found





            return errorApis;
        }
    }
}
