using Microsoft.EntityFrameworkCore;
using WorkOS.Shared.Entitys;

namespace WorkOS.Shared.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<GroupDTO> Groups { get; set; }
    public DbSet<UserDTO> Users { get; set; }
    public DbSet<TaskItemDTO> Tasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupDTO>().HasMany(g => g.Users)
                    .WithOne(u => u.Group)
                    .HasForeignKey(u => u.GroupId);

        modelBuilder.Entity<UserDTO>().HasMany(u => u.TaskItem)
                    .WithOne(t => t.Author)
                    .HasForeignKey(t => t.AuthorId);

        modelBuilder.Entity<TaskItemDTO>().HasMany(t => t.Comments)
                    .WithOne(c => c.Task)
                    .HasForeignKey(c => c.TaskId);
    }
    public async Task CreateTable()
    {
        await this.Database.MigrateAsync();
        if(!this.Groups.Any(c=>c.Name == "Teste Group"))
        {
            var Group = new Group("Teste");
            await this.Groups.AddAsync((GroupDTO)Group);
            await this.SaveChangesAsync();

            var user = new User(Group.Id ,"TesteUser", "teste", "teste123", "test@email.com", LevelCode.Staff);
            await this.Users.AddAsync(user);
            await this.SaveChangesAsync();

            var task = new TaskItem("Teste Task", "This is a test description.", Priority.Medium, user.Id);
            await this.Tasks.AddAsync(task);
            await this.SaveChangesAsync();

            var comment = new Comment("This is a comment of a user.", task.Id);
            await this.Comments.AddAsync(comment);
            await this.SaveChangesAsync();
        }
    }
}
