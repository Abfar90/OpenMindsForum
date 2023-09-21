using System;
using System.Collections.Generic;

namespace OpenMindsForum.Models;

public partial class Thread
{
    public int ThreadId { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
