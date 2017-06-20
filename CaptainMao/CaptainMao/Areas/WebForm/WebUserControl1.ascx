<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="CaptainMao.Areas.WebForm.WebUserControl1" %>
<asp:GridView CssClass="table table-bordered table-hover" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
    <Columns>
        <asp:BoundField DataField="Order_ID" HeaderText="訂單編號" SortExpression="Order_ID" />
        <asp:BoundField DataField="DeliveryName" HeaderText="收件者" SortExpression="DeliveryName"></asp:BoundField>
        <asp:BoundField DataField="Order_Createdate" HeaderText="訂單建立日期" SortExpression="Order_Createdate" />
        <asp:BoundField DataField="BranchAddress" HeaderText="寄貨地址" SortExpression="BranchAddress" />
        <asp:TemplateField HeaderText="取消">
            <ItemTemplate>
                <asp:HyperLink runat="server" NavigateUrl='<%# "~/Areas/WebForm/WebFormUser.aspx?OrderID=" + Eval("Order_ID")%>' CssClass="btn btn-primary glyphicon glyphicon-search"></asp:HyperLink>
                <%--<asp:HyperLink runat="server" NavigateUrl='<%# "~/Areas/WebForm/WebUserCancel.aspx?OrderID="  + Eval("Order_ID")%>' CssClass="btn1 btn btn-primary glyphicon glyphicon-remove"></asp:HyperLink>--%>
                <asp:HyperLink runat="server" CssClass="btn1 btn btn-primary glyphicon glyphicon-remove"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
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
<asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString='<%$ ConnectionStrings:MaoWebformConnectionString %>'
            SelectCommand="SELECT ShoppingNetwork.[Order].Order_ID, ShoppingNetwork.[Order].Order_Fitness, ShoppingNetwork.[Order].user_ID, ShoppingNetwork.[Order].DeliveryName, ShoppingNetwork.[Order].Order_Createdate, ShoppingNetwork.FourStore.BranchAddress FROM ShoppingNetwork.[Order] INNER JOIN ShoppingNetwork.FourStore ON ShoppingNetwork.[Order].DeliveryLocation = ShoppingNetwork.FourStore.BranchID WHERE (ShoppingNetwork.[Order].user_ID = @user_ID) AND (ShoppingNetwork.[Order].Order_Fitness = 1)">
            <SelectParameters>
                <asp:SessionParameter Name="user_ID" SessionField="Identity" />
        </SelectParameters>
    </asp:SqlDataSource>
