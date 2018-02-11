using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitTest1.Models;
using System.Reflection;

namespace NUnitTest1
{
    public class BaseObject
    {
        public override bool Equals(object obj)
        {
            if (obj.GetType().Name != this.GetType().Name)
                if (obj.GetType().BaseType.Name != this.GetType().Name)
                    return false;
            return EqualObj(this, obj);
        }

        public override Int32 GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool EqualObj(object source, object target)
        {
            var result = true;
            foreach (var field in source.GetType().GetFields())
            {
                var valSource = field.GetValue(source);
                var valTarget = field.GetValue(target);
                if (valSource == null && valTarget == null)
                    continue;
                else if ((valSource == null && valTarget != null) || (valSource != null && valTarget == null))
                    return false;
                if (valSource is List<Discount>) //Иначе стандартный Equal не сравниает 2 List<Discount>
                {
                    List<Discount> valSourceDiscount = valSource as List<Discount>;
                    List<Discount> valTargetDiscount = valTarget as List<Discount>;
                    if (valSourceDiscount.SequenceEqual(valTargetDiscount, new DiscountComparer()))
                        continue;
                }
                if (valSource is List<Bonus>)
                {
                    List<Bonus> valSourceBonus = valSource as List<Bonus>;
                    List<Bonus> valTargetBonus = valTarget as List<Bonus>;
                    if (valSourceBonus.SequenceEqual(valTargetBonus, new BonusComparer()))
                        continue;
                }
                if (valSource is List<Period>)
                {
                    List<Period> valSourcePeriod = valSource as List<Period>;
                    List<Period> valTargetPeriod = valTarget as List<Period>;
                    if (valSourcePeriod.SequenceEqual(valTargetPeriod, new PeriodComparer()))
                        continue;
                }
                if (valSource is List<PaymentSystem>)
                {
                    List<PaymentSystem> valSourcePay = valSource as List<PaymentSystem>;
                    List<PaymentSystem> valTargetPay = valTarget as List<PaymentSystem>;
                    if (valSourcePay.SequenceEqual(valTargetPay, new PaymentSystemComparer()))
                        continue;
                }
                if (!valSource.Equals(valTarget))
                    return false;
            }
            return result;
        }
    }

    class DiscountComparer : IEqualityComparer<Discount>
    {
        public bool Equals(Discount x, Discount y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.discount_percent == y.discount_percent && x.max_amount == y.max_amount && String.Compare(x.sku, y.sku, true) == 0;
        }

        public int GetHashCode(Discount discount)
        {
            if (Object.ReferenceEquals(discount, null)) return 0;
            int hashmax_amount = discount.max_amount == null ? 0 : discount.max_amount.GetHashCode();
            int hashdiscount_percent = discount.discount_percent.GetHashCode();
            int hashsku = discount.sku.GetHashCode();
            return hashmax_amount ^ hashdiscount_percent ^ hashsku;
        }
    }

    class BonusComparer : IEqualityComparer<Bonus>
    {
        public bool Equals(Bonus x, Bonus y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            return x.quantity == y.quantity && String.Compare(x.sku, y.sku, true) == 0;
        }

        public int GetHashCode(Bonus bonus)
        {
            if (Object.ReferenceEquals(bonus, null)) return 0;
            int hashquantity = bonus.quantity.GetHashCode();
            int hashsku = bonus.sku.GetHashCode();
            return hashquantity ^ hashsku;
        }
    }

    class PeriodComparer : IEqualityComparer<Period>
    {
        public bool Equals(Period x, Period y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            //offset автоматически заполняется на сервере в зависимости от to, from
            return String.Compare(x.to, y.to, true) == 0 && String.Compare(x.from, y.from, true) == 0 /*&& String.Compare(x.offset, y.offset, true) == 0*/;
        }

        public int GetHashCode(Period period)
        {
            if (Object.ReferenceEquals(period, null)) return 0;
            int hashfrom = period.from.GetHashCode();
            int hashto = period.to.GetHashCode();
            //int hashoffset = period.offset.GetHashCode();
            return hashfrom ^ hashto;// ^ hashoffset;
        }

    }
    class PaymentSystemComparer : IEqualityComparer<PaymentSystem>
    {
        public bool Equals(PaymentSystem x, PaymentSystem y)
        {
            if (Object.ReferenceEquals(x, y)) return true;
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
            //offset автоматически заполняется на сервере в зависимости от to, from
            return x.id == y.id;
        }

        public int GetHashCode(PaymentSystem pay)
        {
            if (Object.ReferenceEquals(pay, null)) return 0;
            int hashid = pay.id.GetHashCode();
            return hashid;
        }

    }
}
