using System;
using System.Collections.Generic;
using System.Linq;
namespace WorkOS.Data.Entitys;

public class Company
{
    public Company() { }
    public Company(string name)
    {
        Name = name;
        Groups = new List<Group>();
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual ICollection<Group> Groups { get; set; }
    public DateTime CreationDate { get; set; }
}
