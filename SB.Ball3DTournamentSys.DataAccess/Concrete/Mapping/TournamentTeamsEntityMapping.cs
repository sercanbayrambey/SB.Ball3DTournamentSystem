using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class TournamentTeamsEntityMapping : IEntityTypeConfiguration<TournamentTeamsEntity>
    {
        public void Configure(EntityTypeBuilder<TournamentTeamsEntity> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne(I => I.Tournament).WithMany(I => I.TournamentTeams).HasForeignKey(I => I.TournamentId);
            builder.HasOne(I => I.Team).WithMany(I => I.TournamentTeams).HasForeignKey(I => I.TeamId);
        }
    }
}
