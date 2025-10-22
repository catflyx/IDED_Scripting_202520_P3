namespace TestProject1
{
    public static class TypeChart
    {
        // Diccionario: Tipo atacante → (Tipo defensor → modificador)
        private static readonly Dictionary<PokemonType, Dictionary<PokemonType, double>> effectiveness =
            new Dictionary<PokemonType, Dictionary<PokemonType, double>>
            {
                [PokemonType.Water] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Fire] = 2.0,
                    [PokemonType.Ground] = 2.0,
                    [PokemonType.Rock] = 2.0,
                    [PokemonType.Grass] = 0.5,
                    [PokemonType.Water] = 0.5,                    
                },

                [PokemonType.Fire] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Grass] = 2.0,
                    [PokemonType.Bug] = 2.0,
                    [PokemonType.Water] = 0.5,
                    [PokemonType.Rock] = 0.5,
                    [PokemonType.Fire] = 0.5,
                },

                [PokemonType.Grass] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Water] = 2.0,
                    [PokemonType.Ground] = 2.0,
                    [PokemonType.Rock] = 2.0,
                    [PokemonType.Fire] = 0.5,
                    [PokemonType.Bug] = 0.5,
                    [PokemonType.Grass] = 0.5,
                    [PokemonType.Poison] = 0.5,
                },

                [PokemonType.Electric] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Water] = 2.0,
                    [PokemonType.Grass] = 0.5,
                    [PokemonType.Electric] = 0.5,
                    [PokemonType.Ground] = 0.0,
                },

                [PokemonType.Rock] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Fire] = 2.0,
                    [PokemonType.Bug] = 2.0,
                    [PokemonType.Ground] = 0.5,
                    [PokemonType.Grass] = 0.5,
                },

                [PokemonType.Ground] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Rock] = 2.0,
                    [PokemonType.Electric] = 2.0,
                    [PokemonType.Bug] = 0.5,
                    [PokemonType.Poison] = 2.0,
                    [PokemonType.Grass] = 0.5,
                },

                [PokemonType.Ghost] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Ghost] = 2.0,
                    [PokemonType.Psychic] = 2.0,                    
                },

                [PokemonType.Poison] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Rock] = 0.5,
                    [PokemonType.Ground] = 0.5,
                    [PokemonType.Ghost] = 0.5,                    
                    [PokemonType.Poison] = 0.5,
                    [PokemonType.Grass] = 2.0,
                },

                [PokemonType.Psychic] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Poison] = 2.0,
                    [PokemonType.Psychic] = 0.5,
                },

                [PokemonType.Bug] = new Dictionary<PokemonType, double>
                {
                    [PokemonType.Fire] = 0.5,
                    [PokemonType.Psychic] = 2.0,
                    [PokemonType.Ghost] = 0.5,
                    [PokemonType.Poison] = 0.5,
                    [PokemonType.Grass] = 2.0,
                },
            };

        // Calcula el modificador total considerando tipos dobles
        public static double GetEffectiveness(PokemonType attackType, List<PokemonType> defendTypes)
        {
            double modifier = 1.0;

            foreach (var defendType in defendTypes)
            {
                double value = 1.0;
                if (effectiveness.ContainsKey(attackType) &&
                    effectiveness[attackType].ContainsKey(defendType))
                {
                    value = effectiveness[attackType][defendType];
                }

                modifier *= value;
            }

            return modifier;
        }

        public static double GetEffectiveness(PokemonType attackType, PokemonType defendType)
        {
            return GetEffectiveness(attackType, new List<PokemonType> { defendType });
        }
    }
}

