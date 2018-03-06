using DellChallenge.Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DellChallange.Repository.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
            .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Password)
            .HasColumnType("varchar(32)")
               .IsRequired();

            builder.HasOne(c => c.Role);
            builder.HasMany(c => c.Clients);
        }
    }
}
