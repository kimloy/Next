using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using next_api.Entities;

namespace next_api.DbContexts.Mapping
{
    public class PlayerMap : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player");

            builder.HasKey(p => p.Player_ID);

            builder.HasOne<Park>(p => p.Park)
                .WithMany(p => p.Players)             
                .HasForeignKey(p => p.Park_ID)
                .IsRequired(false);

            builder.HasOne<Game>(p => p.Game)
                .WithMany(g => g.Players)
                .HasForeignKey(p => p.Game_ID)
                .IsRequired(false);


        }
    }
}
