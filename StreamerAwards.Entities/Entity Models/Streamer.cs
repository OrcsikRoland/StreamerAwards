
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.Entity_Models
{
    public class Streamer 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public int VotesCount { get; set; }
        public string CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

    }
}
