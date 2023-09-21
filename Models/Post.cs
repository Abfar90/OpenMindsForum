using System;
using System.Collections.Generic;

namespace OpenMindsForum.Models;

public partial class Post
{
    public int PostId { get; set; }

    public string Title { get; set; } = null!;

    public string PostContent { get; set; } = null!;

    public int SubjectId { get; set; }

    public int ThreadId { get; set; }

    public DateTime PostStamp { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Subject Subject { get; set; } = null!;

    public virtual Thread Thread { get; set; } = null!;
}
