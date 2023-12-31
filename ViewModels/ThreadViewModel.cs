﻿using OpenMindsForum.Models;
using System.ComponentModel;

namespace OpenMindsForum.ViewModels
{
    public class ThreadViewModel
    {
        public int subjectId { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Content")]
        public string content { get; set; }

        [DisplayName("Posted")]
        public DateTime stamp { get; set; }
        public List<Comment> postComments { get; set; }

    }
}
