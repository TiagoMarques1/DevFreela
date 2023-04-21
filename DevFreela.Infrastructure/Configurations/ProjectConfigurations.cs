using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .ToTable("tb_Project")
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Freelancer)
                .WithMany(p => p.FreelanceProjects)
                .HasForeignKey(f => f.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Client)
                .WithMany(p => p.OwnedProjects)
                .HasForeignKey(f => f.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
