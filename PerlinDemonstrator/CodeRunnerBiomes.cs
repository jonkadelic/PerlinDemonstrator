using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerlinDemonstrator
{
    internal class CodeRunnerBiomes : CodeRunner<int[,]>
    {
        public override string LogFile { get; set; } = "last_biomes.txt";
        public override string SetupCode { get; set; } =
@"using PerlinDemonstrator;
using PerlinDemonstrator.JavaImports;

int[,] data = new int" + $"[{DisplayWidth}, {DisplayWidth}];" +
@"
int rainforest =        0x08FA36;
int swampland =         0x00FFB3;
int seasonalForest =    0x9BE023;
int forest =            0x056621;
int grasslands =        0xD9E023;
int outback =           0xD96223;
int shrubland =         0xA1AD20;
int taiga =             0xEDFFFE;
int borealForest =      0x4DC972;
int desert =            0xFFFB00;
int plains =            0xFFFB82;
int glacier =           0xFFED93;
int tundra =            0x57EBF9;
int meadow =            0x6A9993;
int birchForest =       0x6738FF;

BiomeProvider bp = new BiomeProvider(DateTime.Now.Ticks);

for (int x = 0; x < " + DisplayWidth + @"; x++)
{
    for (int z = 0; z < " + DisplayWidth + @"; z++)
    {
        (double temperature, double humidity) = bp.GetBiomeAtBlock(x, z);
        int color = 0x000000;
        bool colorSet = false;

        void setColor(int c) { if (!colorSet) { color = c; colorSet = true; } }

";
        public override string EndCode { get; set; } =
@"        data[x, z] = color;
    }
}

return data;";

        protected override void PopulateBitmap(int[,] result, Bitmap bitmap)
        {
            for (int x = 0; x < result.GetLength(0); x++)
            {
                for (int y = 0; y < result.GetLength(0); y++)
                {
                    int opaqueResult = (int)(result[x, y] | 0xFF000000);
                    bitmap.SetPixel(x, y, Color.FromArgb(opaqueResult));
                }
            }
        }
    }
}
