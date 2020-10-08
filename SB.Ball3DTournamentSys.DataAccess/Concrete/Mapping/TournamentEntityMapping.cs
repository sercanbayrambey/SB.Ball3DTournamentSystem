using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class TournamentEntityMapping : IEntityTypeConfiguration<TournamentEntity>
    {
        public void Configure(EntityTypeBuilder<TournamentEntity> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasOne(I => I.Stadium).WithMany(I => I.Tournaments).HasForeignKey(I => I.StadiumId);

            builder.HasOne(I => I.GameServer).WithMany(I => I.Tournaments).HasForeignKey(I => I.GameServerId);
            

        }
    }
}
