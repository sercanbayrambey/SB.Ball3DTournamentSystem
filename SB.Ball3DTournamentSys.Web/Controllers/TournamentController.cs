using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using SB.Ball3DTournamentSys.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace SB.Ball3DTournamentSys.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;
        private readonly IPlayedGamesService _playedGamesService;
        private readonly ITournamentTeamsService _tournamentTeamsService;
        public TournamentController(IMapper mapper, ITournamentService tournamentService, IPlayedGamesService playedGamesService, ITournamentTeamsService tournamentTeamsService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
            _playedGamesService = playedGamesService;
            _tournamentTeamsService = tournamentTeamsService;
        }
        public IActionResult Index(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var model = _mapper.Map<TournamentListAllDto>(_tournamentService.GetTournamentWithAllTablesById(id.Value));

            if (model == null)
                return NotFound();

            return View(model);
        }

        public IActionResult Bracket()
        {
            var gameFixture = _playedGamesService.GetPlayedGamesWithAllTablesByTournamentId(3);
            return View(_mapper.Map<List<PlayedGamesListAllDto>>(gameFixture));
        }


        [Route("api")]
        public IActionResult API()
        {
            var gameFixture = _playedGamesService.GetPlayedGamesWithAllTablesByTournamentId(3);
            var teamCount = _tournamentTeamsService.GetTotalTeamCountByTournamentId(3);
            bool teamCountIsPowerOfTwo = MathManager.isPowerOfTwo(teamCount);

            List<dynamic> Rounds = new List<dynamic>();
            List<dynamic> PlayedGames = null;

            int currentRound = 0;
            int counter = 0;
            foreach (var item in gameFixture)
            {
                if (currentRound != item.RoundNumber || currentRound == 0) // new Round
                {
                    PlayedGames = new List<dynamic>();
                }

                List<dynamic> Game = new List<dynamic>();
                Game.Add(new { name = item.HomeTeam?.Tag ?? "Waiting..", id = item.HomeTeam?.Tag ?? null, seed = item?.HomeTeamId ?? null, displaySeed = counter == 0 ? "D1" : "", score = item.HomeTeamScore });
                Game.Add(new { name = item.AwayTeam?.Tag ?? "Waiting..", id = item.AwayTeam?.Tag ?? null, seed = item?.AwayTeamId ?? null, displaySeed = "", score = item.AwayTeamScore });

                PlayedGames.Add(Game);
                if(item.RoundNumber==1 /*&& !teamCountIsPowerOfTwo*/)
                {
                    Game = new List<dynamic>();
                    Game.Add(new { name = "", id = "bye", seed = "bye", displaySeed = "", score = 0 });
                    Game.Add(new { name = "", id = "bye", seed = "bye", displaySeed = "", score = 0 });
                    PlayedGames.Add(Game);
                }

                counter++;

                if (currentRound != item.RoundNumber)
                {
                    Rounds.Add(PlayedGames);
                    currentRound = item.RoundNumber;
                }
            }

            PlayedGames = new List<dynamic>();
            var _game = new List<dynamic>();
            _game.Add(new { name = "", id = "", seed = "", displaySeed = "", score = 0 });
            PlayedGames.Add(_game);
            Rounds.Add(PlayedGames);


            return Json(Rounds.ToArray());
        }

        [Route("api2")]
        public IActionResult API2()
        {

/*            var saveData = {
            "teams": [
                ["Team 1", "Team 2"],
                ["Team 3", null],
                ["Team 4", null],
                ["Team 5", null]
            ],
            "results": [
                [
                    [[1, 0], [null, null], [null, null], [null, null]],
                    [[null, null], [1, 4]],
                    [[null, null], [null, null]]
                ]
            ]
        };*/

            var gameFixture = _playedGamesService.GetPlayedGamesWithAllTablesByTournamentId(3);
            var teamCount = _tournamentTeamsService.GetTotalTeamCountByTournamentId(3);
            bool teamCountIsPowerOfTwo = MathManager.isPowerOfTwo(teamCount);

            List<dynamic> Rounds = new List<dynamic>();
            List<dynamic> PlayedGames = new List<dynamic>();
            List<dynamic> RoundResults = new List<dynamic>();
           

            int currentRound = 0;
            int counter = 0;
            foreach (var item in gameFixture)
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

                if (item.HomeTeam!=null || item.AwayTeam !=null)
                    PlayedGames.Add(Game);


                List<dynamic> Scores = new List<dynamic>();
                Scores.Add(item.HomeTeamScore);
                Scores.Add(item.AwayTeamScore);
                RoundResults.Add(Scores);

                if (currentRound != item.RoundNumber)
                {
                    Rounds.Add(RoundResults);
                    currentRound = item.RoundNumber;
                }

            }


            var result = new { teams = PlayedGames.ToArray(), results=Rounds.ToArray() };

            return Json(result);
        }


            public IActionResult UpdateScore(int matchId)
        {
            var playedGame = _playedGamesService.GetById(matchId);
            var winnerTeam = _playedGamesService.UpdateScore(playedGame, 3, 2);
            FixtureManager fm = new FixtureManager(_playedGamesService);
            var nextTable = fm.FindTheNextTableForGame(playedGame);
            if (nextTable.HomeTeamId == null)
                nextTable.HomeTeamId = winnerTeam.Id;
            else
                nextTable.AwayTeamId = winnerTeam.Id;
            _playedGamesService.Update(nextTable);
            return RedirectToAction("Bracket");
        }
    }
}
