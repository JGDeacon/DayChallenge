//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DayChallengeData
//{
//    public class DayChallengeDBContext : DbContext
//    {
//        public DayChallengeDBContext() :base("DefaultConnection")
//        {

//        }
//        public static DayChallengeDBContext Create()
//        {
//            return new DayChallengeDBContext();
//        }
//        public DbSet<Comment> Comments { get; set; }
//        public DbSet<Post> Posts { get; set; }
//        public DbSet<Reply> Replies { get; set; }
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();           

//        }
//    }
//}
