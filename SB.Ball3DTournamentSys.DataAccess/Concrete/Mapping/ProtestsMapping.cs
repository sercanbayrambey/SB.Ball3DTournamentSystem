using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class ProtestsMapping : IEntityTypeConfiguration<ProtestEntity>
    {
        public void Configure(EntityTypeBuilder<ProtestEntity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Text).HasMaxLength(512);
            builder.Property(I => I.Title).HasMaxLength(64);
            builder.HasOne(I => I.PlayedGame).WithMany(I => I.Protests).HasForeignKey(I => I.PlayedGameId);
            builder.HasOne(I => I.AppUser).WithMany(I => I.Protests).HasForeignKey(I => I.AppUserId);

        }
    }
}
