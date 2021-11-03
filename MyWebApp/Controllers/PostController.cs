using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Data;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class PostController : Controller
    {
        // GET: PostController1
        public ActionResult Index()
        {
            var posts = PostMemRepository.SelecionarTodos();
            return View(posts);
        }

        // GET: PostController1/Details/5
        public ActionResult Details(int id)
        {

            var post = PostMemRepository.SelecionarPorId(id);

            if (post == null)
                return NotFound();
            
            return View(post);
        }

        // GET: PostController1/Create
        public ActionResult Create()
        {
            var post = new Post();
            return View();
        }

        // POST: PostController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Post post = new Post();

                TryUpdateModelAsync(post);

                PostMemRepository.Adicionar(post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController1/Edit/5
        public ActionResult Edit(int id)
        {
            var post = PostMemRepository.SelecionarPorId(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        // POST: PostController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                PostMemRepository.Editar(id, post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(post);
            }
        }

        // GET: PostController1/Delete/5
        public ActionResult Delete(int id)
        {
            var post = PostMemRepository.SelecionarPorId(id);

            if (post == null)
                return NotFound();

            return View(post);
        }

        // POST: PostController1/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PostMemRepository.Excluir(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
