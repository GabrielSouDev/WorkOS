using System;
using System.Collections.Generic;
using System.Linq;
using WorkOS.Shared.DTO.Response;
namespace WorkOS.Data.Entitys;

public class CompanyResponseDTO
{
    public CompanyResponseDTO(int id, string name, List<GroupResponseDTO> groups, DateTime creationDate)
    {
        Id = id;
        Name = name;
        Groups = groups;
        CreationDate = creationDate;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<GroupResponseDTO> Groups { get; set; }
    public DateTime CreationDate { get; set; }
}
