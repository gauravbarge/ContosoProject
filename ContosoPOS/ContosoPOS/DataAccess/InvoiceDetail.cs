//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContosoPOS.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class InvoiceDetail
    {
        public long InvoiceDetailID { get; set; }
        public Nullable<long> InvoiceID { get; set; }
        public Nullable<long> ProductID { get; set; }
        public Nullable<short> QuantityPurchased { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}