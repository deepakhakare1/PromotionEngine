namespace PromotionEngine
{
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public Product(string id)
        {
            this.Id = id;
            switch (id)
            {
                case "A":
                    this.Price = 50;

                    break;
                case "B":
                    this.Price = 30;

                    break;
                case "C":
                    this.Price = 20;

                    break;
                case "D":
                    this.Price = 15;
                    break;
            }
        }

    }
}