using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiFileUpload.DesktopClient.MercadoModels;

namespace WebApiFileUpload.DesktopClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerPayment m = new ManagerPayment();
            m.Pay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagerPayment m = new ManagerPayment();
            string id = "25061445-2825ed40-e98d-4e1c-8893-36926d5e2cde";
            m.GetPayment(id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
          string timefrom=  DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day+"T12:00:00.000-04:00";
          string timeto = DateTime.Now.AddDays(3).Year + "-" + DateTime.Now.AddDays(3).Month + "-" + DateTime.Now.AddDays(3).Day + "T12:00:00.000-04:00";

            //2016 - 02 - 01T12: 00:00.000 - 04:00"
            Preference mypreference = new Preference()
            { auto_return = "approved",
                expiration_date_from = timefrom,
                expiration_date_to = timeto,
                expires = true,
                notification_url="Página de notificación",
                 external_reference="Referencia externa"
            };
            mypreference.items.Add(new MercadoModels.MercadoItem()
            {
                category_id = "categoria1",
                currency_id = "AR",
                description = "Mi descripción",
                id = "1",
                picture_url = "mifoto",
                quantity = 22,
                title = "Supertítulo",
                unit_price = 40
            });
            mypreference.items.Add(new MercadoModels.MercadoItem()
            {
                category_id = "categoria2",
                currency_id = "AR",
                description = "Mi descripción 2",
                id = "2",
                picture_url = "mifoto2",
                quantity = 255,
                title = "Supertítulo2",
                unit_price = 402
            });
            ClientAddress ca = new ClientAddress() {
                street_name = "Mendoza",
                street_number = 25,
                zip_code = "2000"
            };
            ClientIdentification ci = new ClientIdentification()
            {
                number = "34420023",
                type = "CUIT"
            };
            ClientPhone cp = new ClientPhone()
            {
                area_code = "0341",
                number = "156366643"
            };
            mypreference.payer = new MercadoPayer()
            {
                identification = ci,
                phone = cp,
                address = ca,
                date_created = DateTime.Now.ToString(),
                email = "clienteemail@ema.com",
                name = "Cliente1",
                surname = "ApelliedoCliente1"
            };
            mypreference.back_urls = new MercadoBackUrls()
            { failure = "!!$$##",
              pending = "Está pendiente",
              success = "Pagina de compra perfecta"
            };
            mypreference.payment_methods = new MercadoPaymentsMethods()
            {
                default_installments = null,
                default_payment_method_id = null,
                installments = 12,
                excluded_payment_methods = new List<MercadoExcludedPaymentsMethods>()
                  {
                       new MercadoExcludedPaymentsMethods() { id="amex" }
                  },
                excluded_payment_types = new List<MercadoExcludedPaymentTypes>()
                 {
                      new MercadoExcludedPaymentTypes() { payment_type_id="atm" }
                 }
            };
            string json = JsonConvert.SerializeObject(mypreference);
            ManagerPayment m = new ManagerPayment();
            m.Pay(json);
            string a = "4";
        }
    }
}
