namespace PatrimonioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssociationToMarcaInPatrimonio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nome, unique: true);
            
            CreateTable(
                "dbo.Patrimonios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 255),
                        Descricao = c.String(nullable: false, maxLength: 500),
                        NumeroDoTombo = c.Int(nullable: false),
                        MarcaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .Index(t => t.NumeroDoTombo, unique: true)
                .Index(t => t.MarcaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patrimonios", "MarcaId", "dbo.Marcas");
            DropIndex("dbo.Patrimonios", new[] { "MarcaId" });
            DropIndex("dbo.Patrimonios", new[] { "NumeroDoTombo" });
            DropIndex("dbo.Marcas", new[] { "Nome" });
            DropTable("dbo.Patrimonios");
            DropTable("dbo.Marcas");
        }
    }
}
