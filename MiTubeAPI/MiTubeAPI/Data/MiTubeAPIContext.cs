using System;
using System.Collections.Generic;
using System.Linq;
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

        public DbSet<MiTubeModels.Video>? Video { get; set; }
    }
}
