using MyFriends.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFriends.Data.Configurations;

namespace MyFriends.Data
{
    public class MyFriendsContext : DbContext
    {
        public DbSet<Friend> Friends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source=MyFriends.db");
        }

        // this one is used to seed the data into the db, probably no need to use it
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FriendConfiguration());
            // modelBuilder.ApplyConfiguration(new FriendConfiguration()).Seed();
        }
    }
}