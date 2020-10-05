using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.StringConsts
{
    public static class ConstRoles
    {
        public const string Admin = "admin";

        /// <summary>
        /// Admin is member too.
        /// </summary>
        public const string Member = "member,admin";
    }
}
