namespace Strategy.Invoice.Model
{
    public class OrderProduct
    {
        public OrderProduct() {}
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal SubTotal
        {
            get { return Price * Quantity; }
        }
    }
}