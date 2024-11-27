namespace PerlinDemonstrator.Noise;

using JavaImports;

public abstract class BasePerlinNoise<T> : SurfaceNoise
where T: BaseImprovedNoise
{
    private readonly T[] noiseLevels;
    private readonly int levels;

    public BasePerlinNoise(long seed, int levels) : this(seed, levels, 0)
    {
    }

    public BasePerlinNoise(long seed, int levels, int preLevels)
    {
        Random random = new Random(seed);

        for (int i = 0; i < preLevels; i++)
        {
            random.NextDouble();
            random.NextDouble();
            random.NextDouble();

            for (int j = 0; j < 256; j++)
            {
                random.NextInt(256 - j);
            }
        }
        this.levels = levels;
        this.noiseLevels = NewNoiseLevels(random, levels);
    }

    protected abstract T[] NewNoiseLevels(Random random, int numLevels);

    public double Get(double x, double y)
    {
        double outVal = 0.0D;
        double levelScale = 1.0D;

        for(int i = 0; i < levels; i++)
        {
            outVal += noiseLevels[i].GetValue(x * levelScale, y * levelScale) / levelScale;
            levelScale /= 2;
        }

        return outVal;
    }

    public double[] Get(double[] noiseArray, double x, double y, double z,
        int xSize, int ySize, int zSize, double scaleX, double scaleY,
        double scaleZ)
    {
        if (noiseArray == null)
        {
            noiseArray = new double[xSize * ySize * zSize];
        }
        else
        {
            Array.Fill(noiseArray, 0.0D);
        }

        double levelScale = 1.0D;
        for(int i = 0; i < levels; i++)
        {
            noiseLevels[i].Add(noiseArray, x, y, z, xSize, ySize, zSize, scaleX * levelScale, scaleY * levelScale, scaleZ * levelScale, levelScale);
            levelScale /= 2D;
        }

        return noiseArray;
    }

    public double[] Get(double[] densityArray, int x, int z, int xSize, int zSize, double scaleX, double scaleZ)
    {
        return Get(densityArray, x, 0, z, xSize, 1, zSize, scaleX, 1.0, scaleZ);
    }

}