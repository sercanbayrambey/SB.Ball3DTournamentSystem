using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.TagHelpers
{
    public class TournamentTagHelperBase : TagHelper
    {
        public string StadiumName { get; set; }
        public string TournamentType { get; set; }
        public string Date { get; set; }
        public string TeamCount { get; set; }
        public string WinnerTeamTag { get; set; }

        public int Id { get; set; }
    }
}
