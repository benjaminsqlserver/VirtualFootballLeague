using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using VirtualLeague.Models.ConData;

namespace VirtualLeague.Data
{
  public partial class ConDataContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public ConDataContext(DbContextOptions<ConDataContext> options):base(options)
    {
    }

    public ConDataContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.LeagueSeason)
              .WithMany(i => i.VirtualLeagueResults)
              .HasForeignKey(i => i.SeasonID)
              .HasPrincipalKey(i => i.SeasonID);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.MatchDay)
              .WithMany(i => i.VirtualLeagueResults)
              .HasForeignKey(i => i.MatchDayID)
              .HasPrincipalKey(i => i.MatchDayID);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.Team)
              .WithMany(i => i.VirtualLeagueResults)
              .HasForeignKey(i => i.HomeTeamID)
              .HasPrincipalKey(i => i.TeamID);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.Team1)
              .WithMany(i => i.VirtualLeagueResults1)
              .HasForeignKey(i => i.AwayTeamID)
              .HasPrincipalKey(i => i.TeamID);


        builder.Entity<VirtualLeague.Models.ConData.FixtureTemplate>()
              .Property(p => p.TemplateID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.LeagueSeason>()
              .Property(p => p.SeasonID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.MatchDay>()
              .Property(p => p.MatchDayID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.Team>()
              .Property(p => p.TeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.RecordID)
              .HasPrecision(19, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.SeasonID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.MatchDayID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.HomeTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.HomeScore)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.AwayTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.AwayScore)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<VirtualLeague.Models.ConData.FixtureTemplate> FixtureTemplates
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.LeagueSeason> LeagueSeasons
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.MatchDay> MatchDays
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.Team> Teams
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.VirtualLeagueResult> VirtualLeagueResults
    {
      get;
      set;
    }
  }
}
