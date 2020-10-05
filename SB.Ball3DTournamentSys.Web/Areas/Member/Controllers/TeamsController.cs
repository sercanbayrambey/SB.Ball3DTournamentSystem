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
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Areas.Member.Controllers
{

    [Authorize(Roles =ConstRoles.Member)]
    [Area(ConstAreas.Member)]
    public class TeamsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITeamPlayersService _teamPlayersService;
        public TeamsController(IMapper mapper,ITeamService teamService,UserManager<AppUser> userManager, ITeamPlayersService teamPlayersService)
        {
            _teamPlayersService = teamPlayersService;
            _userManager = userManager;
            _teamService = teamService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var loggedUserId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
            ViewBag.CurrentUserId = loggedUserId;
            //TODO: Fix here
            return View(_mapper.Map<List<TeamListDto>>(_teamPlayersService.GetUserTeamsById(loggedUserId)));
        }

        public IActionResult Create()
        {
            return View(new CreateTeamDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTeamDto model)
        {
            if(ModelState.IsValid)
            {
                model.AppUserId = _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                var teamEntity = _mapper.Map<TeamEntity>(model);
                _teamService.Add(teamEntity);
                _teamPlayersService.Add(new TeamPlayersEntity
                {
                    AppUserId = model.AppUserId,
                    TeamId = teamEntity.Id
                });
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
