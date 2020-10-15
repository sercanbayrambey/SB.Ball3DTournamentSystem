using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.BaseControllers;
using SB.Ball3DTournamentSys.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace SB.Ball3DTournamentSys.Web.Controllers
{
    public class TournamentController : IdentityBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;
        private readonly IPlayedGamesService _playedGamesService;
        private readonly ITournamentTeamsService _tournamentTeamsService;
        public TournamentController(IMapper mapper, ITournamentService tournamentService, IPlayedGamesService playedGamesService, ITournamentTeamsService tournamentTeamsService, UserManager<AppUser> userManager) : base(userManager) 
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

            if(model.IsStarted && IsLogged())
            {
                ViewBag.Games = _mapper.Map<List<PlayedGamesListAllDto>>(_playedGamesService.GetTournamentGamesByUserIdWithAll(GetLoggedUser().Id, model.Id));
            }



            return View(model);
        }


        [Route("getBracket")]
        [HttpPost]
        public IActionResult GetTournamentBracket(int tournamentId)
        {
            var gameFixture = _playedGamesService.GetPlayedGamesWithAllTablesByTournamentId(tournamentId);
            BracketManager bm = new BracketManager(gameFixture);
            return Json(bm.GenerateBracketObject());
        }



    
    }
}
