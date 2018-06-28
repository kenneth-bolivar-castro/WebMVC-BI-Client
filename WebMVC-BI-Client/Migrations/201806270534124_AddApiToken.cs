namespace WebMVC_BI_Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApiToken : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ApiToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ApiToken");
        }
    }
}
