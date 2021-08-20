namespace PruebaTrabajo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Nit = c.Int(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.proyectos",
                c => new
                    {
                        IdProyecto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProyecto)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa, cascadeDelete: true)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.HistoriaUsuario",
                c => new
                    {
                        IdHistoriaUsuario = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdProyecto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdHistoriaUsuario)
                .ForeignKey("dbo.proyectos", t => t.IdProyecto, cascadeDelete: true)
                .Index(t => t.IdProyecto);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        IdTickets = c.Int(nullable: false),
                        Comentarios = c.String(),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.IdTickets)
                .ForeignKey("dbo.HistoriaUsuario", t => t.IdTickets)
                .Index(t => t.IdTickets);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "IdTickets", "dbo.HistoriaUsuario");
            DropForeignKey("dbo.HistoriaUsuario", "IdProyecto", "dbo.proyectos");
            DropForeignKey("dbo.proyectos", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Roles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Roles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Ticket", new[] { "IdTickets" });
            DropIndex("dbo.HistoriaUsuario", new[] { "IdProyecto" });
            DropIndex("dbo.proyectos", new[] { "IdEmpresa" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Roles", new[] { "RoleId" });
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Ticket");
            DropTable("dbo.HistoriaUsuario");
            DropTable("dbo.proyectos");
            DropTable("dbo.Empresa");
            DropTable("dbo.UserRoles");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
