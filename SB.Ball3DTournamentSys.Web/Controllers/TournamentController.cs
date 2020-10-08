using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;

namespace SB.Ball3DTournamentSys.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;
        private readonly IPlayedGamesService _playedGamesService;
        public TournamentController(IMapper mapper, ITournamentService tournamentService, IPlayedGamesService playedGamesService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
            _playedGamesService = playedGamesService;
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

        public IActionResult UpdateScore(int matchId)
        {
            var playedGame = _playedGamesService.GetById(matchId);
            var winnerTeam = _playedGamesService.UpdateScore(playedGame, 3, 2);
            FixtureManager fm = new FixtureManager(playedGamesService:_playedGamesService);
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
