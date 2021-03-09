using HRM.Core.Entities;
using HRM.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Data
{
    public class HRMDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<HumanResource> HumanResources { get; set; }
        
        public HRMDbContext(DbContextOptions<HRMDbContext> options): base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentEntityTypeConfiguration());
            builder.ApplyConfiguration(new HumanResourceEntityTypeConfiguration());
            base.OnModelCreating(builder);
        }
    }
}