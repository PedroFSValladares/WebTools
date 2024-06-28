using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Room
{
    public class RoomModel
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public int MaxPlayers { get; set; }
    }
}
