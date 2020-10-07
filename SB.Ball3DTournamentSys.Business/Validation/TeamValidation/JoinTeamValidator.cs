using FluentValidation;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.TeamValidation
{
    public class JoinTeamValidator : AbstractValidator<JoinTeamDto>
    {

        private readonly ITeamPlayersService _teamPlayersService;
        private readonly ITeamService _teamService;
        /// <summary>
        /// Validations are: If invite code null or empty, if user already is on team?
        /// </summary>
        public JoinTeamValidator(ITeamPlayersService teamPlayersService, ITeamService teamService)
        {
            _teamPlayersService = teamPlayersService;
            _teamService = teamService;

            RuleFor(I => I.InviteCode).NotEmpty().WithMessage("Team is not found.");
            RuleFor(I => I).Must(I => !IsUserAlreadyIsOnTeam(I)).WithMessage("You are already joined to this team. Check your teams.");
        }

        private bool IsUserAlreadyIsOnTeam(JoinTeamDto model)
        {
            var teamId = _teamService.GetTeamByInviteCodeWithUserTable(model.InviteCode).Id; 
            var teams = _teamPlayersService.GetAll().Where(I=>I.TeamId == teamId && I.AppUserId == model.UserIdToBeJoined);
            if (teams.Count() == 0)
                return false;
            return true;
        }
    }
}
