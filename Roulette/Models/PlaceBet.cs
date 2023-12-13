using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette.Models
{
    public class PlaceBet
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Color { get; set; }
        public decimal Amount { get; set; }
    }

}
