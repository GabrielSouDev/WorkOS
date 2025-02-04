using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.DTO.Request;

public class CommentRequestDTO
{
    public CommentRequestDTO(string text, int taskId)
    {
        Text = text;
        TaskId = taskId;
    }
    [Required]
    [StringLength(150, MinimumLength = 3, ErrorMessage = "O Campo Commentario deve contar entre 3 e 150 caracteres!")]
    public string Text { get; set; }
    [Required]
    public int TaskId { get; set; }
}
