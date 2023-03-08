using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SocialMedia.Repository.Entities;

namespace SocialMedia.Repository.EF.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<MasterCategory> MasterCategory { get; set; }
        public DbSet<MasterSubCategory> MasterSubCategory { get; set; }
        public DbSet<MasterPrice> MasterPrice { get; set; }
        public DbSet<MasterFeatures> MasterFeature { get; set; }
    }
}
