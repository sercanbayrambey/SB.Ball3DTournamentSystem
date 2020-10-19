using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Protest;
using SB.Ball3DTournamentSys.DTO.DTOs.ProtestResponse;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.Areas.Member.Models;
using SB.Ball3DTournamentSys.Web.BaseControllers;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Areas.Member.Controllers
{
    [Authorize(Roles = ConstRoles.Member)]
    [Area(ConstAreas.Member)]
    public class ProtestController : IdentityBaseController
    {
        private readonly IPlayedGamesService _playedGamesService;
        private readonly IMapper _mapper;
        private readonly IProtestService _protestService;
        private readonly IProtestResponseService _protestResponseService;
        public ProtestController(IPlayedGamesService playedGamesService, UserManager<AppUser> userManager, IMapper mapper, IProtestService protestService, IProtestResponseService protestResponseService) : base(userManager)
        {
            _playedGamesService = playedGamesService;
            _mapper = mapper;
            _protestService = protestService;
            _protestResponseService = protestResponseService;
        }

        public IActionResult Index()
        {
            return View(_mapper.Map<List<ProtestListAllDto>>(_protestService.GetAllByUserIdWithAll(GetLoggedUser().Id)));
        }

        public IActionResult ProtestDetails(int protestId)
        {
            var protest = _protestService.GetByIdWithAll(protestId);
            if (protest == null)
                return NotFound();

            if (!IsAuthorized(protest.AppUserId) && !IsAdmin())
                return Unauthorized();

            ViewBag.LoggedUserId = GetLoggedUser().Id;

            return View(new ProtestResponseListViewModel
            {
                Protest = _mapper.Map<ProtestListAllDto>(protest),
                ProtestResponses = _mapper.Map<List<ProtestResponseListAllDto>>(_protestResponseService.GetProtestResponsesByProtestIdWithAll(protestId))
            });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAnswer(CreateProtestResponseDto model)
        {
            if (!IsAuthorized(model.AppUserId) && !IsAdmin())
                return Unauthorized();
            if (ModelState.IsValid)
            {
                ProtestResponseEntity protestResponseEntity = new ProtestResponseEntity
                {
                    AppUserId = model.AppUserId,
                    Text = model.Text,
                    ProtestId = model.ProtestId
                };

                _protestResponseService.Add(protestResponseEntity);
            }

            return RedirectToAction("ProtestDetails", new { protestId = model.ProtestId });
        }
        public IActionResult AddProtest(int matchId)
        {
            var game = _playedGamesService.GetByIdWithTeamTable(matchId);
            if (game == null || game.HomeTeam == null || game.AwayTeam == null)
                return NotFound();

            ViewBag.LoggedUserId = GetLoggedUser().Id;
            ViewBag.Game = game;

            return View(new CreateProtestDto());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProtest(CreateProtestDto model)
        {
            if (!IsAuthorized(model.AppUserId))
                return Unauthorized();

            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<ProtestEntity>(model);
                _protestService.Add(entity);
                return RedirectToAction("Index", new { matchId = model.PlayedGameId });

            }
            var game = _playedGamesService.GetByIdWithTeamTable(model.PlayedGameId);
            ViewBag.LoggedUserId = GetLoggedUser().Id;
            ViewBag.Game = game;
            return View(model);
        }
    }
}
