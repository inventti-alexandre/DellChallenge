using DellChallenge.Domain.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DellChallange.Repository.Mappings
{
    public class ClassificationMap : IEntityTypeConfiguration<Classification>
    {
        public void Configure(EntityTypeBuilder<Classification> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
            .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

          
        }
    }
}
