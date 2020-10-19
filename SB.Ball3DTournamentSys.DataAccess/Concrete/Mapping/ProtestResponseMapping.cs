using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class ProtestResponseMapping : IEntityTypeConfiguration<ProtestResponseEntity>
    {
        public void Configure(EntityTypeBuilder<ProtestResponseEntity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Text).HasMaxLength(512);
            builder.HasOne(I => I.Protest).WithMany(I => I.ProtestResponses).HasForeignKey(I => I.ProtestId);
            builder.HasOne(I => I.AppUser).WithMany(I => I.ProtestResponses).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
