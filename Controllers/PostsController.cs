using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenMindsForum.Models;
using OpenMindsForum.ViewModels;

namespace OpenMindsForum.Controllers
{
    public class PostsController : Controller
    {
        private readonly OpenMindsForumContext _context;

        public PostsController(OpenMindsForumContext context)
        {
            _context = context;
        }

        // GET: Posts/5
        public /*async Task*/ IActionResult Index(int? id)
        {
            //if(ModelState.IsValid)
            //{ 

            //}

            var model = new List<ListPostViewModel>();
            var postlist = _context.Posts.Where(s => s.SubjectId == id).Include(p => p.Subject).Include(y => y.Comments);
            
            if (id==0 || id==null)
            {
                postlist = _context.Posts.Include(p => p.Subject).Include(y => y.Comments);
            }

            foreach (var item in postlist)
            {
                model.Add(new ListPostViewModel
                {
                    postID = item.PostId,
                    title = item.Title,
                    content = item.PostContent,
                    subject = item.Subject.Name,
                    stamp = item.PostStamp,
                    comments = item.Comments.Count()

                });
            }

            return View(model);
        }

        [Route("Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Subject).Include(y => y.Comments)
                .FirstOrDefaultAsync(m => m.PostId == id);

            if (post == null)
            {
                return NotFound();
            }
            var model = new DetailPostCommentsViewModel
            {
                postID= post.PostId,
                title = post.Title,
                content = post.PostContent,
                stamp = post.PostStamp,
                subject = post.Subject.Name,
                comments = post.Comments.ToList(),

            };

            return View(model);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            var model = new CreatePostViewModel();
            var subjects = _context.Subjects;

            foreach (var item in subjects)
            {
                model.subjectList.Add(new SelectListItem
                {
                    Value = Convert.ToString(item.SubjectId),
                    Text = item.Name
                });
            }
            return View(model);
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                var postModel = new Post
                {
                    Title = postViewModel.title,
                    PostContent = postViewModel.content,
                    PostStamp = DateTime.Now,
                    SubjectId = postViewModel.subjectID,
                };
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postViewModel);
        }
    }
}
