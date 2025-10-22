namespace TestProject1
{
    public enum PokemonType
    {
        Rock,
        Ground,
        Water,
        Electric,
        Fire,
        Grass,
        Ghost,
        Poison,
        Psychic,
        Bug,
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }

        public int SpAttack { get; set; }
        public int SpDefense { get; set; }

        public List<PokemonType> Types { get; } = new List<PokemonType>();

        public Move[] Moves { get; set; }

        //  Constructor general (1 o 2 tipos)
        public Pokemon(string name, int level, int attack, int defense, int SpAtk, int SpDef, params PokemonType[] types)
        {
            Name = name;

            // Agrega todos los tipos que reciba
            Types.AddRange(types);

            Level = level;
            Attack = attack;
            Defense = defense;
            SpAttack = SpAtk;
            SpDefense = SpDef;
        }

        //  Constructor rápido para un solo tipo
        public Pokemon(string name, PokemonType type)
            : this(name, 1, 10, 10, 10, 10, type)
        {
        }
    }
}