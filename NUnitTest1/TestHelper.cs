using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnitTest1.Models;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.IO;

namespace NUnitTest1
{
    public enum WebRequestType
    {
        Delete,
        Get,
        Post,
        Put
    }
    public class TestHelper
    {
        public static async Task<string> Send(WebRequestType webType, string urlparams, HttpContent content = null)
        {
            string requestresult = string.Empty;
            try
            {
                string url = string.Format(Properties.Resources.url, Properties.Resources.merchant_id, urlparams);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (HttpClient hc = new HttpClient())
                {
                    UTF8Encoding encoding = new UTF8Encoding();
                    var bytes = encoding.GetBytes(
                        String.Concat(Properties.Resources.merchant_id,
                        ":",
                        Properties.Resources.api_key));
                    var auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(bytes));
                    hc.DefaultRequestHeaders.Authorization = auth;
                    hc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = null;
                    switch (webType)
                    {
                        case WebRequestType.Delete: response = hc.DeleteAsync(url).Result; break;
                        case WebRequestType.Get: response = hc.GetAsync(url).Result; break;
                        case WebRequestType.Post: response = hc.PostAsync(url, content).Result; break;
                        case WebRequestType.Put: response = hc.PutAsync(url, content).Result; break;
                    }

                    Task<Stream> streamTask = response.Content.ReadAsStreamAsync();
                    using (Stream stream = streamTask.Result)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            await stream.CopyToAsync((Stream)memoryStream);
                            byte[] data = memoryStream.ToArray();
                            requestresult = Encoding.UTF8.GetString(data, 0, data.Length);
                        }
                    }
                    return requestresult;
                }
            }
            catch (Exception)
            {
                requestresult = "[{IsError: true}]";
                return requestresult;
            }
        }

       

        public static NewPeriods BasePeriods()
        {
            var periods = new NewPeriods();
            periods.periods.Add(new Period 
            {
                from = "2019-01-20T00:00:00+05:00",
                to = "2019-02-20T00:00:00+05:00"
            });
            periods.periods.Add(new Period
            {
                from = "2018-03-05T00:00:00+05:00",
                to = "2018-09-05T00:00:00+05:00"
            });
            return periods;
        }
        public static NewPromotion BasePromotion()
        {
            return new NewPromotion
            {
                project_id = Int32.Parse(Properties.Resources.project_id),
                technical_name = "Sample Promotion 1",
                description = new LocalStrings { en = "30% PayPal Discount test" },
                label = new LocalStrings { en = "30% SAVE test" },
                name = new LocalStrings { en = "30% PayPal Discount test" }
            };
        }
        public static NewRewards BaseRewards()
        {
            return new NewRewards
            {
                purchase = new Purchase
                {
                    discount_percent = 10
                },
                package = new Package
                {
                    bonus_percent = 5,
                    bonus_amount = 5
                },
                item = BaseItem(),
                subscription = new Subscription
                {
                    trial_days = 30
                }
            };
        }

        public static NewSubject BaseSubject()
        {
            NewSubject subject = new NewSubject();
            subject.purchase = false;
            subject.items.Add(new Sku
            {
                sku = "t-43-3-unique-id"
            });
            //float pack = float.Parse(Properties.Resources.packages);
            //subject.packages.Add(pack);
            //subject.digital_contents.Add( BaseDigitalContents());////в документации нет описания объекта Drm и самого digital_contents.
            return subject;
        }

        public static NewSubject BaseSubject2()
        {
            NewSubject subject = new NewSubject();
            subject.purchase = false;
            /*subject.items.Add(new Sku
            {
                sku = "t-43-3-unique-id"
            });*/
            float pack = float.Parse(Properties.Resources.packages);
            subject.packages.Add(pack);
            //subject.digital_contents.Add( BaseDigitalContents());////в документации нет описания объекта Drm и самого digital_contents.
            return subject;
        }
        public static PaymentSystems BasePaymentSystem()
        {
            var paySystems = new PaymentSystems();
            paySystems.payment_systems.Add(new PaymentSystem
            {
                id = int.Parse(Properties.Resources.payment_systems_id)
            });
            return paySystems;
        }
        private static DigitalContents BaseDigitalContents()
        {
            var dig = new DigitalContents();
            dig.id = 1;
            dig.localized_name = "test12";
            //третим должно идти поле со значением 0 или 1
            dig.drm.Add(new Drm
            {
                id = 1,
                name = "Steam"
            });
            dig.drm.Add(new Drm
            {
                id = 2,
                name = "Playstation"
            });
            return dig;
        }
        private static Subscriptions BaseSubscriptions()
        {
            var sub = new Subscriptions();
            sub.plans.Add(new Id { id = 123456 });
            sub.products.Add(654321);
            sub.max_charges_count = null;
            return sub;
        }
        private static Item BaseItem()
        {
            var item = new Item();
            item.discount.Add(new Discount
            {
                sku = "t-43-3-unique-id",
                max_amount = 10,
                discount_percent = 5
            });
            item.bonus.Add(new Bonus
            {
                sku = "t-43-3-unique-id",
                quantity = 2
            });
            return item;
        }


    }
}
