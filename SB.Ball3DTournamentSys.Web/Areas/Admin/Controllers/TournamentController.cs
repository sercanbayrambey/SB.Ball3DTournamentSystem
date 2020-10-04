using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Areas.Admin.Controllers
{
    [Area(ConstAreas.Admin)]
    [Authorize(Roles = ConstRoles.Admin)]
    public class TournamentController : Controller
    {
        private readonly IStadiumService _stadiumService;
        private readonly IGameServerService _gameServerService;
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public TournamentController(IStadiumService stadiumService, IGameServerService gameServerService,ITournamentService tournamentService,IMapper mapper)
        {
            _stadiumService = stadiumService;
            _gameServerService = gameServerService;
            _tournamentService = tournamentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {

            return View(_mapper.Map<List<TournamentListAllDto>>(_tournamentService.GetAllWithAllTables()));
        }

        public IActionResult CreateTournament()
        {
            ViewBag.Stadiums = new SelectList(_stadiumService.GetAll(), "Id", "Name");
            ViewBag.GameServers = new SelectList(_gameServerService.GetAll(), "Id", "ServerName");
            return View(new CreateTournamentDto());
        }

        [HttpPost]
        public IActionResult CreateTournament(CreateTournamentDto model)
        {
            if(ModelState.IsValid)
            {
                var tournamentEntity = _mapper.Map<TournamentEntity>(model);
                _tournamentService.Add(tournamentEntity);
                return RedirectToAction("Index", "Home", new {area=String.Empty });
            }
            return View();
        }
    }
}
