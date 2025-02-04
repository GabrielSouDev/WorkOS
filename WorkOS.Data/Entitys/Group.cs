namespace WorkOS.Data.Entitys;

public class Group
{
    public Group() { }
    public Group(int companyId, string name)
    {
        CompanyId = companyId;
        Name = name;
        Users = new List<User>();
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<User> Users { get; set; }
    public DateTime CreationDate { get; set; }
}
