using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkOS.Shared.Entitys;

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
        Level = level;
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int GroupId { get; set; }
    public virtual Group Group { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public virtual ICollection<TaskItem> TaskItem { get; set; }
    public LevelCode Level { get; set; }
    public DateTime CreationDate { get; set; }
}

public enum LevelCode
{
    Staff = 0,
    Operator = 1
}