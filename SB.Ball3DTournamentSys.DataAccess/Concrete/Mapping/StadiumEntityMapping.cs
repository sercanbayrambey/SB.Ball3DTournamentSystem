﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping
{
    public class StadiumEntityMapping : IEntityTypeConfiguration<StadiumEntity>
    {
        public void Configure(EntityTypeBuilder<StadiumEntity> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();
        }
    }
}
