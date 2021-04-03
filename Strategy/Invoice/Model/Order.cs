using System;
using System.Collections.Generic;
using System.Linq;

namespace Strategy.Invoice.Model
{
    public class Order
    {
        public Order() {}
        public string Number { get; set; }
        public string Date { get; set; }
        public string Customer { get; set; }
        public decimal Total
        {
            get { return Products.Sum(p => p.SubTotal); }
        }
        public List<OrderProduct> Products { get; set; }

        public string GenerateTextInvoice()
        {
            string invoice = string.Empty;
            invoice += $"INVOICE NUMBER: {this.Number}{Environment.NewLine}";
            invoice += $"INVOICE DATE: {this.Date}{Environment.NewLine}";
            invoice += $"INVOICE CUSTOMER: {this.Customer}{Environment.NewLine}";
            invoice += Environment.NewLine;
            
            invoice += $"CODE|NAME|PRICE|QUANTITY|SUBTOTAL{Environment.NewLine}";
            foreach(var product in this.Products)
                invoice += $"{product.Code}|{product.Name}|{product.Price}|{product.Quantity}|{product.SubTotal}{Environment.NewLine}";

            invoice += Environment.NewLine;

            invoice += $"INVOICE TOTAL: {this.Total}{Environment.NewLine}";

            return invoice;
        }
    }
}