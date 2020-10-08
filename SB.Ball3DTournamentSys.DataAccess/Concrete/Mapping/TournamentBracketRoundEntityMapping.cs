using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class TournamentBracketRoundEntityMapping : IEntityTypeConfiguration<TournamentBracketRoundEntity>
    {

        public void Configure(EntityTypeBuilder<TournamentBracketRoundEntity> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).ValueGeneratedOnAdd();
            builder.HasOne(I => I.Tournament).WithMany(I => I.PlayedGamesRounds).HasForeignKey(I => I.TournamentId);
        }
    }
}
