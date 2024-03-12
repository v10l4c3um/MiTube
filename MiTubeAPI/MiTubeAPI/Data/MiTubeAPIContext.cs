using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiTubeModels;

namespace MiTubeAPI.Data
{
    public class MiTubeAPIContext : DbContext
    {
        public MiTubeAPIContext (DbContextOptions<MiTubeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MiTubeModels.User> User { get; set; } = default!;
        public DbSet<MiTubeModels.UserType> UserType { get; set; } = default!;
        public DbSet<MiTubeModels.PremiumUser> PremiumUser { get; set; } = default!;

        public DbSet<MiTubeModels.Video> Video { get; set; } = default!;
        public DbSet<MiTubeModels.Tag> Tag { get; set; } = default!;
        public DbSet<MiTubeModels.Comment> Comment { get; set; } = default!;
        public DbSet<MiTubeModels.Like> Like { get; set; } = default!;
        public DbSet<MiTubeModels.Playlist>? Playlist { get; set; }
        //public DbSet<MiTubeModels.Subscription> Subscription { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BuildDateFields(modelBuilder);

            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                Id = 1,
                Description = "Registered user",
            });

        }

    }
}
