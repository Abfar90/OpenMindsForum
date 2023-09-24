
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using OpenMindsForum.Models;
using System.ComponentModel;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace OpenMindsForum.ViewModels
{
    public class CreatePostViewModel
    {
        [DisplayName("Title")]
        [Required(ErrorMessage = "This field is required")]
        public string title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Content")]
        public string content { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Subject")]
        public int subjectID { get; set; }
        public List<SelectListItem> subjectList { get; set; } = new List<SelectListItem>();
        public DateTime stamp { get; set; }
    }
}
