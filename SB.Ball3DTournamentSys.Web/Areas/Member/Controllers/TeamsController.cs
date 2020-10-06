using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.BaseControllers;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Areas.Member.Controllers
{

    [Authorize(Roles =ConstRoles.Member)]
    [Area(ConstAreas.Member)]
    public class TeamsController : IdentityBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;
        private readonly ITeamPlayersService _teamPlayersService;
        public TeamsController(IMapper mapper,ITeamService teamService,UserManager<AppUser> userManager, ITeamPlayersService teamPlayersService) : base(userManager)
        {
            _teamPlayersService = teamPlayersService;
            _teamService = teamService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var loggedUserId = GetLoggedUser().Id;
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
                model.AppUserId = GetLoggedUser().Id;
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


        [HttpPost]
        public IActionResult GenerateInviteLink(int? teamId)
        {
            if (teamId == null)
                return NotFound();

            var team = _teamService.GetById(teamId.Value);

            if (team == null)
                return NotFound();
          
            if (!IsLoggedUserTeamOwner(team))
                return Unauthorized();

            Response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
            var inviteCode = Guid.NewGuid();
            team.InviteCode = inviteCode.ToString();
            _teamService.Update(team);

            return Json(new { inviteCode });
        }
    }
}
