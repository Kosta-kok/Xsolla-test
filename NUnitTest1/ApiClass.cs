using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NUnitTest1.Models;
using NUnitTest1.Properties;
using Newtonsoft.Json;

namespace NUnitTest1
{
    public class ApiClass
    {
        public static async Task<int> CreatePromotion()
        {
            try
            {
                NewPromotion promotion = TestHelper.BasePromotion();
                string json = JsonConvert.SerializeObject(promotion);
                var content = new System.Net.Http.StringContent(json, UnicodeEncoding.UTF8, "application/json");
                string urlparam = Resources.promotions;
                var Response = await TestHelper.Send(WebRequestType.Post, urlparam, content);
                var id = JsonConvert.DeserializeObject<Id>(Response);
                var PromotionId = id.id;
                if (PromotionId > 0)
                    return PromotionId;
                else
                    return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static async Task<string> DeletePromotion(int promotionId)
        {
            string urlparam = String.Format(Resources.promotion, promotionId);
            var Response = await TestHelper.Send(WebRequestType.Delete, urlparam);
            return Response;
        }

        public static async Task<string> TogglePromotion(int promotionId)
        {
            EmptyClass empty = new EmptyClass();
            string json = JsonConvert.SerializeObject(empty);
            return await SetConverter(String.Format(Resources.toogle, promotionId), json);
        }

        public static async Task<string> SetPeriods(int promotionId, NewPeriods periods)
        {
            string json = JsonConvert.SerializeObject(periods);
            return await SetConverter(String.Format(Resources.periods, promotionId), json);
        }

        public static async Task<string> SetRewards(int promotionId, NewRewards rewards)
        {
           
            string json = JsonConvert.SerializeObject(rewards);
            return await SetConverter(String.Format(Resources.rewards, promotionId), json);

        }

        public static async Task<string> SetSubject(int promotionId, NewSubject subject)
        {
            string json = JsonConvert.SerializeObject(subject);
            return await SetConverter(String.Format(Resources.subject, promotionId), json);
        }

        public static async Task<string> SetPaymentSystems(int promotionId, PaymentSystems paymentSystems)
        {
            string json = JsonConvert.SerializeObject(paymentSystems);
            return await SetConverter(String.Format(Resources.payment_systems, promotionId), json);
        }
        private static async Task<string> SetConverter(string urlparam, string json)
        {
            try
            {
                var content = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var Response = await TestHelper.Send(WebRequestType.Put, urlparam, content);
                return Response;
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public static async Task<List<PromotionResult>> GetPromotions()
        {
            try
            {
                var Response = await TestHelper.Send(WebRequestType.Get, Resources.promotions);
                var Res = JsonConvert.DeserializeObject <List<PromotionResult>>(Response);
                return Res;
            }
            catch (Exception)
            {
                return default(List<PromotionResult>);
            }
        }

        public static async Task<Promotion> GetPromotion(int promotionId)
        {
            return await GetConverter<Promotion>(String.Format(Resources.promotion, promotionId));
        }

        public static async Task<List<Review>> GetReviewPromotion(int promotionId)
        {
            return await GetConverter<List<Review>>(String.Format(Resources.review, promotionId));
        }

        public static async Task<Rewards> GetRewardsPromotion(int promotionId)
        {
            return await GetConverter<Rewards>(String.Format(Resources.rewards, promotionId));
        }

        public static async Task<Subject> GetSubjectPromotion(int promotionId)
        {
            return await GetConverter<Subject>(String.Format(Resources.subject, promotionId));
        }

        public static async Task<Periods> GetPeriodsPromotion(int promotionId)
        {
            return await GetConverter<Periods>(String.Format(Resources.periods, promotionId));
        }

        public static async Task<PaymentSystemsResult> GetPaymentSystem(int promotionId)
        {
            return await GetConverter<PaymentSystemsResult>(String.Format(Resources.payment_systems, promotionId));
        }

        private static async Task<T> GetConverter<T>(string urlparam)
        {
            try
            {
                var Response = await TestHelper.Send(WebRequestType.Get, urlparam);
                var Res = JsonConvert.DeserializeObject<T>(Response);
                return Res;
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
