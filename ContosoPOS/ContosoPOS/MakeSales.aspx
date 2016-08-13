<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MakeSales.aspx.cs" Inherits="ContosoPOS.MakeSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
   
            <asp:GridView ID="rptProducts" runat="server"  Width="100%"  ViewStateMode="Enabled">
                <Columns>
       <%--             <asp:BoundField DataField="ProductName" />
                    <asp:BoundField DataField="UnitSellingPrice" />
                    <asp:BoundField DataField="Quantity" />
                    <asp:BoundField DataField="TotalPrice" />--%>
                </Columns>
               
            </asp:GridView>
          
            <%--  <asp:Repeater ID="rptProducts" runat="server" OnItemDataBound="Products_ItemDataBound">
            <HeaderTemplate>
                <tr>
                    <td>Product</td>
                    <td>Unit Selling price</td>
                    <td>Quantity Purchased</td>
                    <td>Total Price</td>
                </tr>

            </HeaderTemplate>
            <ItemTemplate>
         
                    <tr>
                        <td>
                            <asp:DropDownList ID="ProductList" runat="server"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="UnitSellingPrice" runat="server"></asp:Label>
                        </td>

                        <td>
                            <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="TotalPrice" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                        </td>
                    </tr>

              
            </ItemTemplate>

        </asp:Repeater>--%>
   </div>
    <div>   
           <table>
            <tr>
                <td>Product</td>
                <td>Unit Selling price</td>
                <td>Quantity Purchased</td>
                <td>Total Price</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ProductList" runat="server" OnSelectedIndexChanged="btn_DrpSelectIndex"></asp:DropDownList>
                    
                </td>
                <td>
                    <asp:Label ID="UnitSellingPrice" runat="server"></asp:Label>
                </td>

                <td>
                    <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="TotalPrice" runat="server"></asp:Label>
                </td>
<%--                <td>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" />
                </td>--%>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Add Product" OnClick="btnAdd_Click" />
                </td>
            </tr>
        </table>

    </div>
    <div>
        <table>
            <tr>

                <td>Amount before tax :</td>
                <td>
                    <asp:Label ID="lblBeforeAmounttax" runat="server"></asp:Label>

                </td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Tax percentage :</td>
                <td>
                    <asp:TextBox ID="txtTaxPercentage" runat="server" Text="4"></asp:TextBox>
                </td>
                <td>Tax amount :</td>
                <td>
                    <asp:Label ID="lblTaxAmount" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>

                <td>Discount percentage :</td>
                <td>
                    <asp:TextBox ID="txtDiscountPercentage" runat="server" Text="0"></asp:TextBox>
                </td>
                <td>Discount amount :</td>
                <td>
                    <asp:Label ID="lblDiscount" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Final Invoice Amount :</td>
                <td>
                    <asp:Label ID="lblFinalInvoiceAmount" runat="server"></asp:Label>

                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /></td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
                <td>
                    <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" />
                </td>
            </tr>

        </table>

    </div>
</asp:Content>
