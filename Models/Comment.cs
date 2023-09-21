using System;
using System.Collections.Generic;

namespace OpenMindsForum.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string? Title { get; set; }

    public string Comment1 { get; set; } = null!;

    public int PostId { get; set; }

    public DateTime CommentStamp { get; set; }

    public virtual Post Post { get; set; } = null!;
}
