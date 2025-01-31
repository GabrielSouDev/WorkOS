using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOS.Shared.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WorkOS.Shared.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>().HasMany(g => g.Users)
                    .WithOne(u => u.Group)
                    .HasForeignKey(u => u.GroupId);

        modelBuilder.Entity<User>().HasMany(u => u.TaskItem)
                    .WithOne(t => t.Author)
                    .HasForeignKey(t => t.AuthorId);

    }
    public async Task CreateTable()
    {
        await this.Database.MigrateAsync();
        if(!this.Groups.Any(c=>c.Name == "Teste"))
        {
            var Group = new Group("Teste");
            await this.Groups.AddAsync(Group);
            await this.SaveChangesAsync();
        }
    }
}
