//$(document).ready(function () {
//    $("#tbody button").click(function () {
//        document.cookie =
//     // console.log($(this).val())
//        $.cookie("myMerchandise", $(this).val(), { expires: 7 });
//    })
//})


window.onload = function () {
    hw4();

}

function hw4() {
    var c = document.querySelectorAll("a.pa");
    for (var i = 0; i < c.length; i++) {
        document.getElementById(c[i].id).onclick = function () { funChangImg(this.id) };
        document.getElementById(c[i].id).onmouseover = function () { mouseover(this.id) };
        document.getElementById(c[i].id).onmouseout = function () { mouseout(this.id) };
    }
    var x = document.getElementById("hw4_txt").children;
    for (var i = 0; i < x.length; i++) {
        x[i].onmouseover = function () {
            document.getElementById("hw4_image2").style.opacity = "1";

            document.getElementById("hw4_image2").src = "/Areas/buy/images/image_" + this.id.substr(1) + ".jpg";
            document.getElementById(this.id).style.backgroundColor = "#994639";
        }
        x[i].onmouseout = function () {
            document.getElementById("hw4_image2").style.opacity = "0";
            document.getElementById(this.id).style.backgroundColor = "white";
        }

        x[i].onclick = function () {
            document.getElementById("hw4_image").src = "/Areas/buy/images/image_" + this.id.substr(1) + ".jpg";
            image_n = i;
        }


        document.getElementById("aaction").onclick = funchang;


        function funchang() {
            if (aaction_ch) {
                interval = window.setInterval(funChangImg, 2000);
                document.getElementById("aaction").style.backgroundImage = "url(/Areas/buy/images/autoicon.png)";

            } else {
                clearInterval(interval);
                document.getElementById("aaction").style.backgroundImage = "url(/Areas/buy/images/go.png)";

            }
            aaction_ch = !aaction_ch;
        };
    }
}
var aaction_ch = true;
var interval;
var image_n = 1;
function funChangImg(e) {
    var n;
    if (e == "PrePage") {
        image_n = (image_n == 1) ? image_n = 6 : image_n - 1;
        n = (image_n - 1 == 0) ? 6 : image_n - 1;
    }
    else {
        image_n = (image_n == 6) ? image_n = 1 : image_n + 1;
        n = (image_n + 1 == 7) ? 1 : image_n + 1;
    }
    document.getElementById("hw4_image").src = "/Areas/buy/images/image_" + image_n + ".jpg";
    document.getElementById(e).style.backgroundImage = "url('/Areas/buy/images/image_" + n + ".jpg')";
}

function mouseover(e) {
    if (e == "PrePage") {
        var n = (image_n - 1 == 0) ? 6 : image_n - 1;
    }
    else {
        var n = (image_n + 1 == 7) ? 1 : image_n + 1;
    }
    document.getElementById(e).style.backgroundImage = "url('/Areas/buy/images/image_" + n + ".jpg')";
}

function mouseout(e) {
    document.getElementById(e).style.backgroundImage = "";
}