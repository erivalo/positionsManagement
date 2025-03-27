using Management.Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Management.Service.Infrastructure.Data.EntityFramework;
internal class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
{
  public void Configure(EntityTypeBuilder<Recruiter> builder)
  {
    builder.HasKey(p => p.Id);

    builder.Property(p => p.Name)
      .IsRequired()
      .HasMaxLength(100);

    builder.HasData(
      new Recruiter
      {
        Id = 1,
        Name = "Maria"
      },
      new Recruiter
      {
        Id = 2,
        Name = "Juana"
      },
      new Recruiter
      {
        Id = 3,
        Name = "Cinthia"
      }
    );
  }
}