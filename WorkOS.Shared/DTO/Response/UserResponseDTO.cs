

namespace WorkOS.Shared.DTO.Response;

public class UserResponseDTO
{
    public UserResponseDTO(int id, GroupResponseDTO group, string name, string login, string password, string email, ICollection<TaskItemResponseDTO> tasks, LevelCode level, DateTime creationDate)
    {
        Id = id;
        GroupId = group.Id;
        Group = group;
        Name = name;
        Login = login;
        Email = email;
        Tasks = tasks;
        Level = level;
        CreationDate = creationDate;
    }
    public int Id { get; set; }
    public int GroupId { get; set; }
    public GroupResponseDTO Group { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public ICollection<TaskItemResponseDTO> Tasks { get; set; }
    public LevelCode Level { get; set; }
    public DateTime CreationDate { get; set; }
}