using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configuration
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Subject).HasMaxLength(30);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Subject).IsRequired();

            builder.HasMany(b => b.BlogCategory).WithOne(cb => cb.Blog).HasForeignKey(x => x.BlogId).OnDelete(DeleteBehavior.Restrict);
            

        }
    }
}
