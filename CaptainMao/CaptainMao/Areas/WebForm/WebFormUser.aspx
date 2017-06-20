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

        #DataList1 {
            width:100%;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-6 row">
            <uc1:WebUserControl1 runat="server" ID="WebUserControl1" />
        </div>
        <div class="col-lg-6 row">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <Columns>
                    <asp:BoundField DataField="Merchandise_Name" HeaderText="商品名稱" SortExpression="Merchandise_Name"></asp:BoundField>
                    <asp:BoundField DataField="Merchandise_Price" HeaderText="商品價錢" SortExpression="Merchandise_Price"></asp:BoundField>
                    <asp:BoundField DataField="Expr1" HeaderText="購買數量" SortExpression="Expr1"></asp:BoundField>
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                <RowStyle ForeColor="#000066"></RowStyle>

                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:MaoWebformConnectionString %>' SelectCommand="SELECT ShoppingNetwork.Merchandise.Merchandise_Name, ShoppingNetwork.Merchandise.Merchandise_Price, ShoppingNetwork.Merchandise_Order_View.merchandise_Volume AS Expr1 FROM ShoppingNetwork.Merchandise_Order_View INNER JOIN ShoppingNetwork.Merchandise ON ShoppingNetwork.Merchandise_Order_View.Merchandise_ID = ShoppingNetwork.Merchandise.Merchandise_ID WHERE (ShoppingNetwork.Merchandise_Order_View.Order_ID = @Order_ID)">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="OrderID" Name="Order_ID"></asp:QueryStringParameter>
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>


</body>

<script src="../../Scripts/jquery-3.1.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
<script src="../buy/js/sweetalert.min.js"></script>
    <script>
        $(function () {
            $('.btn1').click(function (e) {
                
                var x = $(this).parents("tr").children().first().text()
                swal({
                    title: "您確定要取消此筆訂單?",
                    text: "您將取消此筆訂單",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "是的",
                    cancelButtonText:"取消",
                    closeOnConfirm: false
                },
                function () {
                    swal("刪除", "您已取消此筆訂單.", "success");
                    location.href = "/Areas/WebForm/WebUserCancel.aspx?OrderID=" + x;

                });
            })
        })
    </script>

</html>
