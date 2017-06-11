     
$(document).ready(function () {
    var me = {};
    me.avatar = $('#userPhoto').val();

    var you = {};
    you.avatar = "";

    $(document).on('click', '.getchat', function () {
        var id = $(this).attr('data-id');
        var name = $(this).attr('data-name');
        var img = $(this).attr('data-img');
        $('#targetID').val(id);
        $('.chatTitle').text(name);
        you.avatar = img;
    });


    var flag = false;
    $('.frame').hide();
    $('.frame >div').hide();
    $('.chatTitle').click(function () {
        var frame = $('.frame');
       
        if(!flag) {
            flag = true;
            
            frame.slideDown(1000, function () {
                $('.frame > ul').show();
                $('.frame >div').show();
            });
        }
        else {
            flag = false;
            $('.frame > ul').hide();
            $('.frame >div').hide();
            frame.slideToggle(1000, function () { });            
        } 
    })

    var userID = "";
    var nickName = "";

    userID = $('#userID').val();
    nickName = $('#userNickName').val();

    //建立與Server端的Hub的物件，注意Hub的開頭字母一定要為小寫
    var chat = $.connection.chatHub;

    //取得所有上線清單
    //chat.client.getList = function (userList) {
    //    var docFrag = $(document.createDocumentFragment());
    //    $.each(userList, function (index, data) {
    //        var option = $("<option></option>").val(data.id).text(data.name).attr("id", data.id);
    //        docFrag.append(option);
    //    });

    //    $("#box").append(docFrag);
    //}

    ////新增一筆上線人員
    //chat.client.addList = function (id, name) {
    //    var option = $("<option></option>").val(id).text(name).attr("id", id);
    //    $("#box").append(option);
    //}

    //移除一筆上線人員
    //chat.client.removeList = function (id) {
    //    $("#" + id).remove();
    //}

    formatAMPM = function (date) {
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0' + minutes : minutes;
        var strTime = hours + ':' + minutes + ' ' + ampm;
        return strTime;
    }

    chat.client.insertChat = function (who, text) {
        var control = "";
        var date = formatAMPM(new Date());

        if (who == "me") {

            control = '<li style="width:100%;">' +
                              '<div class="msj-rta macro">' +
                              '<div class="text text-l">' +
                              '<p>' + text + '</p>' +
                              '<p><small>' + date + '</small></p>' +
                              '</div>' +
                              '<div class="avatar" style="padding:0px 0px 0px 10px !important"><img class="img-circle" style="width:100%;" src="' + me.avatar + '" /></div>' +
                              '</li>';
            $('#chatul').append(control);
        } else {
            control = '<li style="width:100%">' +
                            '<div class="msj macro">' +
                            '<div class="avatar"><img class="img-circle" style="width:100%;" src="' + you.avatar + '" /></div>' +
                            '<div class="text text-r">' +
                            '<p>' + text + '</p>' +
                            '<p><small>' + date + '</small></p>' +
                            '</div>' +
                            '</div>' +
                            '</li>';
            $('#chatul').append(control);
            
        }
    }

    $(".mytext").on("keyup", function (e) {
        if (e.which == 13) {
            var text = $(this).val();
            var id = $('#targetID').val();
            if (text !== "" || id != "") {
                chat.server.sendMessage(id, text);
                $(this).val('');
            }
        }
    });

    $.connection.hub.start();
});