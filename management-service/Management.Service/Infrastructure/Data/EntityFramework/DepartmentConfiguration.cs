using Management.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
  public void Configure(EntityTypeBuilder<Department> builder)
  {
    builder.HasKey(p => p.Id);

    builder.Property(p => p.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.HasData(
      new Department
      {
        Id = 1,
        Name = "Engeneering",
      },
      new Department
      {
        Id = 2,
        Name = "Data",
      },
      new Department
      {
        Id = 3,
        Name = "Operations",
      }
    );
  }
}