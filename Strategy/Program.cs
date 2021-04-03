using System;
using Strategy.Invoice.Logic;
using Strategy.Invoice.Abstraction;
using Strategy.Invoice.Implementation;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Input
            Console.WriteLine("Choose one of the following invoice delivery options.");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. File");
            Console.WriteLine("3. Screen");
            Console.WriteLine("Select invoice delivery options: ");
            var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());
            #endregion

            #region Output
            var invoiceLogic = new InvoiceLogic();
            var order = invoiceLogic.GetInvoice();
            invoiceLogic.InvoiceStrategy(GetInvoiceStrategyFor(invoiceOption));
            invoiceLogic.FinalizeOrder(order);
            #endregion
        }

        private static IInvoiceStrategy GetInvoiceStrategyFor(int option)
        {
            switch(option)
            {
                case 1: return new EMailInvoiceStrategy();
                case 2: return new FileInvoiceStrategy();
                case 3: return new PrintOnScreenInvoiceStrategy();
                default: throw new Exception("Unsupported invoice delivery option");
            }
        }
    }
}
