using System;
using System.Collections.Generic;

namespace AtolOnline.v1
{
    class Sample
    {
        private void Exec()
        {
            Balancer kkt = new Balancer("127.0.0.0", 7777, 223344556600);

            var response = kkt.Sale(new Document()
            {
                CallbackUrl = "http://mysite.net/calback",
                Date = DateTime.Now,
                Email = "user@mail.com",
                Phone = "+79001234657",
                DiscountType = DiscountType.Fixed,
                Discount = 200,
                Payments = new List<Payment>() { new Payment() { Type = 1, Value = 5500 } },
                Items = new List<DocumentProduct>
                            {
                                new DocumentProduct() {
                                    Name = "Sony Erricsson 320",
                                    Price = 5000,
                                    DiscountType = DiscountType.Precent,
                                    Discount = 10,
                                    Quantity = 1,
                                    Barcode = "BR0002111",
                                    Classifier = "Сотовый телефон",
                                    VAT = 18
                                },
                                 new DocumentProduct() {
                                    Name = "Чехол Sony Erricsson",
                                    Price = 520,
                                    DiscountType = DiscountType.Fixed,
                                    Discount = 20,
                                    Quantity = 2,
                                    Barcode = "BR977862",
                                    Classifier = "Чехол",
                                    VAT = 18,
                                }
                            }
            });

            var id = response.Uuid;
        }
    }
}
