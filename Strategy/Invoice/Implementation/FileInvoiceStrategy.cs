using System;
using System.IO;
using System.Diagnostics;
using Strategy.Invoice.Abstraction;
using Strategy.Invoice.Model;

namespace Strategy.Invoice.Implementation
{
    public class FileInvoiceStrategy: IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            string fullPath;
            using(var stream = new StreamWriter($"INVOICE_{Guid.NewGuid()}.txt"))
            {
                stream.Write(order.GenerateTextInvoice());
                fullPath = ((FileStream)(stream.BaseStream)).Name;
                stream.Flush();
            }

            Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
        }
    }
}