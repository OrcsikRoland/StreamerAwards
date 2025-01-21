using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.DTOs
{
    public class VoteResultDto
    {
        public string StreamerId { get; set; } = "";
        public string StreamerName { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public int TotalVotes { get; set; }
    }
}
