using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SB.Ball3DTournamentSys.Business.Concrete;
using SB.Ball3DTournamentSys.Business.Interfaces;
using SB.Ball3DTournamentSys.DTO.DTOs.Protest;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.ProtestValidation
{
    public class CreateProtestValidator : AbstractValidator<CreateProtestDto>
    {
        private readonly ITeamService _teamService;
        private readonly IPlayedGamesService _playedGamesService;

        public CreateProtestValidator(ITeamService teamService, IPlayedGamesService playedGamesService)
        {
            _teamService = teamService;
            _playedGamesService = playedGamesService;
            RuleFor(I => I.Text).NotEmpty().WithMessage("Text field is required.").MaximumLength(512);
            RuleFor(I => I.Title).NotEmpty().WithMessage("Title field is required.").MaximumLength(64);
            RuleFor(I => I).Must(I => IsUserOwner(I)).WithMessage("You are not owner of these teams.");
            RuleFor(I => I).Must(I => !IsGameFinished(I.PlayedGameId)).WithMessage("Game is already finished.");
        }

        private bool IsUserOwner(CreateProtestDto model)
        {
            var game = _playedGamesService.GetById(model.PlayedGameId);
            if(_teamService.IsUserOwner(model.AppUserId,game.HomeTeamId.Value) || _teamService.IsUserOwner(model.AppUserId,game.AwayTeamId.Value))
            {
                return true;
            }
            return false;

        }

        private bool IsGameFinished(int playedGameId)
        {
            return _playedGamesService.GetById(playedGameId).IsFinished;
        }
    }
}
