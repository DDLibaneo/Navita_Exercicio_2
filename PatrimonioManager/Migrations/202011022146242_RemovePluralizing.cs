namespace PatrimonioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePluralizing : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Marcas", newName: "Marca");
            RenameTable(name: "dbo.Patrimonios", newName: "Patrimonio");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Patrimonio", newName: "Patrimonios");
            RenameTable(name: "dbo.Marca", newName: "Marcas");
        }
    }
}
