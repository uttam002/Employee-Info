using Microsoft.EntityFrameworkCore;

namespace Employee_Info.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
            modelBuilder.Entity<Projects>().HasKey(p => p.P_Id);

            // Configure relationships
            modelBuilder.Entity<Projects>()
                .HasOne(p => p.Employee) // Each project belongs to one employee
                .WithMany()              // Each employee can have multiple projects
                .HasForeignKey(p => p.empId) // Foreign key in Projects referencing Employee
                .IsRequired();           // EmpId is required in Projects

            // Seed initial data if needed
            // modelBuilder.Entity<Employee>().HasData(
            //     new Employee { Id = 1, Name = "John Doe", ... }
            // );

            // modelBuilder.Entity<Projects>().HasData(
            //     new Projects { P_Id = 1, ProjectName = "Project X", ... }
            // );
        }
    }
}
