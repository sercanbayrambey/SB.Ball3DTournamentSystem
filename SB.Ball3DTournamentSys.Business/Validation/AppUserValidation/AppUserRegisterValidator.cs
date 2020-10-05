using FluentValidation;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Validation.AppUserValidation
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(I => I.Login).NotEmpty().WithMessage("Ball 3D Nick is required.");
            RuleFor(I => I.UserName).NotEmpty().WithMessage("Username field is required");
            RuleFor(I => I.Email).NotEmpty().WithMessage("Email adreess is required.").EmailAddress().WithMessage("Please enter valid e-mail adress.");
            RuleFor(I => I.Password).NotEmpty().WithMessage("Password field is required.");
            RuleFor(I => I.ConfirmPassword).Equal(I => I.Password).WithMessage("Passwords not match!");
        }
    }
}
