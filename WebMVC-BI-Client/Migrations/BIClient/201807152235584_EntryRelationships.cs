namespace WebMVC_BI_Client.Migrations.BIClient
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntryRelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Entries", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Entries", new[] { "User_Id" });
            RenameColumn(table: "dbo.Entries", name: "Client_Id", newName: "ClientId");
            RenameColumn(table: "dbo.Entries", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Entries", name: "IX_Client_Id", newName: "IX_ClientId");
            AlterColumn("dbo.Entries", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Entries", "UserId");
            AddForeignKey("dbo.Entries", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Entries", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Entries", new[] { "UserId" });
            AlterColumn("dbo.Entries", "UserId", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.Entries", name: "IX_ClientId", newName: "IX_Client_Id");
            RenameColumn(table: "dbo.Entries", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Entries", name: "ClientId", newName: "Client_Id");
            CreateIndex("dbo.Entries", "User_Id");
            AddForeignKey("dbo.Entries", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
