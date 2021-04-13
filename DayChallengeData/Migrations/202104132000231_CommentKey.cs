namespace DayChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comment", "PostID");
            AddForeignKey("dbo.Comment", "PostID", "dbo.Post", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropIndex("dbo.Comment", new[] { "PostID" });
        }
    }
}
