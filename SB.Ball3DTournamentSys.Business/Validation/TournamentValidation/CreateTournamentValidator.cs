using FluentValidation;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.TournamentValidation
{
    public class CreateTournamentValidator : AbstractValidator<CreateTournamentDto>
    {
        public CreateTournamentValidator()
        {
            /*Description field is required.*/
            RuleFor(I => I.Description).MaximumLength(512).WithMessage("Description maximum length is 512 chars.");
            RuleFor(I => I.GameServerId).NotEmpty().WithMessage("Please select a valid gameserver.");
            RuleFor(I => I.GameType).NotEmpty().ExclusiveBetween(-1, 12).WithMessage("Please select valid game type.");
            RuleFor(I => I.Name).NotEmpty().WithMessage("Tournament name field is required.").MaximumLength(50);
            /*RuleFor(I => I.ScoreLimit).ExclusiveBetween(0, 21).WithMessage("Please select valid score limit.");*/ // TODO: There is something wrong here, fix it.
            RuleFor(I => I.StartDate).NotEmpty().WithMessage("Date field is required.");
        }
    }   
}
