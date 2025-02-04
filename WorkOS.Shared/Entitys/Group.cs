using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOS.Shared.Entitys;

public class Group
{
    public Group() { }
    public Group(string name)
    {
        Name = name;
        CreationDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public DateTime CreationDate { get; set; }
}
