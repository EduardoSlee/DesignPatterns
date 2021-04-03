using Strategy.Invoice.Model;

namespace Strategy.Invoice.Abstraction
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}