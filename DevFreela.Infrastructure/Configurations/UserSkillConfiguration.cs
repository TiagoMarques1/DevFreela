﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Configurations
{
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder
                .ToTable("tb_UserSkill")
                .HasKey(x => x.Id);
        }
    }
}
