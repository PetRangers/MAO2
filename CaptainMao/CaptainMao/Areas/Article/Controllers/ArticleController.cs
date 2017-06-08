using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptainMao.Models;
using CaptainMao.Areas.Article.Models;
using PagedList.Mvc;
using PagedList;
using Microsoft.Security.Application;

namespace CaptainMao.Areas.Article.Controllers
{
    public class ArticleController : Controller
    {
        private Ipository<CaptainMao.Models.Article> articledb = new pository<CaptainMao.Models.Article>();
        private Ipository<CaptainMao.Models.Comment> commentdb = new pository<CaptainMao.Models.Comment>();
        private MaoEntities db = new MaoEntities();
        // GET: Article/Article
        //顯示所有文章
        public ActionResult Index(int? page,int? titleCategoryID, int? boardID)
        {
            var article=db.Articles.Select(a=>a);
            if (titleCategoryID != null)
            {
                article = article.Where(a => a.TitleCategoryID == titleCategoryID && a.IsDeleted != true);
            }
            if (boardID != null)
            {
                article = article.Where(a => a.BoardID == boardID && a.IsDeleted != true).OrderByDescending(a => a.LastChDateTime);
            }
            article = article.Where(a=>a.IsDeleted != true).OrderByDescending(a => a.LastChDateTime);
            return View(article.ToList().ToPagedList(page ?? 1,10));
        }
        [ChildActionOnly]
        public ActionResult BoardCategories()
        {
            return PartialView(db.Boards.ToList());
        }
        //顯示主版內容
        public ActionResult Board()
        {
            BoardViewModel board = new BoardViewModel();
            board.article = db.Articles.Where(a=>a.IsDeleted !=true).OrderByDescending(a=>a.Number).Take(6);
            return View(board);
        }
        public ActionResult Create()
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Boards.ToList();
            return View();
        }
        //建立文章
        [HttpPost]
        public ActionResult Create(CaptainMao.Models.Article article)
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Boards.ToList();

            //string url = Url.Content("~/Images/" + upload.FileName);
            ////string script = $"<script>window.parent.CKEDITOR.tools.callFunction({article},'{url}','')</script>";
            //upload.SaveAs(Server.MapPath("~/Images/" + upload.FileName));
            //return Content(script);
            if (ModelState.IsValid)
            {
                article.CreateDateTime = DateTime.Now;
                article.LastChDateTime = DateTime.Now;
                article.PosterID = db.Articles.First().PosterID;
                article.Number = 0;

                articledb.Create(article);
                return RedirectToAction("Index");
            }
            return View();
        }
        //秀文章內容
        [HttpGet]
        public ActionResult Show(int? articleID)
        {
            CaptainMao.Areas.Article.Models.CommentViewModel vm = new CommentViewModel();
            var article = db.Articles.Find(articleID);
            article.Number++;

            db.Entry(article).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            vm.comment = db.Comments.Where(a=>a.ArticleID==articleID);
            vm.article = db.Articles.Where(a => a.ArticleID == articleID);
            return View(vm);
        }
        public ActionResult Comment()
        {
            return View();
        }
        //建置留言
        [HttpPost]
        public ActionResult Comment(CaptainMao.Models.Comment comment,int id)
        {
            if (ModelState.IsValid)
            {
                comment.ArticleID = db.Articles.Find(id).ArticleID;
                //comment.ArticleID = commentdb.GetID(id).ArticleID;
                comment.NewDateTime = DateTime.Now;
                comment.PosterID = db.Articles.First().PosterID;

                var articleDT = db.Articles.Find(id);
                articleDT.LastChDateTime = DateTime.Now;
                db.Entry(articleDT).State = System.Data.Entity.EntityState.Modified;

                commentdb.Create(comment);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Aside()
        {
            return PartialView();
        }
        //顯示使用者的發佈的文章
        public ActionResult Poster(int? page,string posterID)
        {
            var article = db.Articles.Where(a => a.IsDeleted != true).OrderByDescending(a=>a.LastChDateTime);
            article.First().PosterID = posterID;
            return View(article.ToList().ToPagedList(page ?? 1, 10));
        }
        //修改文章前用ID找文章
        public ActionResult Edit(int? articleID)
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Boards.ToList();
            CaptainMao.Models.Article article= db.Articles.Find(articleID);
            article.ContentText = HttpUtility.HtmlDecode(article.ContentText);
            return View(article);
        }
        //修改文章
        [HttpPost]
        public ActionResult Edit(CaptainMao.Models.Article article)
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Boards.ToList();

            if (ModelState.IsValid)
            {
                article.LastChDateTime = DateTime.Now;

                articledb.Update(article);
                return RedirectToAction("Poster");
            }
            return View();
        }
        //刪除文章，但只是把文章做隱藏
        public ActionResult Del(int? articleID)
        {
            db.Articles.Find(articleID).IsDeleted = true ;
            db.SaveChanges();
            return RedirectToAction("Poster");
        }
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            var fileName = System.IO.Path.GetFileName(upload.FileName);
            var filePhysicalPath = Server.MapPath("~/UploadImage/" + fileName);

            upload.SaveAs(filePhysicalPath);

            var url = "/UploadImage/" + fileName;
            var CKEditorFuncNum = System.Web.HttpContext.Current.Request["CKEditorFuncNum"];

            string startTag = @"<script type = ""text/javascript"">";
            string endTag = "</script>";
            string contentBefore = @"window.parent.CKEDITOR.tools.callFunction( """;
            string contentAfter = @""", " + filePhysicalPath + @", """" );";

            string result = startTag + contentBefore + CKEditorFuncNum + contentAfter + endTag;

            //string url = Url.Content("~/UploadImage/" + upload.FileName);
            //string script = $"<script>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum},'{url}','')</script>";
            //upload.SaveAs(Server.MapPath("~/UploadImage/" + upload.FileName));
            //"<script>window.parent.CKEDITOR.tools.callFunction("+CKEditorFuncNum+", \""+url+"\");</script>"
            return Content(result, "text/html");
        }
    }
}