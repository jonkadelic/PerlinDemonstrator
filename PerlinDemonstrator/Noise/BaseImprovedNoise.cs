namespace PerlinDemonstrator.Noise;

using JavaImports;

public abstract class BaseImprovedNoise
{
    protected readonly int[] p;
    public readonly double xo;
    public readonly double yo;
    public readonly double zo;

    public BaseImprovedNoise(Random random) {
        this.p = new int[512];
        this.xo = random.NextDouble() * 256;
        this.yo = random.NextDouble() * 256;
        this.zo = random.NextDouble() * 256;

        // Assign initial values for each permutation
        for (var i = 0; i < 256; i++)
        {
            p[i] = i;
        }

        // Shuffle values
        for(var i = 0; i < 256; i++)
        {
            var newI = random.NextInt(256 - i) + i;
            (this.p[i], this.p[newI]) = (this.p[newI], this.p[i]);
            this.p[i + 256] = this.p[i];
        }
    }

    public double GetValue(double x, double y)
    {
        return this.GetValue(x, y, 0);
    }

    public double GetValue(double x, double y, double z)
    {
        int X = (int)((long)Math.Floor(x) & 255),                  // FIND UNIT CUBE THAT
            Y = (int)((long)Math.Floor(y) & 255),                  // CONTAINS POINT.
            Z = (int)((long)Math.Floor(z) & 255);
        x -= Math.Floor(x);                                // FIND RELATIVE X,Y,Z
        y -= Math.Floor(y);                                // OF POINT IN CUBE.
        z -= Math.Floor(z);
        double u = Fade(x),                                // COMPUTE FADE CURVES
               v = Fade(y),                                // FOR EACH OF X,Y,Z.
               w = Fade(z);
        int A = p[X  ]+Y, AA = p[A]+Z, AB = p[A+1]+Z,      // HASH COORDINATES OF
            B = p[X+1]+Y, BA = p[B]+Z, BB = p[B+1]+Z;      // THE 8 CUBE CORNERS,

        return Lerp(w, Lerp(v, Lerp(u, Grad(p[AA  ], x  , y  , z   ),  // AND ADD
                                                            Grad(p[BA  ], x-1, y  , z   )), // BLENDED
                                             Lerp(u, Grad(p[AB  ], x  , y-1, z   ),  // RESULTS
                                                            Grad(p[BB  ], x-1, y-1, z   ))),// FROM  8
                              Lerp(v, Lerp(u, Grad(p[AA+1], x  , y  , z-1 ),  // CORNERS
                                                            Grad(p[BA+1], x-1, y  , z-1 )), // OF CUBE
                                             Lerp(u, Grad(p[AB+1], x  , y-1, z-1 ),
                                                         Grad(p[BB+1], x-1, y-1, z-1 ))));
    }

    protected double Grad(int hash, double x, double y)
    {
        int j = hash & 0xf;
        double d2 = (double)(1 - ((j & 8) >> 3)) * x;
        double d3 = j >= 4 ? j != 12 && j != 14 ? y : x : 0.0D;
        return ((j & 1) != 0 ? -d2 : d2) + ((j & 2) != 0 ? -d3 : d3);
    }

    protected double Fade(double t)
    {
        return t * t * t * (t * (t * 6 - 15) + 10);
    }

    protected double Lerp(double t, double a, double b)
    {
        return a + t * (b - a);
    }

    protected double Grad(int hash, double x, double y, double z)
    {
        int h = hash & 15;                      // CONVERT LO 4 BITS OF HASH CODE
        double u = h<8 ? x : y,                 // INTO 12 GRADIENT DIRECTIONS.
                v = h<4 ? y : h==12||h==14 ? x : z;
        return ((h&1) == 0 ? u : -u) + ((h&2) == 0 ? v : -v);
    }

    public abstract void Add(double[] arr, double x, double y, double z, int xSize, int ySize, int zSize, double xScale, double yScale, double zScale, double levelScale);

}