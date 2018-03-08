
using DellChallenge.Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DellChallange.Repository.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
            .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.LastPurchase)
            .HasColumnType("datetime")
               .IsRequired();


            builder.Property(c => c.Phone)
            .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(c => c.Region)
            .HasColumnType("varchar(10)")
                .HasMaxLength(10)
                .IsRequired();


            builder.HasOne(c => c.Seller);
            builder.HasOne(c => c.Classification);
            builder.HasOne(c => c.Gender);
        }
    }
}
