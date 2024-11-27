namespace PerlinDemonstrator.Noise;

using JavaImports;

public class PerlinSimplexNoise : SurfaceNoise
{
    private readonly SimplexNoise[] noiseLevels;
    private readonly int levels;

    public PerlinSimplexNoise(Random random, int levels)
    {
        this.levels = levels;
        noiseLevels = new SimplexNoise[levels];
        for(int i = 0; i < levels; i++)
        {
            noiseLevels[i] = new SimplexNoise(random);
        }
    }

    public double GetMaximumValue()
    {
        return GetMaximumValue(0.5);
    }

    // Gets the maximum value for a given value of d5. For those values, the range is from -getMaximumValue to getMaximumValue.
    public double GetMaximumValue(double d5)
    {
        double max = 0.0;

        double scaleB = 1.0;
        for (int l = 0; l < levels; l++)
        {
            max += 1.0 * (0.55D / scaleB);
            scaleB *= d5;
        }

        return max;
    }

    public double[] GetValue(double[] outValue, double x, double z, int xSize, int zSize, double xScale, double zScale, double d4)
    {
        return GetValue(outValue, x, z, xSize, zSize, xScale, zScale, d4, 0.5D);
    }

    public double[] GetValue(double[] outValue, double x, double z, int xSize, int zSize, double xScale, double zScale, double d4, double d5)
    {
        xScale /= 1.5D;
        zScale /= 1.5D;

        if (outValue == null || outValue.Length < xSize * zSize)
        {
            outValue = new double[xSize * zSize];
        }
        else
        {
            Array.Fill(outValue, 0.0D);
        }

        double scaleA = 1.0D;
        double scaleB = 1.0D;
        for(int l = 0; l < levels; l++)
        {
            noiseLevels[l].Add(outValue, x, z, xSize, zSize, xScale * scaleA, zScale * scaleA, 0.55D / scaleB);
            scaleA *= d4;
            scaleB *= d5;
        }

        return outValue;
    }

}