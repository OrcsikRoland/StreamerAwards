using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.DTOs
{
    public class StreamerCreateUpdateDto
    {
        public required string Name { get; set; } = "";
        public required string Description { get; set; } = "";
        public required string CategoryId { get; set; } = "";
    }
}
