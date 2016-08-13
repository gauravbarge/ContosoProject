<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ContosoPOS.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contoso POS contact person</h3>
    <address>
        Some place<br />
        Some other place<br />
        <abbr title="Phone">P:</abbr>
        000.000.00000
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@contoso.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@contoso.com</a>
    </address>
</asp:Content>
