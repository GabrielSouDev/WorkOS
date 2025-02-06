using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WorkOS.Shared.DTO.Request;
namespace WorkOS.Data.Entitys;

public class CompanyRequestDTO
{
    public CompanyRequestDTO(string name)
    {
        Name = name;
    }
    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "O Campo Nome deve contar entre 3 e 15 caracteres!")]
    public string Name { get; set; } = string.Empty;
}
