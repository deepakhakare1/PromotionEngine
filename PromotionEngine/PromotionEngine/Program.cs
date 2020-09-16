using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionEngineRule
    {
        static void Main(string[] args)
        {
            var promotionPrice= GetPromotionEngineResult();
            Console.ReadLine();

        }

        public static decimal GetPromotionEngineResult()
        {
            //create list of promotions
            //we need to add information about Product's count
            decimal promoprice=0m;
            Dictionary<String, int> d1 = new Dictionary<String, int>();
            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);
            List<Promotion> promotions = new List<Promotion>()
                {
                    new Promotion(1, d1, 130),
                    new Promotion(2, d2, 45),
                    new Promotion(3, d3, 30)
                };
            //create orders
            List<Order> orders = new List<Order>();
            Order order1 = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            Order order2 = new Order(2, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B") });
            Order order3 = new Order(3, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("D") });
            Order order4 = new Order(4, new List<Product>() { new Product("A"), new Product("B"), new Product("C") });
            Order order5 = new Order(5, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("C") });
            Order order6 = new Order(6, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });

            orders.AddRange(new Order[] { order1, order2, order3, order4, order5, order6 });
            //check if order meets promotion
            foreach (Order ord in orders)
            {
                List<decimal> promoprices = promotions
                    .Select(promo => PromotionChecker.GetTotalPrice(ord, promo))
                    .ToList();
                decimal origprice = ord.Products.Sum(x => x.Price);
                promoprice = promoprices.Sum();

                Console.WriteLine($"OrderID: {ord.OrderID} => Original price: {origprice.ToString("0.00")} | Rebate Price: {(origprice - promoprice).ToString("0.00")} | Total Price: {(promoprice).ToString("0.00")}");
            }
            return promoprice;
        }
    }
}
