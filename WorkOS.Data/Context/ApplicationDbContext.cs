using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
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

        // Gerando as companies
        var company1 = new Company("TechCorp") { Id = 1 };
        var company2 = new Company("DevSolutions") { Id = 2 };
        var company3 = new Company("CreativeX") { Id = 3 };
        modelBuilder.Entity<Company>().HasData(company1, company2, company3);

        // Gerando os groups
        var group1_1 = new Group(company1.Id, "Dev Team") { Id = 1 };
        var group1_2 = new Group(company1.Id, "Marketing Team") { Id = 2 };
        var group1_3 = new Group(company1.Id, "HR Team") { Id = 3 };

        var group2_1 = new Group(company2.Id, "Engineering Team") { Id = 4 };
        var group2_2 = new Group(company2.Id, "Design Team") { Id = 5 };

        var group3_1 = new Group(company3.Id, "Product Team") { Id = 6 };
        var group3_2 = new Group(company3.Id, "Support Team") { Id = 7 };

        modelBuilder.Entity<Group>().HasData(group1_1, group1_2, group1_3, group2_1, group2_2, group3_1, group3_2);

        // Gerando os users para cada group
        var user1_1 = new User(group1_1.Id, "Alice Smith", "alice", "password123", "alice@techcorp.com", LevelCode.Manager) { Id = 1 };
        var user1_2 = new User(group1_1.Id, "Bob Johnson", "bob", "password123", "bob@techcorp.com", LevelCode.Staff) { Id = 2 };
        var user1_3 = new User(group1_2.Id, "Charlie Davis", "charlie", "password123", "charlie@techcorp.com", LevelCode.Manager) { Id = 3 };
        var user1_4 = new User(group1_3.Id, "Diana Lee", "diana", "password123", "diana@techcorp.com", LevelCode.Staff) { Id = 4 };

        var user2_1 = new User(group2_1.Id, "Ethan White", "ethan", "password123", "ethan@devsolutions.com", LevelCode.Staff) { Id = 5 };
        var user2_2 = new User(group2_1.Id, "Fiona Brown", "fiona", "password123", "fiona@devsolutions.com", LevelCode.Manager) { Id = 6 };

        var user3_1 = new User(group3_1.Id, "Grace Harris", "grace", "password123", "grace@creativex.com", LevelCode.Staff) { Id = 7 };
        var user3_2 = new User(group3_1.Id, "Henry Clark", "henry", "password123", "henry@creativex.com", LevelCode.Staff) { Id = 8 };

        modelBuilder.Entity<User>().HasData(user1_1, user1_2, user1_3, user1_4, user2_1, user2_2, user3_1, user3_2);

        // Gerando as tasks para cada user
        var task1_1 = new TaskItem(user1_1.Id, "Project Planning", "Plan the next phase of the project", Priority.High) { Id = 1 };
        var task1_2 = new TaskItem(user1_1.Id, "Budget Review", "Review the budget for the new quarter", Priority.Medium) { Id = 2, Status = StatusCode.Started };
        var task1_3 = new TaskItem(user1_2.Id, "SEO Strategy", "Develop a strategy for SEO", Priority.Medium) { Id = 3 };

        var task2_1 = new TaskItem(user2_1.Id, "Software Development", "Develop the new features for the app", Priority.High) { Id = 4, Status = StatusCode.Completed };
        var task2_2 = new TaskItem(user2_2.Id, "Design Mockups", "Create mockups for the new UI design", Priority.Low) { Id = 5 };

        var task3_1 = new TaskItem(user3_1.Id, "Product Testing", "Test the new features in the product", Priority.Medium) { Id = 6 };
        var task3_2 = new TaskItem(user3_2.Id, "Customer Support", "Respond to customer inquiries", Priority.Low) { Id = 7 };

        modelBuilder.Entity<TaskItem>().HasData(task1_1, task1_2, task1_3, task2_1, task2_2, task3_1, task3_2);

        // Gerando os comments para as tasks
        var comment1_1 = new Comment(task1_1.Id, "We need to discuss the timeline for this project.") { Id = 1 };
        var comment1_2 = new Comment(task1_2.Id, "I suggest cutting some costs from marketing.") { Id = 2 };
        var comment2_1 = new Comment(task2_1.Id, "The app features are almost ready for testing.") { Id = 3 };

        modelBuilder.Entity<Comment>().HasData(comment1_1, comment1_2, comment2_1);

    }

    public async Task CreateTable()
    {
        await this.Database.MigrateAsync();
        if(!this.Companys.Any(c=>c.Name == "Teste Company"))
        {
            var company = new Company("Teste Company");
            await this.Companys.AddAsync(company);
            await this.SaveChangesAsync();

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
