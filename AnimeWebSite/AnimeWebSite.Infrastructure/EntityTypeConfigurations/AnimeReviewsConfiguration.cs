using AnimeWebSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeWebSite.Infrastructure.EntityTypeConfigurations
{
    internal sealed class AnimeReviewsConfiguration : IEntityTypeConfiguration<AnimeReviews>
    {
        public void Configure(EntityTypeBuilder<AnimeReviews> builder)
        {
            builder.ToTable("AnimeReviews");

            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();


            builder.HasOne(t => t.Anime)
                   .WithMany(t => t.Reviews)
                   .HasForeignKey(t => t.AnimeId);

            builder.HasOne(t => t.User)
                   .WithMany()
                   .HasForeignKey(t => t.UserId);
        }
    }
}
