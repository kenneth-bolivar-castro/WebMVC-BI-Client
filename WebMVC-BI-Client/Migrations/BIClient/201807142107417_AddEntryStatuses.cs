namespace WebMVC_BI_Client.Migrations.BIClient
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntryStatuses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entries", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entries", "Status");
        }
    }
}
