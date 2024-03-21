using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiTubeModels;

namespace MiTube.API.Data
{
    public class MiTubeAPIContext : DbContext
    {
        public MiTubeAPIContext (DbContextOptions<MiTubeAPIContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MiTubeModels.User> User { get; set; } = default!;
        public DbSet<MiTubeModels.UserType> UserType { get; set; } = default!;
        public DbSet<MiTubeModels.PremiumUser> PremiumUser { get; set; } = default!;
        public DbSet<MiTubeModels.Video> Video { get; set; } = default!;
        public DbSet<MiTubeModels.Tag> Tag { get; set; } = default!;
        public DbSet<MiTubeModels.Comment> Comment { get; set; } = default!;
        public DbSet<MiTubeModels.Like> Like { get; set; } = default!;
        public DbSet<MiTubeModels.Playlist>? Playlist { get; set; }
        public DbSet<MiTubeModels.Subscription> Subscription { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //BuildDateFields(modelBuilder);

            modelBuilder.Entity<User>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            //EF to create relations in Database Sunscriber - User - Publisher
            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.ToTable("Subscription");

                entity.HasOne(s => s.Subscriber)
                    .WithMany(u => u.Subscriptions)
                    .HasForeignKey(s => s.SubscriberId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(s => s.Publisher)
                    .WithMany()
                    .HasForeignKey(s => s.PublisherId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //seed initial data
            modelBuilder.Entity<UserType>().HasData(
               new UserType()
               {
                   Id = 1,
                   Description = "Administrator",
               },
               new UserType()
               {
                   Id = 2,
                   Description = "Registered user",
               }
           );

            modelBuilder.Entity<User>().HasData(
               new User()
               {
                   Id = Guid.NewGuid(),
                   UserTypeId = 2,
                   Name = "homer",
                   Email = "maks.alex1@gmail.com",
                   Password = "homer"
               },
                new User()
               {
                   Id = Guid.NewGuid(),
                   UserTypeId = 2,
                   Name = "bart",
                   Email = "maks.alex3@gmail.com",
                   Password = "bart"
               }
           );

            ////MSSQLServer creted users
            ///bart - E3E3A242-5363-456C-B9FE-AA6D2BE4EDA1
            ///homer - FA97D7FA-DE4E-47AA-A140-FC7323C3727F


        }
    }
}
