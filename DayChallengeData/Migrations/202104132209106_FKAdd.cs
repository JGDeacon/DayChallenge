namespace DayChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "Id", c => c.Int(nullable: false));
            AddColumn("dbo.Reply", "CommentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "Text", c => c.String(nullable: false));
            CreateIndex("dbo.Comment", "Id");
            CreateIndex("dbo.Reply", "CommentID");
            AddForeignKey("dbo.Comment", "Id", "dbo.Post", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reply", "CommentID", "dbo.Comment", "CommentID", cascadeDelete: true);
            DropColumn("dbo.Comment", "PostID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "PostID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reply", "CommentID", "dbo.Comment");
            DropForeignKey("dbo.Comment", "Id", "dbo.Post");
            DropIndex("dbo.Reply", new[] { "CommentID" });
            DropIndex("dbo.Comment", new[] { "Id" });
            AlterColumn("dbo.Comment", "Text", c => c.String());
            DropColumn("dbo.Reply", "CommentID");
            DropColumn("dbo.Comment", "Id");
        }
    }
}
