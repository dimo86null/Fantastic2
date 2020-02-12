using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Fantastic2.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fantastic2.Data
{
    public class Fantastic2Context: DbContext
    {
        public Fantastic2Context() :base("Fantastic2")
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<PlayerStats> PlayerStats { get; set; }
        public DbSet<TeamStats> TeamStats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Game Entity
            modelBuilder.Entity<Game>()
            .HasRequired(t => t.GuestTeam)
            .WithMany(ts => ts.AwayGames)
            .HasForeignKey(g => g.GuestTeamID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
            .HasRequired(t => t.HomeTeam)
            .WithMany(hg => hg.HomeGames)
            .HasForeignKey(h => h.HomeTeamID)
            .WillCascadeOnDelete(false);

            // Profile Entity
            modelBuilder.Entity<Profile>()
                .HasKey(k => k.PlayerID);

            modelBuilder.Entity<Profile>()
                .HasRequired(pl => pl.Player)
                .WithRequiredDependent(pr => pr.Profile);

            // PlayerStats
            modelBuilder.Entity<PlayerStats>()
                .HasKey(ps => new { ps.PlayerID, ps.GameID });

            //TeamStats
            modelBuilder.Entity<TeamStats>()
                .HasKey(ts => new { ts.TeamID, ts.GameID });

        }

      
    }
}