<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="FRONT_KSP.Views.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-12">
        <asp:GridView ID="gviProducts" runat="server" PageSize="5"
            DataKeyNames="CusId"
            >
            <Columns>
                <asp:BoundField DataField="CusId" Visible="false" />
                <asp:BoundField DataField="CusName" HeaderText="Nombre del cliente" />
                <asp:BoundField DataField="SelId" Visible="false" />
                <asp:BoundField DataField="SelName" HeaderText="Nombre del vendedor" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
