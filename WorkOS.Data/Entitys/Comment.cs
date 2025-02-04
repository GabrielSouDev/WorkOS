namespace WorkOS.Data.Entitys;
public class Comment
{
    public Comment() { }
    public Comment(int taskId, string text)
    {
        TaskId = taskId;
        Text = text;
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int TaskId { get; set; }
    public virtual TaskItem Task { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}
