using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject1.Tests
{
    public class TypeChartTests
    {
        // --- PRUEBAS BÁSICAS (tipo simple) ---

        [TestCase(PokemonType.Water, PokemonType.Fire, 2.0)]
        [TestCase(PokemonType.Water, PokemonType.Grass, 0.5)]
        [TestCase(PokemonType.Fire, PokemonType.Grass, 2.0)]
        [TestCase(PokemonType.Fire, PokemonType.Rock, 0.5)]
        [TestCase(PokemonType.Grass, PokemonType.Water, 2.0)]
        [TestCase(PokemonType.Grass, PokemonType.Fire, 0.5)]
        [TestCase(PokemonType.Ghost, PokemonType.Psychic, 2.0)]
        [TestCase(PokemonType.Electric, PokemonType.Water, 2.0)]
        [TestCase(PokemonType.Electric, PokemonType.Ground, 0.0)]
        [TestCase(PokemonType.Poison, PokemonType.Grass, 2.0)]
        [TestCase(PokemonType.Psychic, PokemonType.Poison, 2.0)]
        [TestCase(PokemonType.Bug, PokemonType.Psychic, 2.0)]
        public void GetEffectiveness_TipoSimple_DeberiaDevolverValorEsperado(
            PokemonType attack, PokemonType defend, double expected)
        {
            double result = TypeChart.GetEffectiveness(attack, defend);
            Assert.That(result, Is.EqualTo(expected));
        }

        // --- PRUEBAS CON TIPOS DOBLES (multiplicación del MOD) ---

        [Test]
        public void GrassVsRockGround_DeberiaSer4x()
        {
            var defenderTypes = new List<PokemonType> { PokemonType.Rock, PokemonType.Ground };
            double result = TypeChart.GetEffectiveness(PokemonType.Grass, defenderTypes);
            Assert.That(result, Is.EqualTo(4.0));
        }

        [Test]
        public void FireVsBugGrass_DeberiaSer4x()
        {
            var defenderTypes = new List<PokemonType> { PokemonType.Bug, PokemonType.Grass };
            double result = TypeChart.GetEffectiveness(PokemonType.Fire, defenderTypes);
            Assert.That(result, Is.EqualTo(4.0));
        }

        [Test]
        public void ElectricVsWaterGround_DeberiaSer0x()
        {
            var defenderTypes = new List<PokemonType> { PokemonType.Water, PokemonType.Ground };
            double result = TypeChart.GetEffectiveness(PokemonType.Electric, defenderTypes);
            Assert.That(result, Is.EqualTo(0.0));
        }

        [Test]
        public void WaterVsFireRock_DeberiaSer4x()
        {
            var defenderTypes = new List<PokemonType> { PokemonType.Fire, PokemonType.Rock };
            double result = TypeChart.GetEffectiveness(PokemonType.Water, defenderTypes);
            Assert.That(result, Is.EqualTo(4.0));
        }

        [Test]
        public void PoisonVsGrassBug_DeberiaSer1x()
        {
            // Poison → Grass = 2x
            // Poison → Bug = 0.5x → 2 * 0.5 = 1.0
            var defenderTypes = new List<PokemonType> { PokemonType.Grass, PokemonType.Bug };
            double result = TypeChart.GetEffectiveness(PokemonType.Poison, defenderTypes);
            Assert.That(result, Is.EqualTo(1.0));
        }

        // --- USANDO INSTANCIAS DE POKÉMON (como pide el profe) ---

        [Test]
        public void ChorrotugaRecibeAtaqueElectric_DeberiaSer2x()
        {
            var chorrotuga = new Chorrotuga();
            double mod = TypeChart.GetEffectiveness(PokemonType.Electric, chorrotuga.Types);
            Assert.That(mod, Is.EqualTo(2.0));
        }

        [Test]
        public void ChorrotugaRecibeAtaqueGrass_DeberiaSer2x()
        {
            var chorrotuga = new Chorrotuga();
            double mod = TypeChart.GetEffectiveness(PokemonType.Grass, chorrotuga.Types);
            Assert.That(mod, Is.EqualTo(2.0));
        }

        [Test]
        public void ChorrotugaRecibeAtaqueFire_DeberiaSer0_5x()
        {
            var chorrotuga = new Chorrotuga();
            double mod = TypeChart.GetEffectiveness(PokemonType.Fire, chorrotuga.Types);
            Assert.That(mod, Is.EqualTo(0.5));
        }
    }
}