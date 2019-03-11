using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        { }

        public FootballBettingContext(DbContextOptions options) 
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(@"Server=DESKTOP-MFJ6K8M\SQLEXPRESS;Database=StudentSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(e => e.HasKey(ps => new { ps.GameId, ps.PlayerId }));

            modelBuilder.Entity<Team>().HasOne(t => t.PrimaryKitColor).WithMany(c => c.PrimaryKitTeams).HasForeignKey("PrimaryKitColorId").OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Team>().HasOne(t => t.SecondaryKitColor).WithMany(c => c.SecondaryKitTeams).HasForeignKey("SecondaryKitColorId").OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>().HasOne(t => t.Town).WithMany(to => to.Teams);

            modelBuilder.Entity<Game>().HasOne(g => g.HomeTeam).WithMany(t => t.HomeGames).HasForeignKey("HomeTeamId").OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Game>().HasOne(g => g.AwayTeam).WithMany(t => t.AwayGames).HasForeignKey("AwayTeamId").OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Town>().HasOne(t => t.Country).WithMany(c => c.Towns);

            modelBuilder.Entity<Player>().HasOne(p => p.Team).WithMany(t => t.Players);

            modelBuilder.Entity<Player>().HasOne(pl => pl.Position).WithMany(po => po.Players);

            modelBuilder.Entity<PlayerStatistic>().HasOne(ps => ps.Player).WithMany(pl => pl.PlayerStatistics).HasForeignKey("PlayerId");
            modelBuilder.Entity<PlayerStatistic>().HasOne(ps => ps.Game).WithMany(g => g.PlayerStatistics).HasForeignKey("GameId");

            modelBuilder.Entity<Bet>().HasOne(b => b.Game).WithMany(g => g.Bets);

            modelBuilder.Entity<Bet>().HasOne(b => b.User).WithMany(u => u.Bets);
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
