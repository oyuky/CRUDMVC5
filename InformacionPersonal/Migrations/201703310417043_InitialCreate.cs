namespace InformacionPersonal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength:50, nullable: false),
                        ApellidoPaterno = c.String(maxLength:60, nullable:false),
                        ApellidoMaterno = c.String(maxLength:60, nullable:false),
                        CURP = c.String(maxLength:18, nullable:false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Persona");
        }
    }
}
