using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;

namespace SB.Ball3DTournamentSys.Web.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITournamentService _tournamentService;
        public TournamentController(IMapper mapper, ITournamentService tournamentService)
        {
            _mapper = mapper;
            _tournamentService = tournamentService;
        }
        public IActionResult Index(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var model = _mapper.Map<TournamentListAllDto>(_tournamentService.GetTournamentWithAllTablesById(id.Value));
            
            if (model == null)
                return NotFound();

            return View(model);
        }
    }
}
