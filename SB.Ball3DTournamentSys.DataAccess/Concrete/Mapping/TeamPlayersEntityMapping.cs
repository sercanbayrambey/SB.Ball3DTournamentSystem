using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class TeamPlayersEntityMapping : IEntityTypeConfiguration<TeamPlayersEntity>
    {
        public void Configure(EntityTypeBuilder<TeamPlayersEntity> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.HasOne(I => I.Team).WithMany(I => I.Players).HasForeignKey(I => I.TeamId);
            builder.HasOne(I => I.AppUser).WithMany(I => I.Teams).HasForeignKey(I => I.AppUserId);
        }
    }
}
