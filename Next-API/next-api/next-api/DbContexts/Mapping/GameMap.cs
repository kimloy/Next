using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using next_api.Entities;

namespace next_api.DbContexts.Mapping
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Game");

            builder.HasKey(g => g.Game_ID);

            builder.HasOne(g => g.Park)
               .WithMany(p => p.Games)
               .HasForeignKey(g => g.Park_ID)
               .IsRequired();

            builder.HasMany<Player>(p => p.Players)
                .WithOne(p => p.Game)
                .HasForeignKey(g => g.Park_ID)
                .IsRequired();

        }
    }
}
