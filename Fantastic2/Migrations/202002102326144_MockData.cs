namespace Fantastic2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MockData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HomeTeamID = c.Int(nullable: false),
                        GuestTeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.GuestTeamID)
                .ForeignKey("dbo.Team", t => t.HomeTeamID)
                .Index(t => t.HomeTeamID)
                .Index(t => t.GuestTeamID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        TeamID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.PlayerStats",
                c => new
                    {
                        PlayerID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        TwoPointMade = c.Int(nullable: false),
                        TwoPointAttempted = c.Int(nullable: false),
                        ThreePointMade = c.Int(nullable: false),
                        ThreePointAttempted = c.Int(nullable: false),
                        FreeThrowMade = c.Int(nullable: false),
                        FreeThrowAttempted = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        DefensiveRebounds = c.Int(nullable: false),
                        OffensiveRebounds = c.Int(nullable: false),
                        Steals = c.Int(nullable: false),
                        Turnovers = c.Int(nullable: false),
                        BlocksMade = c.Int(nullable: false),
                        BlocksReceived = c.Int(nullable: false),
                        FoulsMade = c.Int(nullable: false),
                        FoulsReceived = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PlayerID, t.GameID })
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .Index(t => t.PlayerID)
                .Index(t => t.GameID);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        PlayerID = c.Int(nullable: false),
                        Country = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Player", t => t.PlayerID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.TeamStats",
                c => new
                    {
                        TeamID = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                        TwoPointMade = c.Int(nullable: false),
                        TwoPointAttempted = c.Int(nullable: false),
                        ThreePointMade = c.Int(nullable: false),
                        ThreePointAttempted = c.Int(nullable: false),
                        FreeThrowMade = c.Int(nullable: false),
                        FreeThrowAttempted = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        DefensiveRebounds = c.Int(nullable: false),
                        OffensiveRebounds = c.Int(nullable: false),
                        Steals = c.Int(nullable: false),
                        Turnovers = c.Int(nullable: false),
                        BlocksMade = c.Int(nullable: false),
                        BlocksReceived = c.Int(nullable: false),
                        FoulsMade = c.Int(nullable: false),
                        FoulsReceived = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TeamID, t.GameID })
                .ForeignKey("dbo.Game", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamID, cascadeDelete: true)
                .Index(t => t.TeamID)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamStats", "TeamID", "dbo.Team");
            DropForeignKey("dbo.TeamStats", "GameID", "dbo.Game");
            DropForeignKey("dbo.Game", "HomeTeamID", "dbo.Team");
            DropForeignKey("dbo.Game", "GuestTeamID", "dbo.Team");
            DropForeignKey("dbo.Player", "TeamID", "dbo.Team");
            DropForeignKey("dbo.Profile", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.PlayerStats", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.PlayerStats", "GameID", "dbo.Game");
            DropIndex("dbo.TeamStats", new[] { "GameID" });
            DropIndex("dbo.TeamStats", new[] { "TeamID" });
            DropIndex("dbo.Profile", new[] { "PlayerID" });
            DropIndex("dbo.PlayerStats", new[] { "GameID" });
            DropIndex("dbo.PlayerStats", new[] { "PlayerID" });
            DropIndex("dbo.Player", new[] { "TeamID" });
            DropIndex("dbo.Game", new[] { "GuestTeamID" });
            DropIndex("dbo.Game", new[] { "HomeTeamID" });
            DropTable("dbo.TeamStats");
            DropTable("dbo.Profile");
            DropTable("dbo.PlayerStats");
            DropTable("dbo.Player");
            DropTable("dbo.Team");
            DropTable("dbo.Game");
        }
    }
}
