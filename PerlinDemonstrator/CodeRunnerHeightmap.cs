using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinDemonstrator
{
    internal class CodeRunnerHeightmap : CodeRunner<float[,]>
    {
        public override string SetupCode { get; set; } = $"using PerlinDemonstrator;\nusing PerlinDemonstrator.JavaImports;\n\nfloat[,] data = new float[{DisplayWidth}, {DisplayWidth}];\nRandom rand = new(DateTime.Now.Ticks);";
        public override string LogFile { get; set; } = "last.txt";
        public override string EndCode { get; set; } = "return data;";

        protected override void PopulateBitmap(float[,] result, Bitmap bitmap)
        {
            float min = float.PositiveInfinity, max = float.NegativeInfinity, range = 0;

            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    float val = result[x, y];
                    min = Math.Min(min, val);
                    max = Math.Max(max, val);
                }
            }

            range = max - min;

            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(1); y++)
                {
                    float normalised = (result[x, y] - min) / range;

                    if (normalised < 0.475f)
                    {
                        float normalised2 = normalised / 0.475f;
                        byte blue = (byte)(normalised2 * 128 + 127);
                        bitmap.SetPixel(x, y, Color.FromArgb(0, 0, blue));
                    }
                    else if (normalised > 0.525f)
                    {
                        float normalised2 = (normalised - 0.525f) / 0.475f;
                        byte green = (byte)(normalised2 * 128 + 127);
                        bitmap.SetPixel(x, y, Color.FromArgb(0, green, 0));
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.SandyBrown);
                    }
                }
            }
        }
    }
}
