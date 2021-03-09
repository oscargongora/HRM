using HRM.Core.Entities;
using HRM.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Infrastructure.EntityTypeConfigurations
{
    public class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .Property(e => e.Name)
                .HasMaxLength(ConstantsHelper.SM_STRING_LENGTH);
        }
    }
}