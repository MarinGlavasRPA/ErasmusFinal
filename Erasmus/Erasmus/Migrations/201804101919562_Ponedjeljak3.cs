namespace Erasmus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ponedjeljak3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Spol", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Spol", c => c.Int(nullable: false));
        }
    }
}
