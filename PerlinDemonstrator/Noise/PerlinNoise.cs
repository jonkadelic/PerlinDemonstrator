namespace PerlinDemonstrator.Noise;

using JavaImports;

public class PerlinNoise : BasePerlinNoise<ImprovedNoise>
{
    public PerlinNoise(long seed, int levels) : base(seed, levels)
    {
    }

    public PerlinNoise(long seed, int levels, int preLevels) : base(seed, levels, preLevels)
    {
    }
    
    protected override ImprovedNoise[] NewNoiseLevels(Random random, int numLevels)
    {
        ImprovedNoise[] levels = new ImprovedNoise[numLevels];

        for (int i = 0; i < numLevels; i++)
        {
            levels[i] = new ImprovedNoise(random);
        }

        return levels;
    }

}