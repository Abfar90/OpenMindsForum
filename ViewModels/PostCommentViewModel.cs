
using OpenMindsForum.Models;

namespace OpenMindsForum.ViewModels
{
    public class PostCommentViewModel
    {
        public string title { get; set; } //from the post
        public string content { get; set; } //from the post
        public DateTime stamp { get; set; } //from the post
        public List<Comment> comments { get; set; }
    }
}
