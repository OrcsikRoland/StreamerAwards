
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.Entity_Models
{
    public class Category 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Streamer> Streamers { get; set; } 
    }
}
