namespace DayChallengeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    Text = c.String(nullable: false),
                    AuthorId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            CreateTable(
                "dbo.Reply",
                c => new
                {
                    ReplyId = c.Int(nullable: false, identity: true),
                    Text = c.String(nullable: false),
                    AuthorId = c.Guid(nullable: false),
                })
                .PrimaryKey(t => t.ReplyId);
        }
        
        public override void Down()
        {
        }
    }
}
