namespace CaptainMao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LoginCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Experience", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "DateRegistered", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Phone", c => c.String());
            DropColumn("dbo.AspNetUsers", "DateRegistered");
            DropColumn("dbo.AspNetUsers", "Experience");
            DropColumn("dbo.AspNetUsers", "LoginCount");
        }
    }
}
