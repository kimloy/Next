using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using next_api.DbContexts.Mapping;
using next_api.Entities;

namespace next_api.DbContexts
{
    public class NextApiContext : DbContext
    {
        public DbSet<Park> Park { get; set; }

        public DbSet<Open_hours> Open_Hours { get; set; }

        public DbSet<Closing_Hours> Closing_Hours { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<GameDocInfo> GameDocInfos { get; set; }

        public NextApiContext(DbContextOptions<NextApiContext> options)
          : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player()
                {
                    Player_ID = "1",
                    Name = "Paul",
                    Date_Of_Birth = "10/12/1992",
                });

            modelBuilder.Entity<GameDocInfo>().HasData(
                new GameDocInfo()
                {
                    Id = 1,                    
                });

            modelBuilder.Entity<Sport>().HasData(
                new Sport()
                {
                    Sport_ID = "1",
                    GameDocInfo_ID = 1,
                    Name = "Basketball",
                    Max_Num_Players = 12,
                },
                 new Sport()
                 {
                     Sport_ID = "2",
                     GameDocInfo_ID = 1,
                     Name = "Football",
                     Max_Num_Players = 12,
                 },
                  new Sport()
                  {
                      Sport_ID = "3",
                      GameDocInfo_ID = 1,
                      Name = "Soccer",
                      Max_Num_Players = 12,
                  }
                );

            this.ConfigureEntityMaps(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        public void ConfigureEntityMaps(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ParkMap());
            modelBuilder.ApplyConfiguration(new GameMap());
            modelBuilder.ApplyConfiguration(new PlayerMap());
        }
    }
}
