namespace Fantastic2.Migrations
{
    using Fantastic2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Fantastic2.Data.Fantastic2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Fantastic2.Data.Fantastic2Context context)
        {

            var teams = new List<Team>
            {
                new Team{Name = "Panathinaikos OPAP Athens"},
                new Team{Name = "Crvena Zvezda mts Belgrade"}
            };
            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();

            var games = new List<Game>
            {
                new Game{
                    HomeTeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID,
                    GuestTeamID = teams.Single(t => t.Name == "Crvena Zvezda mts Belgrade").ID}
            };
            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player{
                    Firstname = "Deshaun", Lastname = "Thomas",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Tyrese", Lastname = "Rice",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Georgios", Lastname = "Papagiannis",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Andy", Lastname = "Rautins",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Ioannis", Lastname = "Papapetrou",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Nikos", Lastname = "Pappas",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Ian", Lastname = "Vougioukas",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Konstantinos", Lastname = "Papadakis",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Wesley", Lastname = "Johnson",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Jimmer", Lastname = "Fredette",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Nick", Lastname = "Calathes",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Jacob", Lastname = "Wiley",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Konstantinos", Lastname = "Mitoglou",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},
                new Player{
                    Firstname = "Benjamin", Lastname = "Bentil",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID},

                // Former team Player (Brown)
                new Player{
                    Firstname = "Rion", Lastname = "Brown",
                    TeamID = teams.Single(t => t.Name == "Panathinaikos OPAP Athens").ID}
                // Former team Player (Brown)
            };
            players.ForEach(pl => context.Players.Add(pl));
            context.SaveChanges();

            var profiles = new List<Profile>
            { 
                new Profile{
                     PlayerID= players.Single(p => p.Lastname == "Thomas").ID,
                     Country = "USA",
                     Position = Position.Forward
                     },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Rice").ID,
                    Country = "USA",
                    Position = Position.Guard
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Papagiannis").ID,
                    Country = "GRE",
                    Position = Position.Center
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Rautins").ID,
                    Country = "CAN",
                    Position = Position.Guard
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Papapetrou").ID,
                    Country = "GRE",
                    Position = Position.Forward
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Pappas").ID,
                    Country = "GRE",
                    Position = Position.Guard
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Vougioukas").ID,
                    Country = "GRE",
                    Position = Position.Center
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Papadakis").ID,
                    Country = "GRE",
                    Position = Position.Guard
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Johnson").ID,
                    Country = "USA",
                    Position = Position.Forward
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Fredette").ID,
                    Country = "USA",
                    Position = Position.Guard 
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Calathes").ID,
                    Country = "GRE",
                    Position = Position.Guard
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Wiley").ID,
                    Country = "USA",
                    Position = Position.Forward
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Mitoglou").ID,
                    Country = "GRE",
                    Position = Position.Forward
                    },
                new Profile{
                    PlayerID= players.Single(p => p.Lastname == "Bentil").ID,
                    Country = "GHA",
                    Position = Position.Forward
                    },
                new Profile{
                    PlayerID = players.Single(p => p.Lastname == "Brown").ID,
                    Country = "USA",
                    Position = Position.Guard
                    }
            };
            profiles.ForEach(pr => context.Profiles.Add(pr));
            context.SaveChanges();

            var playerStats = new List<PlayerStats>
            {
                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" && p.Lastname == "Thomas").ID,
                    TwoPointMade = 6, TwoPointAttempted = 13, ThreePointMade = 0, ThreePointAttempted = 1, FreeThrowMade = 6, FreeThrowAttempted = 7,
                    OffensiveRebounds = 4, DefensiveRebounds = 7, Assists = 2, Steals = 2, Turnovers = 1, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 2,
                    FoulsReceived = 4},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Rice").ID,
                    TwoPointMade = 2, TwoPointAttempted = 3, ThreePointMade = 1, ThreePointAttempted = 2, FreeThrowMade = 5, FreeThrowAttempted = 6,
                    OffensiveRebounds = 1, DefensiveRebounds = 1, Assists = 2, Steals = 1, Turnovers = 1, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 1,
                    FoulsReceived = 4},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Papagiannis").ID,
                    TwoPointMade = 4, TwoPointAttempted = 6, ThreePointMade = 0, ThreePointAttempted = 0, FreeThrowMade = 0, FreeThrowAttempted = 2,
                    OffensiveRebounds = 0, DefensiveRebounds = 5, Assists = 0, Steals = 1, Turnovers = 0, BlocksMade = 2, BlocksReceived = 0, FoulsMade = 1,
                    FoulsReceived = 1},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Papapetrou").ID,
                    TwoPointMade = 1, TwoPointAttempted = 2, ThreePointMade = 0, ThreePointAttempted = 1, FreeThrowMade = 0, FreeThrowAttempted = 0,
                    OffensiveRebounds = 0, DefensiveRebounds = 2, Assists = 0, Steals = 0, Turnovers = 0, BlocksMade = 1, BlocksReceived = 0, FoulsMade = 3,
                    FoulsReceived = 1},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Vougioukas").ID,
                    TwoPointMade = 2, TwoPointAttempted = 2, ThreePointMade = 0, ThreePointAttempted = 0, FreeThrowMade = 0, FreeThrowAttempted = 0,
                    OffensiveRebounds = 0, DefensiveRebounds = 2, Assists = 0, Steals = 0, Turnovers = 4, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 1,
                    FoulsReceived = 2},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Johnson").ID,
                    TwoPointMade = 1, TwoPointAttempted = 1, ThreePointMade = 0, ThreePointAttempted = 0, FreeThrowMade = 1, FreeThrowAttempted = 4,
                    OffensiveRebounds = 0, DefensiveRebounds = 3, Assists = 1, Steals = 2, Turnovers = 0, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 2,
                    FoulsReceived = 2},

                // Its not Panathinaikos player any more. It should be fixed!
                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Brown").ID,
                    TwoPointMade = 0, TwoPointAttempted = 0, ThreePointMade = 0, ThreePointAttempted = 0, FreeThrowMade = 0, FreeThrowAttempted = 0,
                    OffensiveRebounds = 0, DefensiveRebounds = 1, Assists = 0, Steals = 0, Turnovers = 0, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 1,
                    FoulsReceived = 2},
                 // Its not Panathinaikos player any more. It should be fixed!

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Fredette").ID,
                    TwoPointMade = 2, TwoPointAttempted = 4, ThreePointMade = 1, ThreePointAttempted = 2, FreeThrowMade = 4, FreeThrowAttempted = 4,
                    OffensiveRebounds = 0, DefensiveRebounds = 1, Assists = 1, Steals = 0, Turnovers = 2, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 2,
                    FoulsReceived = 3},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Calathes").ID,
                    TwoPointMade = 5, TwoPointAttempted = 8, ThreePointMade = 3, ThreePointAttempted = 6, FreeThrowMade = 2, FreeThrowAttempted = 3,
                    OffensiveRebounds = 0, DefensiveRebounds = 3, Assists = 7, Steals = 1, Turnovers = 5, BlocksMade = 0, BlocksReceived = 2, FoulsMade = 1,
                    FoulsReceived = 6},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Wiley").ID,
                    TwoPointMade = 1, TwoPointAttempted = 2, ThreePointMade = 0, ThreePointAttempted = 1, FreeThrowMade = 0, FreeThrowAttempted = 0,
                    OffensiveRebounds = 1, DefensiveRebounds = 0, Assists = 1, Steals = 1, Turnovers = 0, BlocksMade = 1, BlocksReceived = 0, FoulsMade = 2,
                    FoulsReceived = 0},

                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" &&  p.Lastname == "Mitoglou").ID,
                    TwoPointMade = 2, TwoPointAttempted = 2, ThreePointMade = 0, ThreePointAttempted = 0, FreeThrowMade = 2, FreeThrowAttempted = 2,
                    OffensiveRebounds = 0, DefensiveRebounds = 0, Assists = 0, Steals = 0, Turnovers = 0, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 1,
                    FoulsReceived = 2},

                //***************** DNP *****************//
                new PlayerStats{
                    GameID = games.Single(g => g.HomeTeam.Name == "Panathinaikos OPAP Athens" && g.GuestTeam.Name == "Crvena Zvezda mts Belgrade").ID,
                    PlayerID = players.Single(p => p.Team.Name == "Panathinaikos OPAP Athens" && p.Lastname == "Bentil").ID,
                    TwoPointMade = 0, TwoPointAttempted = 0, ThreePointMade = 0, ThreePointAttempted = 0, FreeThrowMade = 0, FreeThrowAttempted = 0,
                    OffensiveRebounds = 0, DefensiveRebounds = 0, Assists = 0, Steals = 0, Turnovers = 0, BlocksMade = 0, BlocksReceived = 0, FoulsMade = 0,
                    FoulsReceived = 0}
                //***************** DNP *****************//
            };
            playerStats.ForEach(pl => context.PlayerStats.Add(pl));
            context.SaveChanges();

        }
    }
}
