using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class controleProdutoesController : Controller
    {
        private RestAPIContex db = new RestAPIContex();

        // GET: controleProdutoes
        public ActionResult Index()
        {
            var controleProdutoes = db.controleProdutoes.Include(c => c.Categoria).Include(c => c.Produto);
            return View(controleProdutoes.ToList());
        }

        // GET: controleProdutoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            controleProduto controleProduto = db.controleProdutoes.Find(id);
            if (controleProduto == null)
            {
                return HttpNotFound();
            }
            return View(controleProduto);
        }

        // GET: controleProdutoes/Create
        public ActionResult Create()
        {
            ViewBag.categoriasId = new SelectList(db.Categorias, "categoriasId", "nome");
            ViewBag.ProdutoId = new SelectList(db.produtoes, "ProdutoId", "nome");
            return View();
        }

        // POST: controleProdutoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(controleProduto controleProduto)
        {
            if (ModelState.IsValid)
            {
                var controleProdutoes = db.controleProdutoes.Include(c => c.Categoria).Include(c => c.Produto);
                //var prodCont = db.controleProdutoes.Where(p => p.ProdutoId == controleProduto.ProdutoId).FirstOrDefault();
                //foreach(controleProduto)
                foreach(var produto in controleProdutoes)
                {
                    if (produto.ProdutoId == controleProduto.ProdutoId && produto.categoriasId == controleProduto.categoriasId)
                    {                        
                        return RedirectToAction("Create");                        
                    }
                    
                }

                db.controleProdutoes.Add(controleProduto);
                db.SaveChanges();
                return RedirectToAction("Index");


            }

            ViewBag.categoriasId = new SelectList(db.Categorias, "categoriasId", "nome", controleProduto.categoriasId);
            ViewBag.ProdutoId = new SelectList(db.produtoes, "ProdutoId", "nome", controleProduto.ProdutoId);
            return View(controleProduto);
        }

        // GET: controleProdutoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            controleProduto controleProduto = db.controleProdutoes.Find(id);
            if (controleProduto == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoriasId = new SelectList(db.Categorias, "categoriasId", "nome", controleProduto.categoriasId);
            ViewBag.ProdutoId = new SelectList(db.produtoes, "ProdutoId", "nome", controleProduto.ProdutoId);
            return View(controleProduto);
        }

        // POST: controleProdutoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "controleProdutoId,ProdutoId,categoriasId")] controleProduto controleProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(controleProduto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoriasId = new SelectList(db.Categorias, "categoriasId", "nome", controleProduto.categoriasId);
            ViewBag.ProdutoId = new SelectList(db.produtoes, "ProdutoId", "nome", controleProduto.ProdutoId);
            return View(controleProduto);
        }

        // GET: controleProdutoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            controleProduto controleProduto = db.controleProdutoes.Find(id);
            if (controleProduto == null)
            {
                return HttpNotFound();
            }
            return View(controleProduto);
        }

        // POST: controleProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            controleProduto controleProduto = db.controleProdutoes.Find(id);
            db.controleProdutoes.Remove(controleProduto);
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
