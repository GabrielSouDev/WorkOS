using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOS.Shared.Enums;

namespace WorkOS.Data.Entitys;

public class TaskItem
{
    public TaskItem() { }
    public TaskItem(int authorId, string title, string description, PriorityCode priority)
    {
        AuthorId = authorId;
        Title = title;
        Description = description;
        Status = StatusCode.Plan;
        Priority = priority;
        Comments = new List<Comment>();
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public virtual User Author { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public StatusCode Status { get; set; }
    public PriorityCode Priority { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public DateTime CreationDate { get; set; }
}