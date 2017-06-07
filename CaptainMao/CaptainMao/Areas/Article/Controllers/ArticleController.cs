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
using System.IO;

namespace CaptainMao.Areas.Article.Controllers
{
    public class ArticleController : Controller
    {
        private Ipository<CaptainMao.Models.Article> articledb = new pository<CaptainMao.Models.Article>();
        private Ipository<CaptainMao.Models.Comment> commentdb = new pository<CaptainMao.Models.Comment>();
        private MaoEntities db = new MaoEntities();
        // GET: Article/Article
        //顯示所有文章
        public ActionResult Index(int? page, int? titleCategoryID, int? boardID)
        {
            var article = db.Article.Select(a => a);
            if (titleCategoryID != null)
            {
                article = article.Where(a => a.TitleCategoryID == titleCategoryID && a.IsDeleted != true);
            }
            if (boardID != null)
            {
                article = article.Where(a => a.BoardID == boardID && a.IsDeleted != true).OrderByDescending(a => a.LastChDateTime);
            }
            article = article.Where(a => a.IsDeleted != true).OrderByDescending(a => a.LastChDateTime);
            return View(article.ToList().ToPagedList(page ?? 1, 10));
        }
        [ChildActionOnly]
        public ActionResult BoardCategories()
        {
            return PartialView(db.Board.ToList());
        }
        //顯示主版內容
        public ActionResult Board()
        {
            BoardViewModel board = new BoardViewModel();
            board.article = db.Article.Where(a => a.IsDeleted != true).OrderByDescending(a => a.Number).Take(6);
            return View(board);
        }
        public ActionResult Create()
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Board.ToList();
            return View();
        }
        //建立文章
        [HttpPost]
        public ActionResult Create(CaptainMao.Models.Article article)
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Board.ToList();

            //string url = Url.Content("~/Images/" + upload.FileName);
            ////string script = $"<script>window.parent.CKEDITOR.tools.callFunction({article},'{url}','')</script>";
            //upload.SaveAs(Server.MapPath("~/Images/" + upload.FileName));
            //return Content(script);
            if (ModelState.IsValid)
            {
                article.CreateDateTime = DateTime.Now;
                article.LastChDateTime = DateTime.Now;
                
                article.PosterID = db.Article.First().PosterID;
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
            var article = db.Article.Find(articleID);
            article.Number++;

            db.Entry(article).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            vm.comment = db.Comment.Where(a => a.ArticleID == articleID);
            vm.article = db.Article.Where(a => a.ArticleID == articleID);
            return View(vm); 
        }
        public ActionResult Comment()
        {
            return View();
        }
        //建置留言
        [HttpPost]
        public ActionResult Comment(CaptainMao.Models.Comment comment, int id)
        {
            if (ModelState.IsValid)
            {
                comment.ArticleID = db.Article.Find(id).ArticleID;
                //comment.ArticleID = commentdb.GetID(id).ArticleID;
                comment.NewDateTime = DateTime.Now;
                comment.PosterID = db.Article.First().PosterID;

                var articleDT = db.Article.Find(id);
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
        public ActionResult Poster(int? page, string posterID)
        {
            posterID = "d6927155-c35b-4810-a830-e9de6cd9cf0d";
            var article = db.Article.Where(a =>a.PosterID==posterID && a.IsDeleted != true).OrderByDescending(a => a.LastChDateTime);
            return View(article.ToList().ToPagedList(page ?? 1, 10));
        }
        //修改文章前用ID找文章
        public ActionResult Edit(int? articleID)
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Board.ToList();
            CaptainMao.Models.Article article = db.Article.Find(articleID);
            article.ContentText = HttpUtility.HtmlDecode(article.ContentText);
            return View(article);
        }
        //修改文章
        [HttpPost]
        public ActionResult Edit(CaptainMao.Models.Article article)
        {
            ViewBag.datas = db.TitleCategories.ToList();
            ViewBag.datas2 = db.Board.ToList();

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
            db.Article.Find(articleID).IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("Poster");
        }

        /// CKEditor 圖片檔案管理頁
        /// </summary>
        /// <param name="CKEditorFuncNum">CKEditor必要參數</param>
        /// <returns>CKEditorImageFileManager Page</returns>
        public ActionResult CKEditorImageFileManager(string CKEditorFuncNum)
        {
            CKEditorFuncNum = (CKEditorFuncNum == null) ? string.Empty : CKEditorFuncNum.Trim();
            ViewData["CKEditorFuncNum"] = CKEditorFuncNum;

            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/files/"));
            var searchFiles = dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                .Where(o => o.Extension.ToLower().Equals(".jpg") || o.Extension.ToLower().Equals(".gif") || o.Extension.ToLower().Equals(".png"));

            List<string> fileDatas = new List<string>();
            fileDatas = searchFiles.OrderByDescending(o => o.LastWriteTime).Select(o =>
            {
                var fileName = Path.GetFileName(o.FullName);
                string fullFileName = string.Format("~/files/{0}", fileName);
                return fullFileName;
            }).ToList();
            return View(fileDatas);
        }

        /// 檔案上傳
        /// </summary>
        /// <param name="file">檔案(可多個)</param>
        /// <returns>上傳結果(json資料格式)-配合[bootstrap-fileinput套件]</returns>
        [HttpPost]
        public ActionResult CKEditorFileUpload(HttpPostedFileBase[] file)
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { error = "No file selected.", errorkeys = new string[0] });
            }
            string errorMessage = "You have faced errors in {0} files.";
            string root = Server.MapPath("~/files/");
            List<string> errorKeys = new List<string>();
            List<Tuple<string, string>> files = new List<Tuple<string, string>>();
            if (file != null && file.Count() > 0)
            {
                for (int i = 0; i < file.Count(); i++)
                {
                    var fileItem = file[i];
                    string fileExtension = Path.GetExtension(fileItem.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(fileItem.FileName);

                    var checkFiles = Directory.GetFiles(root, fileItem.FileName);
                    if (checkFiles != null && checkFiles.Count() > 0)
                    {
                        Random random = new Random(DateTime.Now.Second);
                        var sno = random.Next(0, 10000);
                        fileName = string.Format("{0}_{1}_{2}", fileName, DateTime.Now.ToString("yyyyMMddHHmmss"), sno);
                    }
                    try
                    {
                        fileItem.SaveAs(Path.Combine(root, fileName + fileExtension));
                        files.Add(new Tuple<string, string>(Url.Content("~/files/"), fileName + fileExtension));
                    }
                    catch (Exception)
                    {
                        errorKeys.Add(i.ToString());
                        continue;
                    }
                }
            }
            //錯誤回傳格式 => {error: 'You have faced errors in 4 files.', errorkeys: [0, 3, 4, 5]}
            if (errorKeys.Count > 0)
            {
                return Json(new { error = string.Format(errorMessage, errorKeys.Count), errorkeys = errorKeys.ToArray() });
            }
            else
            {
                return Json(new { files = files.Select(o => new { @FilePath = o.Item1, @FileName = o.Item2 }).ToArray() });
            }
        }

        /// <summary>
        /// 使用檔名刪除檔案
        /// </summary>
        /// <param name="fileName">檔案名稱</param>
        /// <returns>刪除結果</returns>
        public ActionResult CKEditorFileDelete(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return Json(new { IsSuccess = false, Message = "File name must input." });
            string root = Server.MapPath("~/files/");
            DirectoryInfo dirInfo = new DirectoryInfo(root);
            var checkFiles = dirInfo.GetFiles(fileName);
            if (checkFiles != null && checkFiles.Count() > 0)
            {
                foreach (var item in checkFiles)
                {
                    try
                    {
                        var delFileName = Path.GetFileName(item.FullName);
                        if (delFileName.Equals(fileName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            item.Delete();
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                return Json(new { IsSuccess = true, Message = string.Empty });
            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Can't find file by file name." });
            }
        }
    }
}