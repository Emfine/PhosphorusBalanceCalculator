using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhosphorusBalanceCalculator.Helper
{
    public class MathHelper
    {
        public static decimal CalcDiet(decimal c)
        {
            decimal diet = c * 7m;
            return diet;
        }

        public static decimal CalcDialysis(decimal a, decimal b, decimal d, decimal e, decimal f, decimal g, decimal h, decimal q)
        {
            decimal beta = CalcBeta(h);
            decimal dialysis = (80.3m * f - 0.024m * a + 0.07m * b + beta * h - 8.14m + g * (e - 4m) * 0.06m * q) * d * 31m;
            return dialysis;
        }

        public static decimal CalcBeta(decimal h)
        {
            decimal beta = 6.231m / 1000m * h - 1.886m / 100000m * h * h - 0.467m;
            return beta;
        }

        public static decimal CalcDrug(decimal i, decimal j, decimal k, decimal l, decimal m, decimal n, decimal o, decimal p)
        {
            decimal tsg = CalcTSG(i, j);
            decimal csg = CalcCSG(k, l);
            decimal tsswlm = CalcTSSWLM(m, n);
            decimal tsl = CalcTSL(o, p);
            decimal drug = tsg + csg + tsswlm + tsl;
            return drug;
        }

        public static decimal CalcTSG(decimal i, decimal j)
        {
            decimal tsg = i * j * 23.36m / 500;
            return tsg;
        }

        public static decimal CalcCSG(decimal k, decimal l)
        {
            decimal csg = k * l * 29.5m / 667m;
            return csg;
        }

        public static decimal CalcTSSWLM(decimal m, decimal n)
        {
            decimal tsswlm = m * n * 21m / 800m;
            return tsswlm;
        }

        public static decimal CalcTSL(decimal o, decimal p)
        {
            decimal tsl = o * p * 67.5m / 500m;
            return tsl;
        }
    }
}