using FluentValidation;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUserDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.AppUserValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDTO>
    {
        public AppUserLoginValidator()
        {
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password field is required.");
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Username field is required.");
        }
    }
}
