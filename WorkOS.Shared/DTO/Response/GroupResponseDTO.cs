using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.DTO.Response;

public class GroupResponseDTO
{
    public GroupResponseDTO(int id, string name, ICollection<UserResponseDTO> users, DateTime creationDate)
    {
        Id = id;
        Name = name;
        Users = users;
        CreationDate = creationDate;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserResponseDTO> Users { get; set; }
    public DateTime CreationDate { get; set; }
}
