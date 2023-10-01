using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OpenMindsForum.ViewModels
{
    public class CreateCommentViewModel
    {
        public int postID { get; set; }
        [DisplayName("Title")]
        public string? title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Content")]
        public string content { get; set; }
        public DateTime stamp { get; set; }
    }
}
