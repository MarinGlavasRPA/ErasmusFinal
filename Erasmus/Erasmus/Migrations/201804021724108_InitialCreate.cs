namespace Erasmus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kolegijs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NazivKolegija = c.String(),
                        NositeljKolegija = c.String(),
                        StudentID = c.Int(nullable: false),
                        RBrRoka = c.String(),
                        DatumRoka = c.DateTime(nullable: false),
                        Ocjena = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AkademskaGodina = c.String(),
                        Rok = c.String(),
                        StudijskiProgram = c.String(),
                        PodrucjeStudija = c.String(),
                        PunoImeStudenta = c.String(),
                        DatumRodenja = c.DateTime(nullable: false),
                        Spol = c.String(),
                        MjestoRodenja = c.String(),
                        ZemljaRodenja = c.Int(nullable: false),
                        Nacionalnost = c.String(),
                        OIB = c.String(),
                        SveucilisteInstitucija = c.String(),
                        SkolaOdjel = c.String(),
                        GradStudija = c.String(),
                        ZemljaStudija = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kolegijs", "StudentID", "dbo.Students");
            DropIndex("dbo.Kolegijs", new[] { "StudentID" });
            DropTable("dbo.Students");
            DropTable("dbo.Kolegijs");
        }
    }
}
