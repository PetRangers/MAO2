<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CaptainMao.Views.CaptainMao.WebForm1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Import Namespace="CaptainMao.Areas.WebForm" %> 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-image: url("../../images/backimg.jpg");
            background-color:rgba(19, 255, 255, 0.40);
        }
        img {
            width:100%;
            
        }

        .thumbnail {
            background-color:rgb(242, 242, 169);
        }

        .drawingpin {
            background-color:rgb(242, 242, 169);
            margin-top: 20px;
            border-radius: 0px 20px 20px 20px;
            background-image: url('../../images/drawingpin.png');
            background-repeat: no-repeat;
            background-position: top left;
            background-size: 40px;
            box-shadow: -2px 5px 10px;
            padding: 30px;
}
    </style>

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="The description of my page" />
</head>
<body>
    <div class="row" style="margin-left:20px;">
        <div class="col-md-3">            
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" DataKeyField="AdoptionID">
                <ItemTemplate>
                    <div class="drawingpin">
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/Areas/WebForm/ImageReader.ashx?SearchID="+Eval("AdoptionID")%>' />
                        <h2><%# Eval("Name") %></h2>
                        <h4>性別: <%# Eval("Sex") %></h4>
                        <h4>體型: <%# Eval("Build") %></h4>
                        <h4>最後更新: <%# Eval("PostDate") %></h4>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString="Data Source=192.168.33.36;Initial Catalog=Mao;Persist Security Info=True;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Top 5 * FROM [Adoption] ORDER BY [PostDate] DESC"></asp:SqlDataSource>
        </div>
        <div class="col-md-3">
            <asp:DataList ID="DataList2" runat="server" DataKeyField="Merchandise_ID" DataSourceID="SqlDataSource2">
                <ItemTemplate>
                    <div class="drawingpin">
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%#"~/Areas/WebForm/MerchandisePhoto.ashx?SearchID="+Eval("Merchandise_ID")%>' />
                        <h2>產品名稱: <%# Eval("Merchandise_Name") %></h2>
                        <h4>產品價格: <%# Eval("Merchandise_Price","{0:c0}") %></h4>
                        <h4>上架時間: <%# Eval("Merchandiser_Editdata") %></h4>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString="Data Source=192.168.33.36;Initial Catalog=Mao;Persist Security Info=True;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Top 5  * FROM ShoppingNetwork.Merchandise ORDER BY [Merchandise_Creatdate] DESC"></asp:SqlDataSource>
        </div>
        <div class="col-md-6">
            <asp:DataList ID="DataList3" runat="server" DataKeyField="ArticleID" DataSourceID="SqlDataSource3">
                <ItemTemplate>
                    <div class="drawingpin">
                        <h2>[<%# Eval("TitleCategoryName") %>]<%# Eval("Title") %> - <%# Eval("BoardName") %>板</h2>
                        <h3>人氣 : <%# Eval("Number") %></h3>
                        <h3><%# Eval("LastChDateTime") %></h3>
                    </div>
                    <br />
                </ItemTemplate>
            </asp:DataList>
            <asp:SqlDataSource runat="server" ID="SqlDataSource3" ConnectionString="Data Source=192.168.33.36;Initial Catalog=Mao;Persist Security Info=True;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Top 10 * FROM [Article] as a join Board as b on a.BoardID = b.BoardID
                                                                  join TitleCategories t on a.TitleCategoryID = t.TitleCategoryID
                                                                 Where a.IsDeleted = 0
                                                                 ORDER BY Number DESC"></asp:SqlDataSource>
        </div>
    </div>
        
    <div>
    </div>
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
</body>
</html>
