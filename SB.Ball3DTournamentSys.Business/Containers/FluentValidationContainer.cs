﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SB.Ball3DTournamentSys.Business.Validation.AppUserValidation;
using SB.Ball3DTournamentSys.Business.Validation.TeamValidation;
using SB.Ball3DTournamentSys.Business.Validation.TournamentValidation;
using SB.Ball3DTournamentSys.DTO.DTOs.AppUser;
using SB.Ball3DTournamentSys.DTO.DTOs.Team;
using SB.Ball3DTournamentSys.DTO.DTOs.Tournament;
using System;
using System.Collections.Generic;
using System.Text;

namespace SB.Ball3DTournamentSys.Business.Containers
{
    public static class FluentValidationContainer
    {
        /// <summary>
        /// Fluent validation transients.
        /// </summary>
        /// <param name="services"></param>
        public static void AddFluentValidationTransients(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CreateTournamentDto>, CreateTournamentValidator>();
            services.AddTransient<IValidator<AppUserLoginDTO>, AppUserLoginValidator>();
            services.AddTransient<IValidator<AppUserRegisterDTO>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<CreateTeamDto>, CreateTeamValidator>();
            services.AddTransient<IValidator<RegisterTeamDto>, TournamentRegisterTeamValidator>();
        }
    }
   
}
