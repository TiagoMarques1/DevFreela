using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
            .ToTable("tb_User")
            .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Skills)
                .WithOne()
                .HasForeignKey(p => p.IdSkill)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
