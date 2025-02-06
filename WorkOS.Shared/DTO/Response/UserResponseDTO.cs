using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorkOS.Shared.DTO.Response;

public class UserResponseDTO
{
    public UserResponseDTO(int id, int groupId, string group, string name, string login, string password, string email, List<TaskItemResponseDTO> tasks, LevelCode level, DateTime creationDate)
    {
        Id = id;
        GroupId = groupId;
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
    public string Group { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public List<TaskItemResponseDTO> Tasks { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public LevelCode Level { get; set; }
    public DateTime CreationDate { get; set; }
}