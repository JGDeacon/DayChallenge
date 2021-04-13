namespace DayChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reply", "CommentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "PostID");
            CreateIndex("dbo.Reply", "CommentID");
            AddForeignKey("dbo.Comment", "PostID", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "CommentID", "dbo.Comment", "CommentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reply", "CommentID", "dbo.Comment");
            DropForeignKey("dbo.Comment", "PostID", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "CommentID" });
            DropIndex("dbo.Comment", new[] { "PostID" });
            DropColumn("dbo.Reply", "CommentID");
        }
    }
}
