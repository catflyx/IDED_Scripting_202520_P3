using NUnit.Framework;
using System;

namespace TestProject1
{
    [TestFixture]
    public class DamageCalculatorDualModeTests
    {
        // Método auxiliar reutilizando la fórmula del profe
        private double CalcularDanio(
            Pokemon atacante, Pokemon defensor, Move movimiento, double mod)
        {
            if (mod == 0)
                return 0;

            double atk = movimiento.moveType == Move.MoveType.Physical ? atacante.Attack : atacante.SpAttack;
            double def = movimiento.moveType == Move.MoveType.Physical ? defensor.Defense : defensor.SpDefense;

            double nivelFactor = (2 * (atacante.Level / 5.0)) + 2;
            double formula = ((nivelFactor) * (movimiento.BasePower * (atk / def) + 2)) / 50.0;
            double dmg = formula * mod;

            return Math.Round(dmg, MidpointRounding.AwayFromZero);
        }

        //  Casos seleccionados (físico y especial)
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
        public void DebeCalcularDanio_FisicoYEspecial(
            int level, int basePower, int atk, int def, double mod, double esperado)
        {
            //  Creamos el atacante y el defensor
            var atacante = new Pokemon("Atacante", PokemonType.Fire)
            {
                Level = level,
                Attack = atk,
                SpAttack = atk
            };

            var defensor = new Pokemon("Defensor", PokemonType.Grass)
            {
                Defense = def,
                SpDefense = def
            };

            //  Prueba con movimiento FÍSICO
            var moveFisico = new Move("Golpe Físico", PokemonType.Fire, Move.MoveType.Physical, basePower);
            double dmgFisico = CalcularDanio(atacante, defensor, moveFisico, mod);

            //   Prueba con movimiento ESPECIAL
            var moveEspecial = new Move("Golpe Especial", PokemonType.Fire, Move.MoveType.Special, basePower);
            double dmgEspecial = CalcularDanio(atacante, defensor, moveEspecial, mod);

            //  Comprobaciones
            Assert.Multiple(() =>
            {
                Assert.That(dmgFisico, Is.EqualTo(esperado)
                    .Within(1),
                    $"Físico: LV:{level} ATK:{atk} DEF:{def} MOD:{mod}");

                Assert.That(dmgEspecial, Is.EqualTo(esperado)
                    .Within(1),
                    $"Especial: LV:{level} SpATK:{atk} SpDEF:{def} MOD:{mod}");
            });
        }
    }
}
