using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.DTOs
{
    public class VoteCreateDto
    {
        public required string StreamerId { get; set; } = "";
        public required string CategoryId { get; set; } = "";
    }
}
