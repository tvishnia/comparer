using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComparerBasic.Infrastructure.EntityTypeConfigurations;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(nameof(ComparerContext.Departments));
        builder.HasKey(entity => entity.Id);
        
        // TODO: replace ValueGeneratedNever to Database generated
        builder.Property(entity => entity.Id).ValueGeneratedNever();
    }
}