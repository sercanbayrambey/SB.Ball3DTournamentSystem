using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.Web.Models;

namespace SB.Ball3DTournamentSys.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGameServerService _gameServerService;
        public HomeController(IGameServerService gameServerService)
        {
            _gameServerService = gameServerService;
        }

        public IActionResult Index()
        {
            var gameServers = _gameServerService.GetAll();
            return View();
        }

     
    }
}
