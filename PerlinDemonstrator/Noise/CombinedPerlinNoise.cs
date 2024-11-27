namespace PerlinDemonstrator.Noise;

public class CombinedPerlinNoise<T>
where T: BaseImprovedNoise
{
    private readonly BasePerlinNoise<T> perlinNoiseA;
    private readonly BasePerlinNoise<T> perlinNoiseB;

    public CombinedPerlinNoise(BasePerlinNoise<T> perlinNoiseA, BasePerlinNoise<T> perlinNoiseB) {
        this.perlinNoiseA = perlinNoiseA;
        this.perlinNoiseB = perlinNoiseB;
    }

    public double Get(double x, double y)
    {
        return this.perlinNoiseA.Get(x + this.perlinNoiseB.Get(x, y), y);
    }

}