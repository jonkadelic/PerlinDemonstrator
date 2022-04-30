using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

using PerlinDemonstrator.JavaImports;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PerlinDemonstrator
{
    public partial class FormMain : Form
    {
        const int WIDTH = 512;

        public FormMain()
        {
            InitializeComponent();

            try
            {
                FileStream file = File.Open("last.txt", FileMode.Open);
                StreamReader sr = new(file);
                textBox1.Text = sr.ReadToEndAsync().Result;
                sr.Close();
            }
            catch (Exception)
            {
            }

            labelSetupVariables.Text = $"using PerlinDemonstrator;\nusing PerlinDemonstrator.JavaImports;\n\nfloat[,] data = new float[{WIDTH}, {WIDTH}];\nRandom rand = new(DateTime.Now.Ticks);";

            btnExecute.Click += BtnExecute_ClickAsync;
            textBox1.PreviewKeyDown += TextBox1_PreviewKeyDownAsync;
        }

        private async void TextBox1_PreviewKeyDownAsync(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int selectionStart = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(textBox1.SelectionStart, "    ");
                textBox1.SelectionStart = selectionStart + 4;
                e.IsInputKey = false;
            }
            if (e.KeyCode == Keys.S && e.Control)
            {
                FileStream file = File.Open("last.txt", FileMode.Create);
                StreamWriter writer = new(file);
                await writer.WriteAsync(textBox1.Text);
                writer.Close();
                e.IsInputKey = false;
            }
        }

        private async void BtnExecute_ClickAsync(object? sender, EventArgs e)
        {
            string code = labelSetupVariables.Text + "\n" + textBox1.Text + "\n" + labelReturnVariables.Text;
            ScriptOptions options = ScriptOptions.Default
                .WithReferences(
                    typeof(DateTime).Assembly,
                    typeof(JavaImports.Random).Assembly
                )
                .WithImports(
                   "System"
                );
            Script script = CSharpScript.Create(code, options);
            ScriptState state;
            
            try
            {
                state = await script.RunAsync();
            }
            catch (Exception ex)
            {
                ToolTip tt = new()
                {
                    IsBalloon = true,
                    ToolTipIcon = ToolTipIcon.Error,
                    ToolTipTitle = ex.GetType().Name
                };
                tt.Show(ex.ToString(), textBox1, 0, 0);
                return;
            }

            if (state.Exception != null)
            {
                ToolTip tt = new()
                {
                    IsBalloon = true,
                    ToolTipIcon = ToolTipIcon.Error,
                    ToolTipTitle = state.Exception.GetType().Name
                };
                tt.Show(state.Exception.ToString(), textBox1, 0, 0);
            }
            else
            {
                float[,] data = (float[,])state.ReturnValue;
                float min = float.PositiveInfinity, max = float.NegativeInfinity, range = 0;

                for (int x = 0; x < WIDTH; x++)
                {
                    for (int y = 0; y < WIDTH; y++)
                    {
                        float val = data[x, y];
                        min = Math.Min(min, val);
                        max = Math.Max(max, val);
                    }
                }

                range = max - min;

                Bitmap bitmap = new(WIDTH, WIDTH);

                for (int x = 0; x < WIDTH; x++)
                {
                    for (int y = 0; y < WIDTH; y++)
                    {
                        float normalised = (data[x, y] - min) / range;

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

                        //bitmap.SetPixel(x, y, Color.FromArgb(lightness, lightness, lightness));
                    }
                }

                pictureBox1.Image = bitmap;
            }
        }
    }
}
