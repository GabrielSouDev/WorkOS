using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WorkOS.Shared.Enums;

namespace WorkOS.Shared.DTO.Response;

public class TaskItemResponseDTO
{
    public TaskItemResponseDTO(int id, string title, string description, StatusCode status,PriorityCode priority, int authorId,string author, List<CommentResponseDTO> comments, DateTime creationDate)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        AuthorId = authorId;
        Author = author;
        Comments = comments;
        CreationDate = creationDate;
    }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [JsonConverter(typeof(StringEnumConverter))]
    public StatusCode Status { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public PriorityCode Priority { get; set; }
    public int AuthorId { get; set; }
    public string Author { get; set; }
    public List<CommentResponseDTO> Comments { get; set; }
    public DateTime CreationDate { get; set; }
}