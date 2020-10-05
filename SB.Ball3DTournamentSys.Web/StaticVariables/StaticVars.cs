using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.StaticVariables
{
    public static class StaticVars
    {
        public static string CET_TIME = DateTime.Now.AddHours(-1).ToShortTimeString();
    }
}
