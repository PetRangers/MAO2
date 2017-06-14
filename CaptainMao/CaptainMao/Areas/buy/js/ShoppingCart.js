var app = angular.module('MaoApp', []);
app.controller('MainController', function ($scope, $http) {
    //抓訂單實體網址
var httpurl = '@Url.RouteUrl("DefaultApi", new { httproute = "", controller = "PublicAPI" }, "http")';
    loadData();
//初始設定
function loadData()
{
    $http.get(httpurl).then(function(response) { $scope.items = response.data;
    });
}
//更換儲存
$scope.myFunchang = function(item) {
    $http.put(httpurl, item).then(function() {
        $scope.shopps = "";
        loadData();
    })
}
//刪除
$scope.myFunDelete = function(item) {
    $http.delete(httpurl + "/" + item.cartID).then(function() {
        $scope.shopps = "";
        loadData();
    })
}
//總計
$scope.getTotal = function () {
    var total = 0;
    for (var i = 0; i < $scope.items.length; i++) {
        var product = $scope.items[i];
        total += (product.Merchandise_Price * product.merchandise_Volume);
    }
    return total;
}
});

$(document).ready(function () {

    CitysChange();
    $(document).on('change', '#Citys', CitysChange);

    function CitysChange() {
        //alert($(this).find("option:selected").text());
        $.getJSON("../zPublicFunction/returnJson_selectFourStore", { city: $('#Citys').find("option:selected").text() },
        function (data) {
            var dof = $(document.createDocumentFragment());

            $.each(data, function (ind, value) {
                var add = value.BranchAddress.split("、")[0];

                var typeLi = $('<li></li>').text(add).addClass("list-group-item").
                mouseenter(function () {
                    var address = "http://maps.google.com.tw/maps?f=q&hl=zh-TW&geocode=&q=" + $(this).text() + "&z=16&output=embed&t=";
                    $('#cityMap').attr("src", address);
                }).click(function () {
                    $('.UserAddress').text($(this).text()).val($(this).text());
                                
                });
                dof.append(typeLi);
            });
            $('#cityselect').html(dof);
        })
    }
})