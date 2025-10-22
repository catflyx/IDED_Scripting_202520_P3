using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Gastly : Pokemon
    {
        public Gastly()
            : base("Gastly", 1, 35, 30, 100, 35, PokemonType.Ghost, PokemonType.Poison)
        {
        }
    }
}
