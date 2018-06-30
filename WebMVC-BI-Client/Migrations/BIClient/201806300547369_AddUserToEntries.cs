namespace WebMVC_BI_Client.Migrations.BIClient
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToEntries : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Entries", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Entries", "User_Id");
            AddForeignKey("dbo.Entries", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Entries", new[] { "User_Id" });
            DropColumn("dbo.Entries", "User_Id");
            //DropTable("dbo.AspNetUsers");
        }
    }
}
