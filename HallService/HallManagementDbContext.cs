using HallService.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HallService
{
    public class HallManagementDbContext : DbContext
    {
        public DbSet<ArcadeHall> Halls { get; set; }

        public HallManagementDbContext(DbContextOptions<HallManagementDbContext> options) : base(options)
        {
            
        }
    }
}
