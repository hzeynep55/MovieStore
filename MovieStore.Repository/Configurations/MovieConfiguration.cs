using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repository.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.MovieId);
            builder.Property(x => x.MovieId).UseIdentityColumn();
            builder.Property(x => x.MovieName).IsRequired().HasMaxLength(125);
            builder.Property(x => x.MovieGenre).IsRequired().HasMaxLength(50);

        }
    }
}
