     
$(document).ready(function () {
    var me = {};
    me.avatar = "";

    var you = {};
    you.avatar = "";

    $(document).on('click', '.getchat', function () {
        var id = $(this).attr('data-id');
        var name = $(this).attr('data-name');
        var img = $(this).attr('data-img');

        $(".nextchat").load("../../Shared/_Chat", function () {
            //alert("complete");
            $(this).removeClass('nextchat');
            $('#chatdiv').append('<div class="childdiv nextchat"></div>');

            $(this).find('#targetID').val(id);
            $(this).find('.chatTitle').text(name);
            me.avatar = $(this).find('#userPhoto').val();
            you.avatar = img;
        })
        
    });

    //展開縮小
    //var flag = false;
    //$('.frame').hide();
    //$('.frame >div').hide();
    //$('#chatdiv').on('click', '.chatTitle', function () {
    //    var frame = $(this).siblings('.frame');
       
    //    if(!flag) {
    //        flag = true;
            
    //        frame.slideDown(1000, function () {
    //            frame.children('ul').show();
    //            frame.children('div').show();
    //        });
    //    }
    //    else {
    //        flag = false;
    //        frame.children('ul').hide();
    //        frame.children('div').hide();
    //        frame.slideToggle(1000, function () { });            
    //    } 
    //})

    //建立與Server端的Hub的物件，注意Hub的開頭字母一定要為小寫
    var chat = $.connection.chatHub;


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

    var chatting = "";

    chat.client.insertChat = function ( text) {
        var control = "";
        var date = formatAMPM(new Date());
        control = '<li style="width:100%;">' +
                          '<div class="msj-rta macro">' +
                          '<div class="text text-l">' +
                          '<p>' + text + '</p>' +
                          '<p><small>' + date + '</small></p>' +
                          '</div>' +
                          '<div class="avatar" style="padding:0px 0px 0px 10px !important"><img class="img-circle" style="width:100%;" src="' + me.avatar + '" /></div>' +
                          '</li>';
            chatting.find('.chatul').append(control);
    }

    chat.client.sendChat = function (text, who, img, name) {
      
        var control = "";
        var date = formatAMPM(new Date());
        control = '<li style="width:100%">' +
                          '<div class="msj macro">' +
                          '<div class="avatar"><img class="img-circle" style="width:100%;" src="' + img + '" /></div>' +
                          '<div class="text text-r">' +
                          '<p>' + text + '</p>' +
                          '<p><small>' + date + '</small></p>' +
                          '</div>' +
                          '</div>' +
                          '</li>';

        var exist = false;
        $('.frame').each(function () {
            var id = $(this).find('#targetID').val();

            if (id == who) {
                $(this).find('.chatul').append(control);
                exist = true;
            }
        });

        if (!exist)
        {
            $(".nextchat").load("../../Shared/_Chat", function () {
                //alert("complete");
                $(this).removeClass('nextchat');
                $('#chatdiv').append('<div class="childdiv nextchat"></div>');

                $(this).find('#targetID').val(who);
                $(this).find('.chatTitle').text(name);  
                me.avatar = $(this).find('#userPhoto').val();

                $(this).find('.chatul').append(control);
            })
        }
        //$('.frame').find('.chatul').append(control);
        //$('#targetID').val(who);

        
    }

    $(document).on("keyup",".mytext", function (e) {
        if (e.which == 13) {
            var text = $(this).val();
            var id = $(this).parents('.frame').find('#targetID').val();
            if (text !== "" || id != "") {
                chat.server.sendMessage(id, text, me.avatar);
                chatting = $(this).parents('.frame');
                $(this).val('');
            }
        }
    });

    $.connection.hub.start();
});