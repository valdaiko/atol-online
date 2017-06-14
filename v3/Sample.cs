using System;
using System.Collections.Generic;

// documentation on Telegram https://t.me/atolonline
namespace AtolOnline.v3
{
    public class Sample
    {
        public void Exec()
        {
            Balancer kkt = new Balancer("https://online.atol.ru/possystem",  "my-group", "my-login", "my-password", "path-for-log-file");

            var response = kkt.Sell(new Document()
            {
                ExternalId = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Service = new ServiceDocument()
                {
                    CallbackUrl = "http://mysite.net/callback",
                    Inn = "112233445573",
                    PaymentAddress = "г. Москва, ул. Оранжевая, д.22 к.11"
                },
                Receipt = new ReceiptDocument()
                {
                    Attributes = new Attribute()
                    {
                        Email = "user@mail.com",
                        Phone = "9001234657",
                        Sno = eSnoType.osn,
                    },
                    Items = new List<DocumentProduct>
                            {
                                new DocumentProduct() {
                                    Name = "Sony Erricsson 320",
                                    Price = 5000,
                                    Quantity = 1,
                                    Tax = eTaxType.vat18
                                },
                                 new DocumentProduct() {
                                    Name = "Чехол Sony Erricsson",
                                    Price = 200,
                                    Quantity = 2,
                                    Tax = eTaxType.vat18
                                }
                            },
                    Payments = new List<Payment>() {
                        new Payment() {
                            PaymentType = ePaymentType.Prepaid,
                            Sum = 5400
                        }
                    }
                }
            });

            var id = response.Uuid;
        }
    }
}
