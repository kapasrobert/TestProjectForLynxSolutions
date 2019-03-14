namespace TestProjectForLynxSolutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
