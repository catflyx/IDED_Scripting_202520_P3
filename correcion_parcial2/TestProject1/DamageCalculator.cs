using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public static class DamageCalculator
    {
        public static double CalculateDamage(
            int level,
            int basePower,
            int attack,
            int defense,
            double mod)
        {
            if (mod == 0)
                return 0; // Si el modificador es 0, no hay daño.

            double nivelFactor = (2 * (level / 5.0)) + 2;
            double formula = ((nivelFactor) * (basePower * (attack / (double)defense) + 2)) / 50.0;
            double damage = formula * mod;

            return Math.Floor(damage);
        }
    }
}
