using Management.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class PositionConfiguration : IEntityTypeConfiguration<Position>
{
  public void Configure(EntityTypeBuilder<Position> builder)
  {
    builder.HasKey(p => p.Id);

    builder.Property(p => p.PositionNumber)
      .IsRequired();

    builder.Property(p => p.Title)
      .IsRequired()
      .HasMaxLength(100);

    builder.Property(p => p.Budget)
      .IsRequired()
      .HasColumnType("decimal(18,4)");

    builder.HasOne(p => p.PositionStatus)
      .WithMany()
      .HasForeignKey(p => p.PositionStatusId);

    builder.HasOne(p => p.Recruiter)
      .WithMany()
      .HasForeignKey(p => p.RecruiterId);

    builder.HasOne(p => p.Department)
      .WithMany()
      .HasForeignKey(p => p.DepartmentId);

    builder.HasData(
      new Position
      {
        Id = 1,
        Title = "Senior Software Engineer",
        Budget = 5000,
        PositionNumber = 1,
        RecruiterId = 1,
        PositionStatusId = 1,
        DepartmentId = 1
      },
      new Position
      {
        Id = 2,
        Title = "Full-Stack Engineer",
        Budget = 5500,
        PositionNumber = 2,
        RecruiterId = 1,
        PositionStatusId = 1,
        DepartmentId = 1,
      },
      new Position
      {
        Id = 3,
        Title = "Solutions Engineer (Shopify)",
        Budget = 4500,
        PositionNumber = 3,
        RecruiterId = 1,
        PositionStatusId = 1,
        DepartmentId = 2,
      }
    );
  }
}