﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.DTOs
{
    public class CategoryViewDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public IEnumerable<StreamerShortViewDto> Streamers { get; set; }
    }
}
