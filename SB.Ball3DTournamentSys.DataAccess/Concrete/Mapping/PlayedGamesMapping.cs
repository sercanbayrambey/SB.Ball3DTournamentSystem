using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class PlayedGamesMapping : IEntityTypeConfiguration<PlayedGamesEntity>
    {
        public void Configure(EntityTypeBuilder<PlayedGamesEntity> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne(I => I.HomeTeam).WithMany(I => I.HomeTeams).HasForeignKey(I => I.HomeTeamId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(I => I.AwayTeam).WithMany(I => I.AwayTeams).HasForeignKey(I => I.AwayTeamId).OnDelete(DeleteBehavior.NoAction);
            /*builder.HasOne(I => I.Tournament).WithMany(I => I.PlayedGames).HasForeignKey(I => I.TournamentId);*/
            builder.HasOne(I => I.PlayedGamesRound).WithMany(I => I.PlayedGames).HasForeignKey(I => I.RoundId);
        }
    }
}
