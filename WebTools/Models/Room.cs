using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTools.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public bool isClosed { get; set; }
        public string Password { get; set; }
        public int MaxPlayers { get; set; }
    }
}
