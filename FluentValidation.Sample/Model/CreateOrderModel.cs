namespace FluentValidation.Sample.Controllers
{
    public class CreateOrderModel
    {
       public int OrderId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductLabel { get; set; }
        public int ProductPrice { get; set; }
    }
}