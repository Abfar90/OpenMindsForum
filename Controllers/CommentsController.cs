using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenMindsForum.Models;
using OpenMindsForum.ViewModels;

namespace OpenMindsForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly OpenMindsForumContext _context;

        public CommentsController(OpenMindsForumContext context)
        {
            _context = context;
        }
        // GET: CommentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CommentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCommentViewModel createComment, int id)
        {
            if (ModelState.IsValid)
            {
                var newComment = new Comment
                {
                    PostId = id,
                    Title = createComment.title,
                    CommentContent = createComment.content,
                    CommentStamp = DateTime.Now,
                };
                _context.Add(newComment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Posts", id);
            }
            return RedirectToAction("Details","Posts", id);
        }

        // GET: CommentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
