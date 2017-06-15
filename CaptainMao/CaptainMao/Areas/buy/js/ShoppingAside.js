$(document).ready(function () {
    fun_selectIndex();

    /*發生change事件時的更換*/
    //$(document).on("click", "#CategoryID", changeIndex);
    /*產生aside滑動事件*/
    $("aside").hover(f1, f2).
        find("#firstpane .menu_head").mouseover(fun_asideshow).
        next("div.menu_body").hover(f1).stop(true, true).
        find("a").mouseover(fun_asidesAjax);
        
});

function fun_selectIndex() {
    /*因共用同一個index 故查詢網址列如有參數則讓aside選單初始為參數值*/
    var search = document.location.search;
    if (search !== "") {
        /*查詢出來的第一個參數值*/
        var sercateID = search.split("&")[0].split("=")[1];
        /*設定選單的index，因陣列從0開始故-1*/
        var x = sercateID - 1;
        $("div.menu_body:eq(" + x + ")").show().
            parent().find("span:eq(" + x + ")").addClass("glyphicon-chevron-down");
    }
}
function fun_asideshow() {
    f2();
    var s = $(this);
    s.next("div.menu_body").slideDown(500).siblings("div.menu_body").slideUp("slow");  
    /*做箭頭動畫*/
    s.find("span").addClass("glyphicon-chevron-down");
    s.siblings().find("span").removeClass("glyphicon-chevron-down");
    /*載入ajex選單*/
}
var stype = $("#sTypeArea");
function fun_asidesAjax(e) {
    var _this = $(this);
    var cateID = _this.data("cate");
    var TypeID = _this.data("type");
    //console.log($(this).data("cate"), $(this).data("type"));
    $.getJSON("../zPublicFunction/returnJson_asTypes", { CategoryID: cateID, Type_ID: TypeID },
        function (data) {
            var dof = $(document.createDocumentFragment());
            
            $.each(data, function (ind, value) {
                
                    var typeA = $('<a></a>').text(value.sType_Name).
                        attr("href", "buy?CategoryID=" + cateID + "&sType_ID=" + value.sType_ID);
                    var typeLi = $('<li></li>').append(typeA).addClass("list-group-item");
                    dof.append(typeLi);
                });
                var typeUL = $('<ul></ul>').append(dof).addClass("list-group");
                stype.html(typeUL);
            })
    h = _this.offset().top-50;
    stype.css({ 'top': h + 'px' })

}



function f1(e) {
   stype.show();
    }
    function f2() {
        stype.hide();
    }




//function changeIndex() {
//    var CateSelet = $('#CategoryID :selected').val();
//    window.location.href = "Index?cateID=" + CateSelet;
//}


