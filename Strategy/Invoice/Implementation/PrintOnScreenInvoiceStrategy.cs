using System;
using Strategy.Invoice.Abstraction;
using Strategy.Invoice.Model;

namespace Strategy.Invoice.Implementation
{
    public class PrintOnScreenInvoiceStrategy: IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            var content = order.GenerateTextInvoice();
            Console.WriteLine(content);
        }
    }
}