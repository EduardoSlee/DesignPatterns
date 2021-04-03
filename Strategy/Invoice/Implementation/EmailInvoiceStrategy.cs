using System.Net.Mail;
using System.Net;
using Strategy.Invoice.Abstraction;
using Strategy.Invoice.Model;

namespace Strategy.Invoice.Implementation
{
    public class EMailInvoiceStrategy: IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            var body = order.GenerateTextInvoice();
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("5454989230268d", "a4793499d6d8ee"),
                EnableSsl = true
            };

            client.Send("from@inbox.mailtrap.io", "to@inbox.mailtrap.io", "INVOICE", body);
        }
    }
}