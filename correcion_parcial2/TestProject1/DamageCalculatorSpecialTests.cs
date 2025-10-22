using NUnit.Framework;
using System;

namespace TestProject1
{
    [TestFixture]
    public class DamageCalculatorSpecialTests
    {
        private double CalcularDanioEspecial(Pokemon atacante, Pokemon defensor, Move movimiento, double mod)
        {
            if (mod == 0)
                return 0;

            double atk = atacante.SpAttack;
            double def = defensor.SpDefense;

            double nivelFactor = (2 * (atacante.Level / 5.0)) + 2;
            double formula = ((nivelFactor) * (movimiento.BasePower * (atk / def) + 2)) / 50.0;
            double dmg = formula * mod;

            return Math.Round(dmg, MidpointRounding.AwayFromZero);
        }

        //  Casos del profesor
        [TestCase(1, 1, 1, 1, 0, 0)]
        [TestCase(1, 1, 1, 1, 1, 1)]
        [TestCase(5, 50, 100, 50, 2, 16)]
        [TestCase(5, 50, 100, 50, 1, 5)]
        [TestCase(10, 20, 30, 15, 1, 5)]
        [TestCase(12, 40, 60, 80, 2, 9)]
        [TestCase(25, 80, 120, 60, 1, 40)]
        [TestCase(30, 100, 50, 100, 4, 58)]
        [TestCase(40, 150, 200, 150, 1, 37)]
        [TestCase(50, 128, 200, 100, 1, 58)]
        [TestCase(50, 128, 200, 100, 4, 455)]
        [TestCase(60, 200, 250, 200, 1, 132)]
        [TestCase(70, 180, 200, 100, 2, 435)]
        [TestCase(80, 90, 45, 90, 1, 33)]
        [TestCase(90, 255, 200, 50, 2, 1554)]
        [TestCase(99, 255, 255, 1, 2, 108206)]
        [TestCase(99, 255, 255, 255, 4, 856)]
        [TestCase(99, 255, 255, 255, 0, 0)]
        [TestCase(99, 255, 1, 255, 1, 2)]
        [TestCase(45, 60, 10, 200, 1, 2)]
        [TestCase(20, 30, 5, 250, 1, 1)]
        [TestCase(2, 10, 1, 255, 1, 1)]
        [TestCase(3, 5, 2, 3, 1, 1)]
        [TestCase(15, 200, 255, 255, 1, 33)]
        [TestCase(16, 200, 200, 254, 1, 34)]
        [TestCase(17, 200, 255, 128, 1, 36)]
        [TestCase(33, 77, 77, 77, 1, 25)]
        [TestCase(48, 33, 99, 11, 4, 508)]
        [TestCase(55, 44, 88, 22, 1, 44)]
        [TestCase(66, 11, 11, 11, 1, 8)]
        [TestCase(77, 123, 200, 100, 2, 326)]
        [TestCase(88, 200, 100, 50, 4, 1197)]
        [TestCase(10, 200, 200, 200, 0, 0)]
        [TestCase(50, 255, 100, 50, 0, 0)]
        [TestCase(75, 180, 255, 180, 0, 0)]
        [TestCase(99, 255, 255, 1, 0, 0)]
        [TestCase(25, 60, 40, 20, 0, 0)]
        [TestCase(60, 100, 255, 128, 1, 40)]
        [TestCase(80, 90, 45, 90, 1, 17)]
        [TestCase(99, 200, 150, 150, 1, 84)]
        public void DebeCalcularDanioEspecial(
            int level, int basePower, int atk, int def, double mod, double esperado)
        {
            var attacker = new Pokemon("Atacante", PokemonType.Fire)
            {
                Level = level,
                SpAttack = atk
            };

            var defender = new Pokemon("Defensor", PokemonType.Grass)
            {
                SpDefense = def
            };

            var move = new Move("Golpe Especial", PokemonType.Fire, Move.MoveType.Special, basePower);

            double dmg = CalcularDanioEspecial(attacker, defender, move, mod);

            Assert.That(dmg, Is.EqualTo(esperado).Within(1),
                $"Error especial → LV:{level} SpATK:{atk} SpDEF:{def} MOD:{mod}");
        }
    }
}
