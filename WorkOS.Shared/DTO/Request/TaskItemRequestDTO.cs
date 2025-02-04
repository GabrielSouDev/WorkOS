using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.DTO.Request;

public class TaskItemRequestDTO
{
    public TaskItemRequestDTO(string title, string description, Priority priority, int authorId)
    {
        Title = title;
        Description = description;
        Priority = priority;
        AuthorId = authorId;
    }
    [Required]
    [StringLength(35, MinimumLength = 5, ErrorMessage = "O Campo Titulo deve contar entre 5 e 35 caracteres!")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "O Campo Descrição deve contar entre 5 e 150 caracteres!")]
    public string Description { get; set; } = string.Empty;
    [Required]
    public Priority Priority { get; set; }
    [Required]
    public int AuthorId { get; set; }
}