using System.Linq;

namespace PromotionEngine
{
    public class PromotionChecker
    {//returns PromotionID and count of promotions
        public static decimal GetTotalPrice(Order ord, Promotion prom)
        {
            decimal d = 0M;
            //get count of promoted products in order
            var copp = ord.Products
                .GroupBy(x => x.Id)
                .Where(grp => prom.ProductInfo.Any(y => grp.Key == y.Key && grp.Count() >= y.Value))
                .Select(grp => grp.Count())
                .Sum();

            //get count of promoted products from promotion
            int ppc = prom.ProductInfo.Sum(kvp => kvp.Value);
            var key = prom.ProductInfo.Select(kvp => kvp.Key);
            string Prodkey = "";
            foreach (var i in key)
            {
                Prodkey = i.ToString();
                var originalPrice = from s in ord.Products.Where(x => x.Id == Prodkey)
                                    select s.Price;
                if (copp < ppc)
                {
                    var copp2 = ord.Products.Count(x => x.Id == Prodkey);
                    if (copp2 == 0)
                    {
                    }
                    else
                    {
                        d += (copp2 % ppc * originalPrice.First());
                    }
                }
            }

            while (copp >= ppc)
            {
                d += prom.PromoPrice;
                copp -= ppc;
            }
            if (copp < ppc)
            {
                var originalPrice = from s in ord.Products.Where(x => x.Id == Prodkey)
                                    select s.Price;
                d += (copp % ppc * originalPrice.FirstOrDefault());
            }

            return d;
        }
    }
}