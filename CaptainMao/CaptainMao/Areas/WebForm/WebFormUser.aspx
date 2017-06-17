

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color:transparent;
        }
        .panel {
            margin-left:10px;
            background-color:aliceblue;
            box-shadow:0 10px 30px rgb(0, 0, 0);
        }
    </style>
</head>
<body>
    <div class="col-lg-3">
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" DataSourceID="SqlDataSource1" DataKeyField="Order_ID">
                <ItemTemplate>
                    <div class="panel panel-primary">
                     <div class="panel-heading">訂單編號: <asp:Label Text='<%# Eval("Order_ID") %>' runat="server" ID="Order_IDLabel" /></div>
                        <div class="panel-body">
                            訂單狀態: <asp:Label Text='<%# Eval("Order_Fitness") %>' runat="server" ID="Order_FitnessLabel" /><br />
                            訂單建立日:<asp:Label Text='<%# Eval("Order_Createdate") %>' runat="server" ID="Order_CreatedateLabel" /><br />
                            收件者:<asp:Label Text='<%# Eval("DeliveryName") %>' runat="server" ID="DeliveryNameLabel" /><br />
                            寄送位子:<asp:Label Text='<%# Eval("BranchAddress") %>' runat="server" ID="BranchAddressLabel" /><br />
                         </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1"
                ConnectionString="Data Source=192.168.33.36;Initial Catalog=Mao;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient"
                SelectCommand="SELECT ShoppingNetwork.[Order].Order_ID, ShoppingNetwork.[Order].Order_Fitness, ShoppingNetwork.[Order].user_ID, ShoppingNetwork.[Order].Order_Createdate, ShoppingNetwork.[Order].DeliveryName, ShoppingNetwork.FourStore.BranchAddress FROM ShoppingNetwork.[Order] INNER JOIN ShoppingNetwork.FourStore ON ShoppingNetwork.[Order].DeliveryLocation = ShoppingNetwork.FourStore.BranchID WHERE (ShoppingNetwork.[Order].user_ID = @user_ID)">
                <SelectParameters>
                    <asp:SessionParameter SessionField="Identity" DefaultValue="" Name="user_ID"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    <div class="col-lg-9">

    </div>
</body>
<script src="../../Scripts/jquery-3.1.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
</html>
