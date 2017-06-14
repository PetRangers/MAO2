using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Web.Mvc;
using CaptainMao.Models;
using Microsoft.AspNet.Identity;


namespace CaptainMao
{
    public class ChatHub : Hub
    {
        MaoEntities db = new MaoEntities();

        public static class UserHandler
        {
            public static Dictionary<string, string> ConnectedIds = new Dictionary<string, string>();
        }

        public override Task OnConnected()
        {
            var userName = Context.User.Identity.Name;
            var userID = Context.User.Identity.GetUserId();
            if (userID == null || userName == null)
            {
                return base.OnConnected();
            }
            var userNickName = db.AspNetUsers.Where(u => u.UserName == userName).Select(u => u.NickName).First();
            //User is null then Identity and Name too.
            
            //Clients.Others.addList(userID, userNickName);
            //Clients.Caller.getList(UserHandler.ConnectedIds.Select(p => new { id = p.Key, name = p.Value }).ToList());
            UserHandler.ConnectedIds.Add(userID, userNickName);

            return base.OnConnected();
        }

        //發送訊息至特定使用者
        public void sendMessage(string ToID, string message, string senderPhoto)
        {
            message = HttpUtility.HtmlEncode(message);

            var FromID = Context.User.Identity.GetUserId();
            var FromName = db.AspNetUsers.Where(u => u.Id == FromID).Select(u => u.NickName).First();

            ToID = db.AspNetUsers.Where(u => u.Id == ToID).Select(u => u.UserName).First();
            Clients.Caller.insertChat(message);
            Clients.User(ToID).sendChat(message, FromID, senderPhoto, FromName);
        }

        //當使用者斷線時呼叫
        public override Task OnDisconnected(bool stopCalled)
        {
            var userID = Context.User.Identity.GetUserId();
            //當使用者離開時，移除在清單內的 ConnectionId
            //Clients.All.removeList(userID);
            if (userID != null)
            {
                UserHandler.ConnectedIds.Remove(userID);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}