using Microsoft.EntityFrameworkCore;
using SB.Ball3DTournamentSys.DataAccess.Concrete.Mapping;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.DataAccess.Concrete.Contexts
{
    public class B3DTContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SERCAN\MSSQLSERVER01;Database=SB.B3DTournamentSystem;Integrated Security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TournamentEntityMapping());
            modelBuilder.ApplyConfiguration(new GameServerEntityMapping());
            modelBuilder.ApplyConfiguration(new PlayedGamesMapping());
            modelBuilder.ApplyConfiguration(new StadiumEntityMapping());
            modelBuilder.ApplyConfiguration(new TeamEntityMapping());
            modelBuilder.ApplyConfiguration(new TeamPlayersEntityMapping());
            modelBuilder.ApplyConfiguration(new TournamentTeamsEntityMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<GameServerEntity> GameServers{ get; set; }
        public DbSet<PlayedGamesEntity> PlayedGames { get; set; }
        public DbSet<StadiumEntity> Stadiums { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<TeamPlayersEntity> TeamPlayers { get; set; }
        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<TournamentTeamsEntity> TournamentTeams { get; set; }


    }
}
