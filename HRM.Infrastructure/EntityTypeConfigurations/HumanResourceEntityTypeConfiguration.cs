using HRM.Core.Entities;
using HRM.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Infrastructure.EntityTypeConfigurations
{
    public class HumanResourceEntityTypeConfiguration: IEntityTypeConfiguration<HumanResource>
    {
        public void Configure(EntityTypeBuilder<HumanResource> builder)
        {
            builder
                .Property(e => e.FirstName)
                .HasMaxLength(ConstantsHelper.SM_STRING_LENGTH)
                .IsRequired();
            
            builder
                .Property(e => e.LastName)
                .HasMaxLength(ConstantsHelper.SM_STRING_LENGTH)
                .IsRequired();
            
            builder
                .Property(e => e.Email)
                .HasMaxLength(ConstantsHelper.LG_STRING_LENGTH)
                .IsRequired();
            
            builder
                .Property(e => e.EmployeeNumber)
                .HasMaxLength(ConstantsHelper.SM_STRING_LENGTH)
                .IsRequired();
        }
    }
}