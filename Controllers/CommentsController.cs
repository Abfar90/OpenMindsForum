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

        // GET: CommentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        [Route("Details")]
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
                return RedirectToAction("Details", "Posts", new { id = id });
            }
            return NotFound();
        }
    }
}
