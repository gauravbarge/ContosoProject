using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoPOS.ViewModel;

namespace ContosoPOS
{
    public partial class MakeSales : System.Web.UI.Page
    {

        public class showgrid
        {
           public string ProductName { get; set; }
           public decimal UnitSellingPrice { get; set; }
            public short Quantity { get; set; }
            public   decimal TotalPrice { get; set; }


        }
        public MakeSalesViewModel CurrentSales
        {
            get
            {
                if ((Session["MakesSales"] is MakeSalesViewModel) == false)
                {
                    Session["MakesSales"] = new MakeSalesViewModel();
                }
                return Session["MakesSales"] as MakeSalesViewModel;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Showgrid();
                rptProducts.DataBind();

                ProductList.DataSource = CurrentSales.AvailableProducts;
                ProductList.DataTextField = "Name";
                ProductList.DataValueField = "ProductID";
                ProductList.DataBind();

                var productID = (from o in CurrentSales.AvailableProducts
                                 where o.ProductID.ToString() == ProductList.SelectedItem.Value
                                 select o).FirstOrDefault();
                UnitSellingPrice.Text = productID.SellingPrice.Value.ToString();
                short iQuanity = 0;
                Quantity.Text = "0";
                TotalPrice.Text = (productID.SellingPrice * iQuanity).ToString();
            }

        }

        private void Showgrid()
        {
           var obj  = (from o in CurrentSales.ProductPurchased
                                      select new showgrid
                                      {
                                          ProductName = (from j in CurrentSales.AvailableProducts
                                                         where j.ProductID == o.ProductID
                                                         select j.Name).FirstOrDefault(),
                                          UnitSellingPrice = (from j in CurrentSales.AvailableProducts
                                                              where j.ProductID == o.ProductID
                                                              select j.SellingPrice).FirstOrDefault().Value,
                                          Quantity = o.QuantityPurchased.Value,

                                          TotalPrice = (from j in CurrentSales.AvailableProducts
                                                        where j.ProductID == o.ProductID
                                                        select j.SellingPrice * o.QuantityPurchased).FirstOrDefault().Value

                                      }).ToList();
            if (obj.Count() > 0)
            {
                rptProducts.DataSource = obj;
                rptProducts.DataBind();

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            short iQuantity;
            short.TryParse(Quantity.Text, out iQuantity);
            if (iQuantity > 0)
            {
                var productID = (from o in CurrentSales.AvailableProducts
                                 where o.ProductID.ToString() == ProductList.SelectedItem.Value
                                 select o.ProductID).FirstOrDefault();
                long lProductID = Convert.ToInt64(productID);

                var purchasedProduct = CurrentSales.ProductPurchased.Where(o => o.ProductID == lProductID);
                if (purchasedProduct.Count() > 0)
                {
                    var first = purchasedProduct.FirstOrDefault();
                    first.QuantityPurchased =Convert.ToInt16( first.QuantityPurchased.Value + iQuantity);
                }
                else
                {
                    CurrentSales.ProductPurchased.Add(new DataAccess.InvoiceDetail() { ProductID = lProductID, QuantityPurchased = iQuantity });
                }
                Showgrid();
            }
            //txtDiscountPercentage.Text = "0";
            //txtTaxPercentage.Text = "4";
            //lblBeforeAmounttax.Text = string.Empty;
            //lblDiscount.Text = string.Empty;
            //lblFinalInvoiceAmount.Text = string.Empty;
            //lblTaxAmount.Text = string.Empty;
        }

        //protected void Products_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    //var invoice =  (DataAccess.InvoiceDetail) e.Item.DataItem ;
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        var data = ((DataAccess.InvoiceDetail)e.Item.DataItem);
        //        if (data.ProductID == null)
        //        {
        //            var drplist = ((DropDownList)e.Item.FindControl("ProductList"));

        //            drplist.DataSource = CurrentSales.AvailableProducts;
        //            drplist.DataTextField = "Name";
        //            drplist.DataValueField = "ProductID";
        //            drplist.DataBind();

        //            var txtbox = ((Label)e.Item.FindControl("UnitSellingPrice"));
        //            txtbox.Text = "0";

        //            var textbox = ((TextBox)e.Item.FindControl("Quantity"));
        //            textbox.Text = data.QuantityPurchased.ToString();

        //        }
        //        if (data.ProductID != null)
        //        {
        //            var drplist = ((DropDownList)e.Item.FindControl("ProductList"));

        //            drplist.DataSource = CurrentSales.AvailableProducts;
        //            drplist.Text = (from o in CurrentSales.AvailableProducts
        //                            where o.ProductID == data.ProductID
        //                            select o.Name).ToString();
        //            drplist.DataTextField = "Name";
        //            drplist.DataValueField = "ProductID";
        //            drplist.DataBind();


        //            var label = ((Label)e.Item.FindControl("UnitSellingPrice"));
        //            label.Text = (from o in CurrentSales.AvailableProducts
        //                           where o.ProductID == data.ProductID
        //                           select o.SellingPrice).ToString();

        //            var textbox = ((TextBox)e.Item.FindControl("Quantity"));
        //            textbox.Text = data.QuantityPurchased.ToString();

        //            var Label1 = (( Label)e.Item.FindControl("TotalPrice"));
        //            Label1.Text = (from o in CurrentSales.AvailableProducts
        //                           where o.ProductID == data.ProductID
        //                           select o.SellingPrice * data.QuantityPurchased).ToString();
        //        }

        //    }
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CurrentSales.ProductPurchased = new List<DataAccess.InvoiceDetail>();
            Showgrid();
            txtDiscountPercentage.Text = "0";
            txtTaxPercentage.Text = "4";
            lblBeforeAmounttax.Text = string.Empty;
            lblDiscount.Text = string.Empty;
            lblFinalInvoiceAmount.Text = string.Empty;
            lblTaxAmount.Text = string.Empty;

        }

        protected void btn_DrpSelectIndex(object sender, EventArgs e)
        {
            var productID = (from o in CurrentSales.AvailableProducts
                             where o.ProductID.ToString() == ProductList.SelectedItem.Value
                             select o).FirstOrDefault();
            UnitSellingPrice.Text = productID.SellingPrice.Value.ToString();
            short iQuanity = Convert.ToInt16(Quantity.Text);
            TotalPrice.Text = (productID.SellingPrice * iQuanity).ToString();
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}