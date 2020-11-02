namespace PatrimonioManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProperty_NumeroDoTombo_FromPatrimonio : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Patrimonios", new[] { "NumeroDoTombo" });
            DropColumn("dbo.Patrimonios", "NumeroDoTombo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patrimonios", "NumeroDoTombo", c => c.Int(nullable: false));
            CreateIndex("dbo.Patrimonios", "NumeroDoTombo", unique: true);
        }
    }
}
