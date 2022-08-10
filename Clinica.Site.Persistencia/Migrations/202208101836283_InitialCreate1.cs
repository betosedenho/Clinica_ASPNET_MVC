namespace Clinica.Site.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropTable("clinica.ConfiguracaoUpload");
            DropTable("clinica.HistoricoEmails");
        }
        
        public override void Down()
        {
            CreateTable(
                "clinica.HistoricoEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Assunto = c.String(nullable: false),
                        Mensagem = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "clinica.ConfiguracaoUpload",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Resize = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
