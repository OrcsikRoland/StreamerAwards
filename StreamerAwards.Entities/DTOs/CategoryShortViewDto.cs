using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.DTOs
{
    public class CategoryShortViewDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int VotesCount { get; set; }
    }
}
