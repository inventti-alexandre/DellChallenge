using DellChallenge.Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DellChallange.Repository.Mappings
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
            .HasColumnType("varchar(100)")
                .HasMaxLength(8)
                .IsRequired();

          
        }
    }
}
