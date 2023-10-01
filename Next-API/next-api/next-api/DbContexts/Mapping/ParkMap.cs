using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using next_api.Entities;

namespace next_api.DbContexts.Mapping
{
    public class ParkMap : IEntityTypeConfiguration<Park>
    {
        public void Configure(EntityTypeBuilder<Park> builder)
        {
            builder.ToTable("Park");

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Games)
                .WithOne(p => p.Park)
                .HasPrincipalKey(p => p.Id)
                .IsRequired();

            builder.HasMany(p => p.Players)
                .WithOne(p => p.Park)
                .HasPrincipalKey(p => p.Id)
                .IsRequired();
        }
    }
}
