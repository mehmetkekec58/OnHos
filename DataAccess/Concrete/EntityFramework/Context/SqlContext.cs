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
    public class SqlContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OnHos;Trusted_Connection=true");
        }

  
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ProfilePhoto> ProfilePhotos { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageFile> MessageFiles { get; set; }
        public DbSet<HistoryArticle> HistoryArticle{ get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ReadingList> ReadingLists { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<AldigimPaketler> AldigimPaketler { get; set; }
        public DbSet<ArticleLike> articleLikes { get; set; }
        public DbSet<PostLike> postLikes { get; set; }
        public DbSet<Purse> Purses { get; set; }
        public DbSet<Paketler> Paketler { get; set; }
        public DbSet<VideoLike> VideoLikes { get; set; }
        public DbSet<HistoryDoctor> HistoryDoctor { get; set; }
        public DbSet<VisitArticle> VisitArticle { get; set; }
        public DbSet<VisitDoctorProfile> VisitDoctorProfiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleAndTag> ArticleAndTag { get; set; }
        public DbSet<VideoAndTag> VideoAndTag { get; set; }




    }
}
