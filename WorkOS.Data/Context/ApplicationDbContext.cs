using Microsoft.EntityFrameworkCore;
using WorkOS.Data.Entitys;
using WorkOS.Shared;

namespace WorkOS.Data.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Company> Companys { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
                    .HasMany(c => c.Groups)
                    .WithOne(g => g.Company)
                    .HasForeignKey(g => g.CompanyId);

        modelBuilder.Entity<Group>()
                    .HasMany(g => g.Users)
                    .WithOne(u => u.Group)
                    .HasForeignKey(u => u.GroupId);

        modelBuilder.Entity<User>()
                    .HasMany(u => u.Tasks)
                    .WithOne(t => t.Author)
                    .HasForeignKey(t => t.AuthorId);

        modelBuilder.Entity<TaskItem>()
                    .HasMany(t => t.Comments)
                    .WithOne(c => c.Task)
                    .HasForeignKey(c => c.TaskId);
    }
    public async Task CreateTable()
    {
        await this.Database.MigrateAsync();
        if(!this.Companys.Any(c=>c.Name == "Teste Company"))
        {
            var company = new Company("Teste Company");
            await this.Companys.AddAsync(company);

            var Group = new Group(company.Id, "Teste");
            await this.Groups.AddAsync(Group);
            await this.SaveChangesAsync();

            var user = new User(Group.Id ,"TesteUser", "teste", "teste123", "test@email.com", LevelCode.Staff);
            await this.Users.AddAsync(user);
            await this.SaveChangesAsync();

            var task = new TaskItem(user.Id, "Teste Task", "This is a test description.", Priority.Medium);
            await this.Tasks.AddAsync(task);
            await this.SaveChangesAsync();

            var comment = new Comment(task.Id, "This is a comment of a user.");
            await this.Comments.AddAsync(comment);
            await this.SaveChangesAsync();
        }
    }
}
