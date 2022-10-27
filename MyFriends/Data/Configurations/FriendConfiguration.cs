using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFriends.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyFriends.Data.Configurations
{
    public class FriendConfiguration : IEntityTypeConfiguration<Friend>
    {
             public void Configure(EntityTypeBuilder<Friend> builder)
        {
            // Fluent API can be used here to specify additional requirements on entities
            builder.Property(p => p.Age).HasColumnName("Age");
        }
    }
}