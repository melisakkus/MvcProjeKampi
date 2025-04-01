namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_imagefileclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        ImageFileID = c.Int(nullable: false, identity: true),
                        ImageFileName = c.String(maxLength: 100),
                        ImageFilePath = c.String(),
                    })
                .PrimaryKey(t => t.ImageFileID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
