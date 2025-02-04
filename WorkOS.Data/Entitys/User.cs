using WorkOS.Shared;

namespace WorkOS.Data.Entitys;

public class User
{
    public User() { }
    public User(int groupId, string name, string login, string password, string email, LevelCode level)
    {
        GroupId = groupId;
        Name = name;
        Login = login;
        Password = password;
        Email = email;
        Tasks = new List<TaskItem>();
        Level = level;
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public LevelCode Level { get; set; }
    public virtual ICollection<TaskItem> Tasks { get; set; }
    public DateTime CreationDate { get; set; }
}