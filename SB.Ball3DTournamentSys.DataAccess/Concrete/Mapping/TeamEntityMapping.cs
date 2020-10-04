using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class TeamEntityMapping : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne(I => I.AppUser).WithMany(I => I.OwnedTeams).HasForeignKey(I => I.AppUserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
