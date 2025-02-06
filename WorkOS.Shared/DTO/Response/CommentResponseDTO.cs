using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.DTO.Response;

public class CommentResponseDTO
{
    public CommentResponseDTO(int id, string text, int taskId,string task, DateTime creationDate)
    {
        Id = id;
        Text = text;
        TaskId = taskId;
        Task = task;
        CreationDate = creationDate;
    }
    public int Id { get; set; }
    public string Text { get; set; }
    public int TaskId { get; set; }
    public string Task { get; set; }
    public DateTime CreationDate { get; set; }
}
