using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x=>x.OrderId).UseIdentityColumn();
            builder.Property(x=>x.Price).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Movie).WithMany(x=>x.Orders).HasForeignKey(x=>x.MovieId);
            builder.HasOne(x=>x.Customer).WithMany(x=>x.Orders).HasForeignKey(x => x.CustomerId);
        }
    }
}
