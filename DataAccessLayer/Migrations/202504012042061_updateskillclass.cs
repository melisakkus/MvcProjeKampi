namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateskillclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "AboutMe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "AboutMe", c => c.String());
        }
    }
}
