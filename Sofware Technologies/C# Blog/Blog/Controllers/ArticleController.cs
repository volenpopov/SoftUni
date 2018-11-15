using Blog.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Article/List
        public ActionResult List()
        {
            using (var db = new BlogDbContext())
            {
                // Get the articles from the 

                var articles = db.Articles
                    .Include(a => a.Author)
                    .ToList();

                return View(articles);
            }
        }

        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Include(a => a.Author)
                    .SingleOrDefault(a => a.Id == id);

                if (article == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(article);
            }
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    try
                    {
                        var authorId = db.Users
                            .SingleOrDefault(u => u.UserName == this.User.Identity.Name)
                            .Id;

                        if (authorId == null)
                        {
                            return View(article);
                        }

                        article.AuthorId = authorId;

                        db.Articles.Add(article);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }

                    catch
                    {
                        return View(article);
                    }
                }
            }

            return View(article);
        }

        // GET: Article/Delete
        [Authorize]
        public ActionResult Delete(int? id)
        {
            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Include(a => a.Author)
                    .SingleOrDefault(a => a.Id == id);

                if (article == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                return View(article);
            }
        }

        // POST: Article/Delete
        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Include(a => a.Author)
                    .SingleOrDefault(a => a.Id == id);

                if (article == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                db.Articles.Remove(article);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }

        // GET: Article/Edit
        [Authorize]
        public ActionResult Edit(int? id)
        {
            using (var db = new BlogDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var article = db.Articles
                    .Include(a => a.Author)
                    .SingleOrDefault(a => a.Id == id);

                if (article == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;

                return View(model);
            }
        }

        // POST: Article/Edit
        [Authorize]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(ArticleViewModel model)
        {
            using (var db = new BlogDbContext())
            {
                var article = db.Articles
                    .Include(a => a.Author)
                    .SingleOrDefault(a => a.Id == model.Id);

                if (article == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                article.Title = model.Title;
                article.Content = model.Content;

                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        private bool IsUserAuthorizedToEdit(Article article)
        {
            using (var db = new BlogDbContext())
            {
                bool isAdmin = this.User.IsInRole("Admin");
                bool isAuthor = article.IsAuthor(this.User.Identity.Name);

                return isAdmin || isAuthor;
            }
        }
    }
}