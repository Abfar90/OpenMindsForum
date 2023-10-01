using OpenMindsForum.Models;
using System.ComponentModel;

namespace OpenMindsForum.ViewModels
{
    public class DetailPostCommentsViewModel
    {
        public int postID { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Content")]
        public string content { get; set; }

        [DisplayName("Subject")]
        public string subject { get; set; }

        [DisplayName("Published")]
        public DateTime stamp { get; set; }

        [DisplayName("Comments")]
        public List<Comment> comments { get; set; }
        public CreateCommentViewModel createComment { get; set; }/* = new CreateCommentViewModel();*/
    }
}

