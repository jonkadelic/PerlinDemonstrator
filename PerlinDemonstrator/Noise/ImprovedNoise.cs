﻿namespace PerlinDemonstrator.Noise;

using JavaImports;

public class ImprovedNoise : BaseImprovedNoise
{
    public ImprovedNoise(Random random) : base(random)
    {
    }

    public override void Add(double[] densityArray, double x, double y, double z,
                    int xSize, int ySize, int zSize, double xScale, double yScale,
                    double zScale, double levelScale)
    {
        if(ySize == 1)
        {
            int j3 = 0;
            double d12 = 1.0D / levelScale;
            for(int i4 = 0; i4 < xSize; i4++)
            {
                double d14 = (x + (double)i4) * xScale + xo;
                int j4 = (int)d14;
                if(d14 < (double)j4)
                {
                    j4--;
                }
                int k4 = j4 & 0xff;
                d14 -= j4;
                double d17 = d14 * d14 * d14 * (d14 * (d14 * 6D - 15D) + 10D);
                for(int l4 = 0; l4 < zSize; l4++)
                {
                    double d19 = (z + (double)l4) * zScale + zo;
                    int j5 = (int)d19;
                    if(d19 < (double)j5)
                    {
                        j5--;
                    }
                    int l5 = j5 & 0xff;
                    d19 -= j5;
                    double d21 = d19 * d19 * d19 * (d19 * (d19 * 6D - 15D) + 10D);
                    int l = p[k4] + 0;
                    int j1 = p[l] + l5;
                    int k1 = p[k4 + 1] + 0;
                    int l1 = p[k1] + l5;
                    double d9 = Lerp(d17, Grad(p[j1], d14, d19), Grad(p[l1], d14 - 1.0D, 0.0D, d19));
                    double d11 = Lerp(d17, Grad(p[j1 + 1], d14, 0.0D, d19 - 1.0D), Grad(p[l1 + 1], d14 - 1.0D, 0.0D, d19 - 1.0D));
                    double d23 = Lerp(d21, d9, d11);
                    densityArray[j3++] += d23 * d12;
                }

            }
            return;
        }
        if(zSize == 1)
        {
            int j3 = 0;
            double d12 = 1.0D / levelScale;
            for(int i4 = 0; i4 < xSize; i4++)
            {
                double d14 = (x + (double)i4) * xScale + xo;
                int j4 = (int)d14;
                if(d14 < (double)j4)
                {
                    j4--;
                }
                int k4 = j4 & 0xff;
                d14 -= j4;
                double d17 = d14 * d14 * d14 * (d14 * (d14 * 6D - 15D) + 10D);
                for(int l4 = 0; l4 < ySize; l4++)
                {
                    double d19 = (y + (double)l4) * yScale + zo;
                    int j5 = (int)d19;
                    if(d19 < (double)j5)
                    {
                        j5--;
                    }
                    int l5 = j5 & 0xff;
                    d19 -= j5;
                    double d21 = d19 * d19 * d19 * (d19 * (d19 * 6D - 15D) + 10D);
                    int l = p[k4] + 0;
                    int j1 = p[l] + l5;
                    int k1 = p[k4 + 1] + 0;
                    int l1 = p[k1] + l5;
                    double d9 = Lerp(d17, Grad(p[j1], d14, d19), Grad(p[l1], d14 - 1.0D, 0.0D, d19));
                    double d11 = Lerp(d17, Grad(p[j1 + 1], d14, 0.0D, d19 - 1.0D), Grad(p[l1 + 1], d14 - 1.0D, 0.0D, d19 - 1.0D));
                    double d23 = Lerp(d21, d9, d11);
                    densityArray[j3++] += d23 * d12;
                }

            }

            return;
        }
        int i1 = 0;
        double d7 = 1.0D / levelScale;
        int i2 = -1;
        double d13 = 0.0D;
        double d15 = 0.0D;
        double d16 = 0.0D;
        double d18 = 0.0D;
        for(int i5 = 0; i5 < xSize; i5++)
        {
            double d20 = (x + (double)i5) * xScale + xo;
            int k5 = (int)d20;
            if(d20 < (double)k5)
            {
                k5--;
            }
            int i6 = k5 & 0xff;
            d20 -= k5;
            double d22 = d20 * d20 * d20 * (d20 * (d20 * 6D - 15D) + 10D);
            for(int j6 = 0; j6 < zSize; j6++)
            {
                double d24 = (z + (double)j6) * zScale + zo;
                int k6 = (int)d24;
                if(d24 < (double)k6)
                {
                    k6--;
                }
                int l6 = k6 & 0xff;
                d24 -= k6;
                double d25 = d24 * d24 * d24 * (d24 * (d24 * 6D - 15D) + 10D);
                for(int i7 = 0; i7 < ySize; i7++)
                {
                    double d26 = (y + (double)i7) * yScale + yo;
                    int j7 = (int)d26;
                    if(d26 < (double)j7)
                    {
                        j7--;
                    }
                    int k7 = j7 & 0xff;
                    d26 -= j7;
                    double d27 = d26 * d26 * d26 * (d26 * (d26 * 6D - 15D) + 10D);
                    if(i7 == 0 || k7 != i2)
                    {
                        i2 = k7;
                        int j2 = p[i6] + k7;
                        int k2 = p[j2] + l6;
                        int l2 = p[j2 + 1] + l6;
                        int i3 = p[i6 + 1] + k7;
                        int k3 = p[i3] + l6;
                        int l3 = p[i3 + 1] + l6;
                        d13 = Lerp(d22, Grad(p[k2], d20, d26, d24), Grad(p[k3], d20 - 1.0D, d26, d24));
                        d15 = Lerp(d22, Grad(p[l2], d20, d26 - 1.0D, d24), Grad(p[l3], d20 - 1.0D, d26 - 1.0D, d24));
                        d16 = Lerp(d22, Grad(p[k2 + 1], d20, d26, d24 - 1.0D), Grad(p[k3 + 1], d20 - 1.0D, d26, d24 - 1.0D));
                        d18 = Lerp(d22, Grad(p[l2 + 1], d20, d26 - 1.0D, d24 - 1.0D), Grad(p[l3 + 1], d20 - 1.0D, d26 - 1.0D, d24 - 1.0D));
                    }
                    double d28 = Lerp(d27, d13, d15);
                    double d29 = Lerp(d27, d16, d18);
                    double d30 = Lerp(d25, d28, d29);
                    densityArray[i1++] += d30 * d7;
                }

            }

        }

    }

}