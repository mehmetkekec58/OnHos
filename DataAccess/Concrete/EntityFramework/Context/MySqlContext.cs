using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class MySqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=;user=;password=;database=";
            var serverVersion = new MySqlServerVersion(new Version(4, 9, 7));
            optionsBuilder.UseMySql(connectionString,serverVersion);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Follow> Follows { get; set; }





    }
}
