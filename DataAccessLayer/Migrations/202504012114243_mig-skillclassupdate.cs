namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migskillclassupdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "GithubName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "GithubName", c => c.String());
        }
    }
}
