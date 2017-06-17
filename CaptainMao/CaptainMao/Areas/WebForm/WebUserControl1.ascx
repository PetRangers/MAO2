<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="CaptainMao.Areas.WebForm.WebUserControl1" %>

<asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
    <EditItemTemplate>
        Merchandise_Name:
        <asp:TextBox Text='<%# Bind("Merchandise_Name") %>' runat="server" ID="Merchandise_NameTextBox" /><br />
        Merchandise_Price:
        <asp:TextBox Text='<%# Bind("Merchandise_Price") %>' runat="server" ID="Merchandise_PriceTextBox" /><br />
        Order_ID:
        <asp:TextBox Text='<%# Bind("Order_ID") %>' runat="server" ID="Order_IDTextBox" /><br />
        merchandise_Volume:
        <asp:TextBox Text='<%# Bind("merchandise_Volume") %>' runat="server" ID="merchandise_VolumeTextBox" /><br />
        <asp:LinkButton runat="server" Text="更新" CommandName="Update" ID="UpdateButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="取消" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" />
    </EditItemTemplate>
    <InsertItemTemplate>
        Merchandise_Name:
        <asp:TextBox Text='<%# Bind("Merchandise_Name") %>' runat="server" ID="Merchandise_NameTextBox" /><br />
        Merchandise_Price:
        <asp:TextBox Text='<%# Bind("Merchandise_Price") %>' runat="server" ID="Merchandise_PriceTextBox" /><br />
        Order_ID:
        <asp:TextBox Text='<%# Bind("Order_ID") %>' runat="server" ID="Order_IDTextBox" /><br />
        merchandise_Volume:
        <asp:TextBox Text='<%# Bind("merchandise_Volume") %>' runat="server" ID="merchandise_VolumeTextBox" /><br />
        <asp:LinkButton runat="server" Text="插入" CommandName="Insert" ID="InsertButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="取消" CommandName="Cancel" ID="InsertCancelButton" CausesValidation="False" />
    </InsertItemTemplate>
    <ItemTemplate>
        Merchandise_Name:
        <asp:Label Text='<%# Bind("Merchandise_Name") %>' runat="server" ID="Merchandise_NameLabel" /><br />
        Merchandise_Price:
        <asp:Label Text='<%# Bind("Merchandise_Price") %>' runat="server" ID="Merchandise_PriceLabel" /><br />
        Order_ID:
        <asp:Label Text='<%# Bind("Order_ID") %>' runat="server" ID="Order_IDLabel" /><br />
        merchandise_Volume:
        <asp:Label Text='<%# Bind("merchandise_Volume") %>' runat="server" ID="merchandise_VolumeLabel" /><br />

    </ItemTemplate>
</asp:FormView>
<asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=192.168.33.36;Initial Catalog=Mao;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT ShoppingNetwork.Merchandise.Merchandise_Name, ShoppingNetwork.Merchandise.Merchandise_Price, ShoppingNetwork.Merchandise_Order_View.Order_ID, ShoppingNetwork.Merchandise_Order_View.merchandise_Volume FROM ShoppingNetwork.Merchandise INNER JOIN ShoppingNetwork.Merchandise_Order_View ON ShoppingNetwork.Merchandise.Merchandise_ID = ShoppingNetwork.Merchandise_Order_View.Merchandise_ID WHERE (ShoppingNetwork.Merchandise_Order_View.Order_ID = @Order_ID)">
    <SelectParameters>
        <asp:QueryStringParameter QueryStringField="orderID" DefaultValue="1" Name="Order_ID"></asp:QueryStringParameter>
    </SelectParameters>
</asp:SqlDataSource>
