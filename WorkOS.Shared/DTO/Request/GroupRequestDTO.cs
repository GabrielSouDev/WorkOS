using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.DTO.Request;

public class GroupRequestDTO
{
    public GroupRequestDTO(int companyId,string name)
    {
        CompanyId = companyId;
        Name = name;
    }
    [Required]
    public int CompanyId { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "O Campo Nome deve contar entre 3 e 15 caracteres!")]
    public string Name { get; set; }
}
