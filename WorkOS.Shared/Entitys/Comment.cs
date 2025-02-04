using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.Entitys;

public class Comment
{
    public Comment() { }
    public Comment(string text, int taskId)
    {
        Text = text;
        TaskId = taskId;
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public string Text { get; set; }
    public int TaskId { get; set; }
    public virtual TaskItem Task { get; set; }
    public DateTime CreationDate { get; set; }
}
