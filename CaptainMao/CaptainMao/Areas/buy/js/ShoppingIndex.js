$(document).ready(function () {
    $("#tbody button").click(function () {
        document.cookie =
     // console.log($(this).val())
        $.cookie("myMerchandise", $(this).val(), { expires: 7 });
    })
})