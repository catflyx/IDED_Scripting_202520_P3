using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Pikachu : Pokemon
    {
        public Pikachu()
            : base("Pikachu", 1, 55, 40, 50, 50, PokemonType.Electric)
        {
        }
    }
}
