using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewsAppMVC.Models;
using NewsAppMVC.ViewModels;

namespace NewsAppMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private NewsAppMVCContext db = new NewsAppMVCContext();

        // GET: Articles
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewModels.ArticleViewModel vm = new ViewModels.ArticleViewModel();
            vm.AllTopics = db.Topics.Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString()}).ToList();
            vm.AllAuthors = db.Authors.Select(c => new SelectListItem { Text = c.FirstName + " " + c.MiddleName + " " + c.LastName, Value = c.ID.ToString() }).ToList();
            
            return View(vm);
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DateCreated,DateUpdated,SelectedTopicIds,SelectedAuthorId")] ArticleViewModel articleVM)
        {
            
            if (ModelState.IsValid)
            {
                Article article = new Article()
                {
                    ID = articleVM.ID,
                    Name = articleVM.Name,
                    //DateCreated = articleVM.DateCreated,
                    DateCreated = DateTime.Today,
                    DateUpdated = DateTime.Today,
                   
                    Topics = db.Topics.Where(c => articleVM.SelectedTopicIds.Contains(c.ID)).ToList(),
                    Author = db.Authors.Where(c => articleVM.SelectedAuthorId.Equals(c.ID)).SingleOrDefault()
                };

                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articleVM);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            NewsAppMVC.ViewModels.ArticleViewModel articleVM = new ArticleViewModel()
            {
                ID = article.ID,
                Name = article.Name,
                DateCreated = article.DateCreated,
                DateUpdated = article.DateUpdated,
                
                Topics = article.Topics,
                Author = article.Author
            };
            articleVM.AllTopics = db.Topics.Select(c => new SelectListItem { Text = c.Name, Value = c.ID.ToString() }).ToList();
            articleVM.AllAuthors = db.Authors.Select(c => new SelectListItem { Text = c.FirstName + " " + c.MiddleName + " " + c.LastName, Value = c.ID.ToString() }).ToList();
            return View(articleVM);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,SelectedTopicIds,SelectedAuthorId,DateCreated,DateUpdated")] ViewModels.ArticleViewModel articleVM)
        {
          

           
            if (ModelState.IsValid)
            {
                Article existingArticle = db.Articles.Find(articleVM.ID);

                existingArticle.ID = articleVM.ID;
                existingArticle.Name = articleVM.Name;
                
                //existingArticle.DateCreated = articleVM.DateCreated;
                existingArticle.DateUpdated = DateTime.Today;
                //existingArticle.Topics = db.Topics.Where(c => articleVM.SelectedTopicIds.Contains(c.ID)).ToList();
                existingArticle.Author = db.Authors.Where(c => articleVM.SelectedAuthorId.Equals(c.ID)).SingleOrDefault();

                var existingTopicIds = existingArticle.Topics.Select(c => c.ID);

                var deletedTopicIds = existingTopicIds.Except(articleVM.SelectedTopicIds).ToList();

                var addedTopicIds = articleVM.SelectedTopicIds.Except(existingTopicIds);

                foreach (var item in deletedTopicIds)
                {
                    var deletedItem = db.Topics.Where(c => c.ID == item).SingleOrDefault();
                    existingArticle.Topics.Remove(deletedItem);
                }
                foreach (var item in addedTopicIds)
                {
                    var addedItem = db.Topics.Where(c => c.ID == item).SingleOrDefault();
                    existingArticle.Topics.Add(addedItem);
                }


                db.Entry(existingArticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articleVM);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
