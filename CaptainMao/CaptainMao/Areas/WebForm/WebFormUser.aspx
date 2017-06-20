<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormUser.aspx.cs" Inherits="CaptainMao.Areas.WebForm.WebFormUser1" %>

<%@ Register Src="~/Areas/WebForm/WebUserControl1.ascx" TagPrefix="uc1" TagName="WebUserControl1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../buy/css/sweetalert.css" rel="stylesheet" />
    <style>
        body {
            background-color: transparent;
        }

        .panel {
            margin-left: 10px;
            background-color: aliceblue;
            box-shadow: 0 10px 30px rgb(0, 0, 0);
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-4">
            <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        </div>
        <div class="col-lg-8">
        </div>
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White"></AlternatingItemStyle>

            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <ItemStyle BackColor="#E3EAEB"></ItemStyle>
            <ItemTemplate>
                商品名稱:
                <asp:Label Text='<%# Eval("Merchandise_Name") %>' runat="server" ID="Merchandise_NameLabel" /><br />
                商品數量:
                <asp:Label Text='<%# Eval("merchandise_Volume") %>' runat="server" ID="merchandise_VolumeLabel" /><br />
                單品價錢:
                <asp:Label Text='<%# Eval("Merchandise_Price","{0:C0}") %>' runat="server" ID="Merchandise_PriceLabel" /><br />
                <br />
            </ItemTemplate>
            <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedItemStyle>
        </asp:DataList>
        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:MaoWebformConnectionString %>' SelectCommand="SELECT ShoppingNetwork.Merchandise_Order_View.merchandise_Volume, ShoppingNetwork.Merchandise.Merchandise_Name, ShoppingNetwork.Merchandise.Merchandise_Price FROM ShoppingNetwork.Merchandise_Order_View INNER JOIN ShoppingNetwork.Merchandise ON ShoppingNetwork.Merchandise_Order_View.Merchandise_ID = ShoppingNetwork.Merchandise.Merchandise_ID WHERE (ShoppingNetwork.Merchandise_Order_View.Order_ID = @Order_ID)">
            <SelectParameters>
                <asp:QueryStringParameter QueryStringField="OrderID" DefaultValue="" Name="Order_ID"></asp:QueryStringParameter>

            </SelectParameters>
        </asp:SqlDataSource>
    </form>
    <button id="btn1"></button>

</body>

<script src="../../Scripts/jquery-3.1.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../buy/js/sweetalert.min.js"></script>
    <script>
        //$(function () {
        //    $('#btn1').click(function () {
        //        sweetAlert('ok');
        //    })
        //})
    </script>

</html>
