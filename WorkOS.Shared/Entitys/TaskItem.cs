using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.Entitys;

public class TaskItem
{
    public TaskItem() { }
    public TaskItem(string title, string description, Priority priority, int authorId)
    {
        Title = title;
        Description = description;
        Status = StatusCode.Plan;
        Priority = priority;
        AuthorId = authorId;
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public StatusCode Status { get; set; }
    public Priority Priority { get; set; }
    public int AuthorId { get; set; }
    public virtual User Author { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public DateTime CreationDate { get; set; }
}
public enum Priority
{
    Low = 0,
    Medium = 1,
    High = 2
}

public enum StatusCode
{
    Plan = 0,
    Started = 1,
    Completed = 2
}