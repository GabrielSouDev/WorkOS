using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkOS.Shared.Enums;

namespace WorkOS.Shared.DTO.Request;

public class UserRequestDTO
{
    public UserRequestDTO(int groupId, string name, string login, string password, string email, LevelCode level)
    {
        GroupId = groupId;
        Name = name;
        Login = login;
        Password = password;
        Email = email;
        Level = level;
    }
    [Required(ErrorMessage = "O campo Grupo é obrigatorio!")]
    public int GroupId { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatorio!")]
    [StringLength(35, MinimumLength = 3, ErrorMessage = "O Campo Nome deve contar entre 3 e 35 caracteres!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo Login é obrigatorio!")]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "O Campo Login deve contar entre 5 e 15 caracteres!")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatorio!")]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "O Campo Senha deve contar entre 5 e 15 caracteres!")]
    public string Password { get; set; }

    [Required(ErrorMessage = "O campo E-mail é obrigatorio!")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public LevelCode Level { get; set; }
}