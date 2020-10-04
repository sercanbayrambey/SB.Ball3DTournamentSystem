using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.TagHelpers
{
    [HtmlTargetElement("upcoming-tournaments")]
    public class UpcomingTournamentStringTagHelper  : TournamentTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            StringBuilder stringBuilder = new StringBuilder();
            var str = $"<div><p><i><i class=\"fas fa-hourglass-start mr-1\"></i><a class=\"text-info\" href=\"Tournament\\Index\\{Id}\"><strong>{TournamentType}v{TournamentType} {StadiumName} </strong> ({Date})</a></i><label class=\"ml-1 badge-info badge-pill p-1 text-white\"><strong>{TeamCount}</strong> Teams Registered</label></p></div>";
            stringBuilder.Append(str);

            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}
