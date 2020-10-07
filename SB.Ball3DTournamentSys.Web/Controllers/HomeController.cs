using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUserDto;
using SB.Ball3DTournamentSys.DTO.DTOs.GameServers;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using SB.Ball3DTournamentSys.Entities.Concrete;
using SB.Ball3DTournamentSys.Web.Models;
using SB.Ball3DTournamentSys.Web.StringConsts;

namespace SB.Ball3DTournamentSys.Web.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITournamentService _tournamentService;
        public HomeController(ITournamentService tournamentService, IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _tournamentService = tournamentService;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            //TODO: Refactor here, because now everytime it sends 3 unnecessary requests to database
            var upcomingTournaments = _mapper.Map<List<TournamentListAllDto>>(_tournamentService.GetUpcomingTournamentsWithAllTables());
            var finishedTournaments = _mapper.Map<List<TournamentListAllDto>>(_tournamentService.GetFinishedTournamentsWithAllTables());
            var startedTournaments = _mapper.Map<List<TournamentListAllDto>>(_tournamentService.GetStartedTournamentsWithAllTables());
            
            return View(new HomePageTournamentViewModel { FinishedTournaments = finishedTournaments, StartedTournaments=startedTournaments, UpcomingTournaments=upcomingTournaments});
        }

        public IActionResult Login()
        {
            return View(new AppUserLoginDTO());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AppUserLoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var appUser = await _userManager.FindByNameAsync(model.UserName);
                if (appUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user:appUser, model.Password, model.RememberMe,false);
                    if (result.Succeeded)
                        return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", "Username or pass are invalid.");
            }

            return View(model);
        }


        public IActionResult Register()
        {
            return View(new AppUserRegisterDTO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AppUserRegisterDTO model)
        {
            if(ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);
                var registerResult = await _userManager.CreateAsync(user, model.Password);

                if (registerResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, ConstRoles.Member);
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in registerResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            if(User.Identity.IsAuthenticated)
                _signInManager.SignOutAsync();

            return RedirectToAction("Index");
        }


    }
}
