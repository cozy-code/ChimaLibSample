using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChimaLibSample.Models;

using ChimaLib.Models;

namespace ChimaLibSample.Controllers
{
    public class ArticlesController : Controller
    {
        private ChimaLibSampleContext db = new ChimaLibSampleContext();

        // GET: Articles
        public ActionResult Index(string sort,string filter)
        {
            var query = db.Articles.AsQueryable();  //データソース
            // filter
            if(!string.IsNullOrEmpty(filter)) {
                query = query.Where(a => a.Title.Contains(filter) || a.Description.Contains(filter));
            }

            Article article = null;
            SortDefinition<Article> sort_def = new SortDefinition<Article>() {
                Fields = new[] {   //ソート列定義
                    article.DefineSort(a=>a.Url),
                    article.DefineSort(a=>a.Title),
                    article.DefineSort(a=>a.Description),
                    article.DefineSort(a=>a.Viewcount),
                    article.DefineSort(a=>a.Published),
                    article.DefineSort(a=>a.Released),
                },
                SortKey=sort
            };

            query=sort_def.AddOrderBy(query);

            ViewBag.SortDef = sort_def;     //リンク作成用にソート定義を渡す
            ViewBag.InputedFilter = filter; //入力されたフィルター
            return View(query.ToList());    //ソート済み結果をViewに返す。
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
            return View();
        }

        // POST: Articles/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Title,Description,Viewcount,Published,Released")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
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
            return View(article);
        }

        // POST: Articles/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Title,Description,Viewcount,Published,Released")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
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
