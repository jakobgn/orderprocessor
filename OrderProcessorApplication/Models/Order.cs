namespace OrderProcessorApplication.Models
{
    public class Order
    {
        public Product Product { get; set; }
        public string Email { get; set; }

        public static Order Create(Product product, string email = "")
        {
            return new Order()
            {
                Product = product,
                Email = email
            };
        }
    }
}