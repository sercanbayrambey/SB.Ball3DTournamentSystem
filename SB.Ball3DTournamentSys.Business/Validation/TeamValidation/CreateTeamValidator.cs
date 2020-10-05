using FluentValidation;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.TeamValidation
{
    public class CreateTeamValidator : AbstractValidator<CreateTeamDto>
    {
        private readonly ITeamService _teamService;
        public CreateTeamValidator(ITeamService teamService)
        {
            //TODO: Add regex for team name and tag

            _teamService = teamService;
            RuleFor(I => I.Name).NotEmpty().WithMessage("Team name field is required.").MaximumLength(32);
            RuleFor(I => I.Tag).NotEmpty().WithMessage("Team tag field is required.").MaximumLength(6);
            RuleFor(I => I).Must(I => IsTeamTagUnique(I)).WithMessage("Team tag is in use.");
        }


        private bool IsTeamTagUnique(CreateTeamDto dto)
        {
            var teamList = _teamService.GetAll();
            var result = teamList.Where(I => I.Tag.ToLower() == dto.Tag.ToLower()).FirstOrDefault();
            if (result == null)
                return true;
            return false;
        }
    }
}
