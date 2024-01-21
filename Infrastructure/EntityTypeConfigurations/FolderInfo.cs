using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComparerBasic.Infrastructure.EntityTypeConfigurations;

internal class FolderInfoConfiguration : IEntityTypeConfiguration<FolderInfo>
{
    public void Configure(EntityTypeBuilder<FolderInfo> builder)
    {
        builder.ToTable(nameof(ComparerContext.FolderInfos));
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedNever();
        builder.Property(entity => entity.FolderStatus).HasConversion<string>();
    }
}