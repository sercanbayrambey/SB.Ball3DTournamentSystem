using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Concrete
{
    public class BracketManager
    {

        private List<PlayedGamesEntity> _gameFixture;
        public BracketManager(List<PlayedGamesEntity> gameFixture)
        {
            _gameFixture = gameFixture;
        }

        public object GenerateBracketObject()
        {
            List<dynamic> Rounds = new List<dynamic>();
            List<dynamic> PlayedGames = new List<dynamic>();
            List<dynamic> RoundResults = new List<dynamic>();


            int currentRound = 0;
            foreach (var item in _gameFixture)
            {
                if (currentRound != item.RoundNumber || currentRound == 0) // new Round
                {
                    /*PlayedGames = new List<dynamic>();*/
                    RoundResults = new List<dynamic>();
                }

                List<dynamic> Game = new List<dynamic>();
                if (item.HomeTeam != null)
                {
                    Game.Add(item.HomeTeam.Tag);
                }

                if (item.AwayTeam != null)
                {
                    Game.Add(item.AwayTeam?.Tag);
                }

                if ((item.HomeTeam == null && item.AwayTeam != null) || (item.HomeTeam != null && item.AwayTeam == null))
                {
                    Game.Add(null);
                }

                if ((item.HomeTeam != null || item.AwayTeam != null) && item.RoundNumber == 1)
                    PlayedGames.Add(Game);


                List<dynamic> Scores = new List<dynamic>();
                Scores.Add(item != null && item.IsFinished  ?  item.HomeTeamScore : null);
                Scores.Add(item != null && item.IsFinished  ?  item.AwayTeamScore : null);
                RoundResults.Add(Scores);

                if (currentRound != item.RoundNumber)
                {
                    Rounds.Add(RoundResults);
                    currentRound = item.RoundNumber;
                }

            }


            var result = new { teams = PlayedGames.ToArray(), results = Rounds.ToArray() };
            return result;
        }
    }
}
