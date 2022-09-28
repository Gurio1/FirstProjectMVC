using AnimeWebSite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeWebSite.Infrastructure.EntityTypeConfigurations
{
    internal sealed class CommentsConfiguration : IEntityTypeConfiguration<AnimeComment>
    {

        public void Configure(EntityTypeBuilder<AnimeComment> builder)
        {
            builder.ToTable("AnimeComments");

            builder.Property(x =>x.Id).HasColumnName("id").ValueGeneratedOnAdd();


            builder.HasOne(t => t.Anime)
                   .WithMany(t => t.Comments)
                   .HasForeignKey(t =>t.AnimeId);

            builder.HasOne(t => t.User)
                   .WithMany()
                   .HasForeignKey(t =>t.UserId);
                        
        }
    }
}
