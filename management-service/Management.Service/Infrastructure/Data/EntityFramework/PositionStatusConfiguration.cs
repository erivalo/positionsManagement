using Management.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class PositionStatusConfiguration : IEntityTypeConfiguration<PositionStatus>
{
  public void Configure(EntityTypeBuilder<PositionStatus> builder)
  {
    builder.HasKey(p => p.Id);

    builder.Property(p => p.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.HasData(
      new PositionStatus
      {
        Id = 1,
        Name = "Pending"
      },
      new PositionStatus
      {
        Id = 2,
        Name = "Completed",
      },
      new PositionStatus
      {
        Id = 3,
        Name = "Closed",
      }
    );
  }
}