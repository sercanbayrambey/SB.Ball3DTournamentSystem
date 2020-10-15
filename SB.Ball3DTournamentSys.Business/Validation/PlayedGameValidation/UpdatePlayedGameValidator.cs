using FluentValidation;
using SB.Ball3DTournamentSys.DTO.DTOs.PlayedGames;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.PlayedGameValidation
{
    public class UpdatePlayedGameValidator : AbstractValidator<UpdatePlayedGameDto>
    {
        public UpdatePlayedGameValidator()
        {
            RuleFor(I => I.HomeTeamScore).NotNull().WithMessage("Home team score can not be empty.");
            RuleFor(I => I.AwayTeamScore).NotNull().WithMessage("Away team score can not be empty");
            RuleFor(I => I.Id).NotEmpty().WithMessage("ID cannot be null.");
            RuleFor(I => I).Must(I => !GameIsDraw(I)).WithMessage("Game cannot be draw. We need winner!");
        }

        private bool GameIsDraw(UpdatePlayedGameDto model)
        {
            if(model.HomeTeamScore==null || model.AwayTeamScore == null || model.HomeTeamScore == model.AwayTeamScore)
            {
                return true;
            }
            return false;
        }
    }
}
