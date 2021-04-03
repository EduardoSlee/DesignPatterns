using System.IO;
using Newtonsoft.Json;
using Strategy.Invoice.Abstraction;
using Strategy.Invoice.Model;

namespace Strategy.Invoice.Logic
{
    public class InvoiceLogic
    {
        private IInvoiceStrategy invoiceStrategy;
        public InvoiceLogic() { }

        public void InvoiceStrategy(IInvoiceStrategy _invoiceStrategy)
        {
            invoiceStrategy = _invoiceStrategy;
        }

        public Order GetInvoice()
        {
            string invoiceUrl = "Invoice/Api/Order.json";
            Order order = new Order();
            using (StreamReader sr = new StreamReader(invoiceUrl))
            {
                string json = sr.ReadToEnd();
                order =  JsonConvert.DeserializeObject<Order>(json);               
            }

            return order;
        }

        public void FinalizeOrder(Order order)
        {
            invoiceStrategy.Generate(order);
        }
    }
}