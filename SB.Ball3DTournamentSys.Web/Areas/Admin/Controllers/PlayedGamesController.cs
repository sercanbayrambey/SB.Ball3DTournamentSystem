using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Areas.Admin.Controllers
{
    [Area(ConstAreas.Admin)]
    [Authorize(Roles = ConstRoles.Admin)]
    public class PlayedGamesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPlayedGamesService _playedGamesService;
        public PlayedGamesController(IPlayedGamesService playedGamesService, IMapper mapper)
        {
            _mapper = mapper;
            _playedGamesService = playedGamesService;
        }
        public IActionResult Index(int tournamentId)
        {
            return View(_mapper.Map<List<PlayedGamesListAllDto>>(_playedGamesService.GetPlayedGamesWithAllTablesByTournamentId(tournamentId)));
        }

        [HttpGet]
        public IActionResult UpdateScore(int matchId)
        {
            var model = _mapper.Map<UpdatePlayedGameDto>(_playedGamesService.GetAllById(matchId));
            if (model == null)
                return NotFound();
            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateScore(UpdatePlayedGameDto model)
        {
            if (ModelState.IsValid)
            {
                var playedGame = _playedGamesService.GetById(model.Id);
                var winnerTeam = _playedGamesService.UpdateScore(playedGame, model.HomeTeamScore.Value, model.AwayTeamScore.Value);
                _playedGamesService.AddWinnerToNextGame(playedGame, winnerTeam);
            }
            else
            {
                model = _mapper.Map<UpdatePlayedGameDto>(_playedGamesService.GetAllById(model.Id));
                return View(model);
            }
            return RedirectToAction("Index", new { tournamentId = model.PlayedGamesRound.TournamentId });
        }
    }
}
