using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.BaseControllers;
using SB.Ball3DTournamentSys.Web.StringConsts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.Areas.Member.Controllers
{
    [Area(ConstAreas.Member)]
    [Authorize(Roles = ConstRoles.Member)]
    public class PlayedGamesController : IdentityBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPlayedGamesService _playedGamesService;
        public PlayedGamesController(IPlayedGamesService playedGamesService, IMapper mapper, UserManager<AppUser> userManager) : base(userManager)
        {
            _mapper = mapper;
            _playedGamesService = playedGamesService;
        }


        [HttpGet]
        public IActionResult UpdateScore(int matchId)
        {
            var model = _mapper.Map<MemberUpdatePlayedGameDto>(_playedGamesService.GetAllById(matchId));
            model.LoggedUserId = GetLoggedUser().Id;
            if (model == null || model.HomeTeamId==null || model.AwayTeamId == null)
                return NotFound();
            return View(model);
        }



        //TOOD: Refactor needed

        [HttpPost]
        public IActionResult UpdateScore(MemberUpdatePlayedGameDto model)
        {
                
            if (ModelState.IsValid)
            {
                var loggedUserId = GetLoggedUser().Id;
                if (model.LoggedUserId != loggedUserId)
                    return Unauthorized();

                var playedGame = _playedGamesService.GetById(model.Id);

                if(playedGame.IsFinished)
                    throw new Exception("Game is finished.");

                var winnerTeam = _playedGamesService.UpdateScore(playedGame, model.HomeTeamScore.Value, model.AwayTeamScore.Value,loggedUserId);
                if(playedGame.IsAwayTeamConfirmedResult && playedGame.IsHomeTeamConfirmedResult)
                    _playedGamesService.AddWinnerToNextGame(playedGame, winnerTeam); // not yet!
            
            }
            else
            {
                model = _mapper.Map<MemberUpdatePlayedGameDto>(_playedGamesService.GetAllById(model.Id));
                return View(model);
            }
            return RedirectToAction("Index","Tournament", new {area="", Id = model.PlayedGamesRound.TournamentId });
        }


        [HttpPost]
        public IActionResult ConfirmResult(int matchId, int userId)
        {

            var playedGame = _playedGamesService.GetAllById(matchId);
            if (playedGame == null)
                return NotFound();

            if (playedGame.IsAwayTeamConfirmedResult && playedGame.IsHomeTeamConfirmedResult)
                throw new Exception("Game is already confirmed.");

            UpdateScore(new MemberUpdatePlayedGameDto
            {
                AwayTeamId = playedGame.AwayTeamId,
                HomeTeamId = playedGame.HomeTeamId,
                AwayTeamScore = playedGame.AwayTeamScore,
                HomeTeamScore = playedGame.HomeTeamScore,
                PlayedGamesRound = playedGame.PlayedGamesRound,
                LoggedUserId = GetLoggedUser().Id,
                Id = playedGame.Id
            });;

            return RedirectToAction("Index", "Tournament", new { area = "", Id = playedGame.PlayedGamesRound.TournamentId });

        }
    }
}
