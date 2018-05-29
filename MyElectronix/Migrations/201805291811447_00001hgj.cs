namespace MyElectronix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _00001hgj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TestClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.TestClasses", t => t.TestClassId, cascadeDelete: true)
                .Index(t => t.TestClassId);
            
            CreateTable(
                "dbo.TestClasses",
                c => new
                    {
                        TestClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TestClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "TestClassId", "dbo.TestClasses");
            DropIndex("dbo.Students", new[] { "TestClassId" });
            DropTable("dbo.TestClasses");
            DropTable("dbo.Students");
        }
    }
}
