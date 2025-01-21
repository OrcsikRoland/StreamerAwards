using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.DTOs
{
    public class CategoryCreateUpdateDto
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
