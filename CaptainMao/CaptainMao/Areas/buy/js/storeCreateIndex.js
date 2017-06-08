$(document).ready(function () {
    //讀圖片
    $(document).on("change", "#photo", hasPix);
    });

function hasPix() {
    var fReader = new FileReader();
    fReader.readAsDataURL(this.files[0]);
    fReader.onloadend = function (event) {
        $("#Merimg").attr("src", event.target.result)
        //document.getElementById("Merimg").style.backgroundImage = event.target.result
    }
}


