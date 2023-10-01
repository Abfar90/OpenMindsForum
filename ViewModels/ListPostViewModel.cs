using OpenMindsForum.Models;
using System.ComponentModel;

namespace OpenMindsForum.ViewModels
{
    public class ListPostViewModel
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
        public int comments { get; set; }
    }
}
