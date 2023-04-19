using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class ProjectCommentConfiguration : IEntityTypeConfiguration<ProjectComment>
    {
        public void Configure(EntityTypeBuilder<ProjectComment> builder)
        {
            builder
               .ToTable("tb_ProjectComment")
            .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Project)
                .WithMany(p => p.Comments)
                .HasForeignKey(f => f.IdProject)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(x => x.User)
                 .WithMany(p => p.Comments)
                 .HasForeignKey(f => f.IdUser)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
