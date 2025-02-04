using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkOS.Shared.DTO.Response;

public class TaskItemResponseDTO
{
    public TaskItemResponseDTO(int id, string title, string description, StatusCode status,Priority priority, UserResponseDTO author, ICollection<CommentResponseDTO> comments, DateTime creationDate)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        AuthorId = author.Id;
        Author = author;
        Comments = comments;
        CreationDate = creationDate;
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public StatusCode Status { get; set; }
    public Priority Priority { get; set; }
    public int AuthorId { get; set; }
    public UserResponseDTO Author { get; set; }
    public ICollection<CommentResponseDTO> Comments { get; set; }
    public DateTime CreationDate { get; set; }
}