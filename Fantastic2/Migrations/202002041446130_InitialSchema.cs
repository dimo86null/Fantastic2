namespace Fantastic2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GuestTeam_ID = c.Int(),
                        HomeTeam_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.GuestTeam_ID)
                .ForeignKey("dbo.Team", t => t.HomeTeam_ID)
                .Index(t => t.GuestTeam_ID)
                .Index(t => t.HomeTeam_ID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProfileID = c.Int(nullable: false),
                        TeamID = c.Int(nullable: false),
                        Profile_PlayerID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Profile", t => t.Profile_PlayerID)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.Profile_PlayerID);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.PlayerID);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        GameID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        DefensiveRebounds = c.Int(nullable: false),
                        OffensiveRebounds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GameID, t.PlayerID })
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.GameID)
                .Index(t => t.PlayerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Stats", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Stats", "GameID", "dbo.Game");
            DropForeignKey("dbo.Player", "Profile_PlayerID", "dbo.Profile");
            DropForeignKey("dbo.Game", "HomeTeam_ID", "dbo.Team");
            DropForeignKey("dbo.Game", "GuestTeam_ID", "dbo.Team");
            DropIndex("dbo.Stats", new[] { "PlayerID" });
            DropIndex("dbo.Stats", new[] { "GameID" });
            DropIndex("dbo.Player", new[] { "Profile_PlayerID" });
            DropIndex("dbo.Player", new[] { "TeamID" });
            DropIndex("dbo.Game", new[] { "HomeTeam_ID" });
            DropIndex("dbo.Game", new[] { "GuestTeam_ID" });
            DropTable("dbo.Stats");
            DropTable("dbo.Profile");
            DropTable("dbo.Player");
            DropTable("dbo.Team");
            DropTable("dbo.Game");
        }
    }
}
