using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoPOS.DataAccess;

namespace ContosoPOS.ViewModel
{
    [Serializable]
    public class MakeSalesViewModel
    {
       public List<InvoiceDetail> ProductPurchased { get; set; }
       public  Invoice InvoiceData { get; set; }
       public  List<Product> AvailableProducts { get; private set; }
       private ContosoPOSEntities dbContext;

        public MakeSalesViewModel()
        {
            dbContext = new ContosoPOSEntities();
            AvailableProducts= dbContext.Products.ToList();
            ProductPurchased = new List<InvoiceDetail>();
            InvoiceData = new Invoice();
        }

        public void Save()
        {
            foreach(var o in ProductPurchased)
            dbContext.InvoiceDetails.Add(o);

            dbContext.Invoices.Add(InvoiceData);
            dbContext.SaveChanges();


        }
    }
}