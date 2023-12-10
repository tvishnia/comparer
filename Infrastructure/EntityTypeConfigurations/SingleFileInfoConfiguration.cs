using ComparerBasic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComparerBasic.Infrastructure.EntityTypeConfigurations;

internal class SingleFileInfoConfiguration : IEntityTypeConfiguration<SingleFileInfo>
{
    public void Configure(EntityTypeBuilder<SingleFileInfo> builder)
    {
        builder.ToTable(nameof(ComparerContext.SingleFileInfos));
        builder.HasKey(entity => entity.Id);
        builder.Property(entity => entity.Id).ValueGeneratedNever();
        builder.Property(entity => entity.FileStatus).HasConversion<string>();
    }
}