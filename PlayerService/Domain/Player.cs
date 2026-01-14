using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Library.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
    }
}
