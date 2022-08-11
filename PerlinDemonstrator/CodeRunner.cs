using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using ToolTip = System.Windows.Forms.ToolTip;

namespace PerlinDemonstrator
{
    public abstract partial class CodeRunner<T> : UserControl
    {
        public static int DisplayWidth { get; set; } = 512;
        public abstract string LogFile { get; set; }
        public abstract string SetupCode { get; set; }
        public abstract string EndCode { get; set; }

        public CodeRunner()
        {
            InitializeComponent();

            try
            {
                FileStream file = File.Open(LogFile, FileMode.Open);
                StreamReader sr = new(file);
                codeBox.Text = sr.ReadToEndAsync().Result;
                sr.Close();
            }
            catch (Exception)
            {
            }

            labelSetupVariables.Text = SetupCode;
            labelReturnVariables.Text = EndCode;
            btnExecute.Click += BtnExecute_ClickAsync;
            codeBox.PreviewKeyDown += CodeBox_PreviewKeyDownAsync;
        }

        private async void CodeBox_PreviewKeyDownAsync(object? sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                int selectionStart = codeBox.SelectionStart;
                codeBox.Text = codeBox.Text.Insert(codeBox.SelectionStart, "    ");
                codeBox.SelectionStart = selectionStart + 4;
                e.IsInputKey = false;
            }
            if (e.KeyCode == Keys.S && e.Control)
            {
                FileStream file = File.Open(LogFile, FileMode.Create);
                StreamWriter writer = new(file);
                await writer.WriteAsync(codeBox.Text);
                writer.Close();
                e.IsInputKey = false;
            }
        }

        private async void BtnExecute_ClickAsync(object? sender, EventArgs e)
        {
            string code = labelSetupVariables.Text + "\n" + codeBox.Text + "\n" + labelReturnVariables.Text;
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
                tt.Show(ex.ToString(), codeBox, 0, 0);
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
                tt.Show(state.Exception.ToString(), codeBox, 0, 0);
            }
            else
            {
                T data = (T)state.ReturnValue;

                Bitmap bitmap = new(DisplayWidth, DisplayWidth);

                PopulateBitmap(data, bitmap);

                resultsDisplay.Image = bitmap;
            }
        }

        protected abstract void PopulateBitmap(T result, Bitmap bitmap);
    }
}
