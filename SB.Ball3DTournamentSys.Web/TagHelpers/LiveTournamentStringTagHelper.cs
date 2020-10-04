using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.TagHelpers
{
 
    [HtmlTargetElement("live-tournaments")]
    public class LiveTournamentStringTagHelper : TournamentTagHelperBase
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            StringBuilder stringBuilder = new StringBuilder();
            var str =  $"<div><p><i><i class=\"far fa-futbol mr-1\"></i><a class=\"text-info\" href=\"Tournament\\Index\\{Id}\"><strong>{TournamentType}v{TournamentType} {StadiumName} </strong> ({Date})</a></i><label class=\"ml-1\" style=\"color:red;border:solid;padding:1px\">ON LIVE!</label><label class=\"ml-1 badge-info badge-pill p-1 text-white\"><strong>{TeamCount}</strong> Teams Playing</label></p></div>";
            stringBuilder.Append(str);

            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}
