namespace Fantastic2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompleteStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stats", "TwoPointMade", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "TwoPointAttempted", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "ThreePointMade", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "ThreePointAttempted", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "FreeThrowMade", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "FreeThrowAttempted", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "Steals", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "Turnovers", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "BlocksMade", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "BlocksReceived", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "FoulsMade", c => c.Int(nullable: false));
            AddColumn("dbo.Stats", "FoulsReceived", c => c.Int(nullable: false));
            DropColumn("dbo.Stats", "Points");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stats", "Points", c => c.Int(nullable: false));
            DropColumn("dbo.Stats", "FoulsReceived");
            DropColumn("dbo.Stats", "FoulsMade");
            DropColumn("dbo.Stats", "BlocksReceived");
            DropColumn("dbo.Stats", "BlocksMade");
            DropColumn("dbo.Stats", "Turnovers");
            DropColumn("dbo.Stats", "Steals");
            DropColumn("dbo.Stats", "FreeThrowAttempted");
            DropColumn("dbo.Stats", "FreeThrowMade");
            DropColumn("dbo.Stats", "ThreePointAttempted");
            DropColumn("dbo.Stats", "ThreePointMade");
            DropColumn("dbo.Stats", "TwoPointAttempted");
            DropColumn("dbo.Stats", "TwoPointMade");
        }
    }
}
