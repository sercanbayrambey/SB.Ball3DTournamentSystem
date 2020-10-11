using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Areas.Member.Controllers
{
    [Area(ConstAreas.Member)]
    [Authorize(Roles = ConstRoles.Member)]
    public class TournamentController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITournamentService _tournamentService;
        private readonly ITournamentTeamsService _tournamentTeamsService;
        public TournamentController(IMapper mapper, ITeamService teamService, UserManager<AppUser> userManager, ITournamentService tournamentService, ITournamentTeamsService tournamentTeamsService)
        {
            _mapper = mapper;
            _teamService = teamService;
            _userManager = userManager;
            _tournamentService = tournamentService;
            _tournamentTeamsService = tournamentTeamsService;

        }
        public IActionResult Register(int id)
        {
            var loggedUserId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            RegisterTeamDto model = new RegisterTeamDto
            {
                OwnedTeams = _mapper.Map<List<TeamListDto>>(_teamService.GetOwnedTeamsByUserId(loggedUserId)),
                Tournament = _mapper.Map<TournamentListAllDto>(_tournamentService.GetTournamentWithAllTablesById(id)),
                AppUserId = loggedUserId
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterTeamDto model)
        {
            var loggedUserId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;

            if (loggedUserId != model.AppUserId)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                _tournamentTeamsService.Add(new TournamentTeamsEntity
                {
                    TeamId = model.TeamId,
                    TournamentId = model.TournamentId,
                    IsConfirmed = DateTime.Now.AddMinutes(-30) <= DateTime.Now ? true : false
                });

                return RedirectToAction("Index", "Tournament", new { area = "", id = model.TournamentId });
            }

            model.OwnedTeams = _mapper.Map<List<TeamListDto>>(_teamService.GetOwnedTeamsByUserId(_userManager.FindByNameAsync(User.Identity.Name).Result.Id));

            model.Tournament = _mapper.Map<TournamentListAllDto>(_tournamentService.GetTournamentWithAllTablesById(model.TournamentId));

            return View(model);
        }

        public IActionResult Confirm(int id)
        {
           // TODO: Refactor here


            var loggedUserId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var tournament = _tournamentService.GetTournamentWithAllTablesById(id);

            if (tournament == null)
                return NotFound();

            if(tournament.IsStarted)
            {
                throw new Exception("Tournament is already started :(");
            }

            foreach (var item in tournament.TournamentTeams)
            {
                if (item.Team.AppUserId == loggedUserId) // it means user is registered his team to this tournament, so confirm it
                {
                    if (!item.IsConfirmed)
                    {
                        _tournamentTeamsService.ConfirmRegisterStatus(item.Team, tournament.Id);
                    }
                    return RedirectToAction("Index", "Tournament", new { area = "", id = id });
                }
            }

            return RedirectToAction("Register", "Tournament", new { area = ConstAreas.Member, id = id });

        }


    }
}
