using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(15).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(15).IsRequired();
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.UserName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired();

            

        }
    }
}
