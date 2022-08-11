using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Random = PerlinDemonstrator.JavaImports.Random;

namespace PerlinDemonstrator
{
    public class BiomeProvider
    {
        protected NoiseGeneratorOctaves2 temperatureNoise;
        protected NoiseGeneratorOctaves2 humidityNoise;
        protected NoiseGeneratorOctaves2 fuzzinessNoise;

        public double[]? temperatures;
        public double[]? humidities;
        public double[]? fuzziness;

        public BiomeProvider(long seed)
        {
            temperatureNoise = new NoiseGeneratorOctaves2(new Random(seed * 9871L), 4);
            humidityNoise = new NoiseGeneratorOctaves2(new Random(seed * 39811L), 4);
            fuzzinessNoise = new NoiseGeneratorOctaves2(new Random(seed * 0x84a59L), 2);
        }

        public (double temperature, double humidity) GetBiomeAtBlock(int x, int z)
        {
            temperatures = temperatureNoise.func_4112_a(temperatures, x, z, 1, 1, 0.025D, 0.025D, 0.25D);
            humidities = humidityNoise.func_4112_a(humidities, x, z, 1, 1, 0.05D, 0.05D, 0.3D);
            fuzziness = fuzzinessNoise.func_4112_a(fuzziness, x, z, 1, 1, 0.25D, 0.25D, 0.5D);

            int i = 0;
            double d = fuzziness[i] * 1.1D + 0.5D;
            double d1 = 0.01D;
            double d2 = 1.0D - d1;
            double temperature = (temperatures[i] * 0.15D + 0.7D) * d2 + d * d1;
            d1 = 0.002D;
            d2 = 1.0D - d1;
            double humidity = (humidities[i] * 0.15D + 0.5D) * d2 + d * d1;
            temperature = 1.0D - (1.0D - temperature) * (1.0D - temperature);
            if (temperature < 0.0D)
            {
                temperature = 0.0D;
            }
            if (humidity < 0.0D)
            {
                humidity = 0.0D;
            }
            if (temperature > 1.0D)
            {
                temperature = 1.0D;
            }
            if (humidity > 1.0D)
            {
                humidity = 1.0D;
            }

            return (temperature, humidity);
        }

    }
}
