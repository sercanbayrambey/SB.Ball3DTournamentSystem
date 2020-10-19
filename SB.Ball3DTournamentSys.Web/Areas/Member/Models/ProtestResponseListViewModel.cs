using SB.Ball3DTournamentSys.DTO.DTOs.Protest;
using SB.Ball3DTournamentSys.DTO.DTOs.ProtestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Ball3DTournamentSys.Web.Areas.Member.Models
{
    public class ProtestResponseListViewModel
    {
        public List<ProtestResponseListAllDto> ProtestResponses{ get; set; }
        public ProtestListAllDto Protest{ get; set; }

    }
}
