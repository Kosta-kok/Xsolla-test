using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnitTest1.Properties;
using NUnitTest1.Models;



namespace NUnitTest1
{
    [TestFixture]
    public class TestFixture1
    {
        [Test]
        public async void testCreatePromotion()
        {
            Console.WriteLine("------testCreatePromotion");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                Promotion Response = await ApiClass.GetPromotion(id);
                NewPromotion etalon = TestHelper.BasePromotion();
                //etalon.name.en = "";
                NewPromotion actual = Response as NewPromotion;
                Assert.AreEqual(etalon, actual, Messages.msg_objects_not_equal);
                Console.WriteLine(Messages.msg_objects_equal);
                Console.WriteLine(Messages.msg_test_pass);
          
            } catch(Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [TestFixtureSetUp]
        public async void testDeletePromotions()
        {
            Console.WriteLine("------testDeletePromotions");
            try
            {
                List<PromotionResult> Response = await ApiClass.GetPromotions();
                Console.WriteLine(String.Concat(Messages.msg_count_promotions, Response.Count.ToString()));
                int count = Response.Count;
                if (count != 0)
                {
                    int k = 0;
                    int enabledCount = 0;
                    for (int i = 0; i< count; i++)
                    {
                        var promotion = Response[i];
                        int id = promotion.id;
                        //string Restoggle;
                        if (Response[i].enabled) //включенные выключим
                            enabledCount++;
                            //Restoggle= await ApiClass.TogglePromotion(id);//всё равно акция удалится
                        string ResDel = await ApiClass.DeletePromotion(id);//затем удалим
                        if (ResDel == "")
                            k++;
                    }
                    Console.WriteLine(String.Concat(Messages.msg_count_delete_promotions, k.ToString()));

                    Assert.True(k == (count - enabledCount), Messages.msg_object_delete);
                    //Console.WriteLine(Messages.msg_object_delete);
                }
                Console.WriteLine(Messages.msg_test_pass);

            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [Test]
        public async void testSetPeriods()
        {
            Console.WriteLine("------testSetPeriods");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                NewPeriods etalon = TestHelper.BasePeriods();
                string Response = await ApiClass.SetPeriods(id, etalon);
                if (Response != "")
                    Console.WriteLine(Response);
                Assert.IsNullOrEmpty(Response, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                Periods ResSub = await ApiClass.GetPeriodsPromotion(id);
                NewPeriods actual = ResSub as NewPeriods;
                Assert.AreEqual(etalon, actual, Messages.msg_objects_not_equal);
                Console.WriteLine(Messages.msg_objects_equal);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [Test]
        public async void testSetSubject()
        {
            Console.WriteLine("------testSetSubject");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                
                NewSubject etalon = TestHelper.BaseSubject();
                string ResSetSubject = await ApiClass.SetSubject(id, etalon);
                if (ResSetSubject != "")
                    Console.WriteLine(ResSetSubject);
                Assert.IsNullOrEmpty(ResSetSubject, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                //Subject ResGetSubject= await ApiClass.GetSubjectPromotion(id);

                etalon = TestHelper.BaseSubject2();
                ResSetSubject = await ApiClass.SetSubject(id, etalon);
                if (ResSetSubject != "")
                    Console.WriteLine(ResSetSubject);
                Assert.IsNullOrEmpty(ResSetSubject, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                //ResGetSubject = await ApiClass.GetSubjectPromotion(id);

                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }
        [Test]
        public async void testSetRewards()
        {
            Console.WriteLine("------testSetRewards");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                NewRewards etalon = TestHelper.BaseRewards();
                string ResSetRew = await ApiClass.SetRewards(id, etalon);
                if (ResSetRew != "")
                    Console.WriteLine(ResSetRew);
                Assert.IsNullOrEmpty(ResSetRew, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                Rewards resRew = await ApiClass.GetRewardsPromotion(id);
                NewRewards actual = resRew as NewRewards;
                Assert.AreEqual(etalon, actual, Messages.msg_objects_not_equal);
                Console.WriteLine(Messages.msg_objects_equal);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [Test]
        public async void testSetPaymentSystem()
        {
            Console.WriteLine("------testSetPaymentSystem");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                PaymentSystems etalon = TestHelper.BasePaymentSystem();
                string ResSetpay = await ApiClass.SetPaymentSystems(id, etalon);
                if (ResSetpay != "")
                    Console.WriteLine(ResSetpay);
                Assert.IsNullOrEmpty(ResSetpay, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                PaymentSystemsResult ResGetpay = await ApiClass.GetPaymentSystem(id);
                PaymentSystems actual = ResGetpay as PaymentSystems;  
                Assert.AreEqual(etalon, actual, Messages.msg_objects_not_equal);

                Console.WriteLine(Messages.msg_objects_equal);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [Test]
        public async void testTogglePromotionPositive()
        {
            //негативный тест, заранее знаем что переключаль не сработает из за не полных данных акции
            Console.WriteLine("------testTooglePromotionPositive");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);

                //зададим предмет акции
                NewSubject etalon = TestHelper.BaseSubject2();
                string ResSetSubject = await ApiClass.SetSubject(id, etalon);
                if (ResSetSubject != "")
                    Console.WriteLine(ResSetSubject);
                Assert.IsNullOrEmpty(ResSetSubject, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);


                //зададим период действия акции
                string ResSetPeriod = await ApiClass.SetPeriods(id, TestHelper.BasePeriods());
                if (ResSetPeriod != "")
                    Console.WriteLine(ResSetPeriod);
                Assert.IsNullOrEmpty(ResSetPeriod, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                //зададим вознаграждения
                NewRewards etalonReward = TestHelper.BaseRewards();
                string ResSetRew = await ApiClass.SetRewards(id, etalonReward);
                if (ResSetRew != "")
                    Console.WriteLine(ResSetRew);
                Assert.IsNullOrEmpty(ResSetRew, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                //проверим готовность акции к активации
                List<Review> ResReview = await ApiClass.GetReviewPromotion(id);
                Assert.False(ResReview.Count != 0, Messages.msg_promotion_valid);
         
                Promotion ResEtalon = await ApiClass.GetPromotion(id);
                bool etalonEnable = ResEtalon.enabled;

                string Response = await ApiClass.TogglePromotion(id);
                if (Response != "")
                    Console.WriteLine(Response);
                Assert.IsNullOrEmpty(Response, Messages.msg_not_toggle);
                Promotion ResActual = await ApiClass.GetPromotion(id);
                bool actualEnable = ResActual.enabled;
                Assert.False(etalonEnable == actualEnable, Messages.msg_promotion_not_enable);
                Console.WriteLine(Messages.msg_promotion_enable);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }
        [Test]
        public async void testDeletePromotion()
        {
            Console.WriteLine("------testDeletePromotion");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                string Response = await ApiClass.DeletePromotion(id);
                if (Response != "")
                    Console.WriteLine(Response);
                Assert.IsNullOrEmpty(Response, Messages.msg_object_not_delete);
                Console.WriteLine(Messages.msg_object_delete);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [Test]
        public async void testReviewPromotionNegative()
        {
            //негативный тест, заранее знаем что GetReviewPromotion вернёт список ошибок
            Console.WriteLine("------testReviewPromotionNegative");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                List<Review> Response = await ApiClass.GetReviewPromotion(id);
                Console.WriteLine(String.Concat(Messages.msg_count_conflicts, Response.Count.ToString()));
                Assert.True(Response.Count != 0, Messages.msg_promotion_valid);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

        [Test]
        public async void testTogglePromotionNegative()
        {
            //негативный тест, заранее знаем что переключаль не сработает из за не полных данных акции
            Console.WriteLine("------testTooglePromotionNegative");
            try
            {
                int id = await ApiClass.CreatePromotion();
                //id = -1;
                Assert.False(id == -1, Messages.msg_object_not_created);
                Console.WriteLine(Messages.msg_object_created);
                Promotion ResEtalon = await ApiClass.GetPromotion(id);
                bool etalon = ResEtalon.enabled;
                string Response = await ApiClass.TogglePromotion(id);
                if (Response != "")
                    Console.WriteLine(Response);
                Assert.IsNotNullOrEmpty(Response, Messages.msg_not_toggle);
                Console.WriteLine(Messages.msg_promotion_not_enable);
                Console.WriteLine(Messages.msg_test_pass);
            }
            catch (Exception e)
            {
                Console.WriteLine(Messages.msg_test_fail);
            }
        }

    }
}
