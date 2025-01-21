
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerAwards.Entities.Entity_Models
{
    public class Vote 
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string StreamerId { get; set; }
        public virtual Streamer Streamer { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
