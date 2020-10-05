using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using SB.Ball3DTournamentSys.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.TournamentValidation
{
    public class TournamentRegisterTeamValidator : AbstractValidator<RegisterTeamDto>
    {
        // Is logged user is team owner?
        // Is tournament status is upcoming?
        // Is logged user registered another team?
        private readonly UserManager<AppUser> _userManager;
        private readonly ITournamentService _tournamentService;
        private readonly ITeamService _teamService;

        public TournamentRegisterTeamValidator(UserManager<AppUser> userManager, ITournamentService tournamentService,ITeamService teamService)
        {
            _tournamentService = tournamentService;
            _userManager = userManager;
            _teamService = teamService;

            RuleFor(I => I.TournamentId).Must(I=>IsUpcoming(I)).WithMessage("Tournament is already started/finished.");
            RuleFor(I => I).Must(I => IsUserTeamOwner(I)).WithMessage("You are not owner of this team.");
            RuleFor(I => I).Must(I => !IsUserRegisteredAnotherTeam(I)).WithMessage("You already registered your own other team.");
        }

        private bool IsUserTeamOwner(RegisterTeamDto dto)
        {
            var teamOwnerId = _teamService.GetById(dto.TeamId)?.AppUserId;
            var modelOwnerId = dto.AppUserId;

            if (teamOwnerId == modelOwnerId)
                return true;

            return false;
        }

        private bool IsUpcoming(int tournamentId)
        {
            var tournament = _tournamentService.GetById(tournamentId);
            if (tournament == null || tournament.IsStarted || tournament.IsFinished)
                return false;
            return true;
        }

        private bool IsUserRegisteredAnotherTeam(RegisterTeamDto dto)
        {
            var tournament = _tournamentService.GetTournamentWithAllTablesById(dto.TournamentId);
            if (tournament == null)
                return true;

            foreach (var item in tournament.TournamentTeams)
            {
                if(item.Team.AppUserId == dto.AppUserId)
                {
                    return true;
                }
            }

            return false;
        }
      
    }
}
