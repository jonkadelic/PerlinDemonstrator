namespace PerlinDemonstrator
{
    public class NoiseGeneratorOctaves : NoiseGenerator
    {

        public NoiseGeneratorOctaves(JavaImports.Random random, int i)
        {
            field_1191_b = i;
            generatorCollection = new NoiseGeneratorPerlin[i];
            for (int j = 0; j < i; j++)
            {
                generatorCollection[j] = new NoiseGeneratorPerlin(random);
            }

        }

        public double get2D(double x, double y)
        {
            double d2 = 0.0D;
            double d3 = 1.0D;
            for (int i = 0; i < field_1191_b; i++)
            {
                d2 += generatorCollection[i].func_801_a(x * d3, y * d3) / d3;
                d3 /= 2D;
            }

            return d2;
        }

        public double[] generateNoiseOctaves(double[] ad, double d, double d1, double d2,
                int i, int j, int k, double d3, double d4,
                double d5)
        {
            if (ad == null)
            {
                ad = new double[i * j * k];
            }
            else
            {
                for (int l = 0; l < ad.Length; l++)
                {
                    ad[l] = 0.0D;
                }

            }
            double d6 = 1.0D;
            for (int i1 = 0; i1 < field_1191_b; i1++)
            {
                generatorCollection[i1].func_805_a(ad, d, d1, d2, i, j, k, d3 * d6, d4 * d6, d5 * d6, d6);
                d6 /= 2D;
            }

            return ad;
        }

        private NoiseGeneratorPerlin[] generatorCollection;
        private int field_1191_b;
    }
}