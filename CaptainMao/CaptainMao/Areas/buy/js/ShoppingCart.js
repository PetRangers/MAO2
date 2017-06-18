$(document).ready(function () {
    CitysChange();
    $(document).on('change', '#Citys', CitysChange);

    function CitysChange() {
        //alert($(this).find("option:selected").text());
        $.getJSON("../zPublicFunction/returnJson_selectFourStore", { cityID: $('#Citys').find("option:selected").val() },
        function (data) {
            var dof = $(document.createDocumentFragment());

            $.each(data, function (ind, value) {
                var address = value.BranchAddress.split("、")[0];
                var add = value.Compete +"-"+ value.BranchAddress.split("、")[0];
                                
                var typeLi = $('<li></li>').val(value.BranchID).text(add).addClass("list-group-item").
                                    mouseenter(function () {
                                        var address = "https://maps.google.com.tw/maps?f=q&hl=zh-TW&geocode=&q=" + address + "&z=16&output=embed&t=";
                                        $('#cityMap').attr("src", address);}).                                
                                    click(function () {
                                        $('.UserAddress').text($(this).text()).val($(this).text());
                                        $('#UserAddressID').val($(this).val());
                                    });
                                    dof.append(typeLi);
            });
            $('#cityselect').html(dof);
        })
    }
})