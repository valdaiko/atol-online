using System;
using System.Collections.Generic;

namespace AtolOnline.v2
{
    public class Sample
    {
        public void Exec()
        {
            Balancer kkt = new Balancer("127.0.0.1", 7777, "my-group");

            var response = kkt.Sell(new Document()
            {
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
                        Phone = "90001234567",
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
                            PaymentType = ePaymentType.type1,
                            Sum = 5400
                        }
                    }
                }
            });

            var id = response.Uuid;
        }
    }
}
