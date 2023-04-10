using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            IProgress<int> onChangeProgress = new Progress<int>((i) =>
            {
                progressLabel.Text = i.ToString();
                progressBar1.Value = i;
            });
            CancellationTokenSource cts = new CancellationTokenSource();
            buttonCancel.Click += delegate { cts.Cancel(); };
            resultLabel.Text = (await MyMethodAsync(onChangeProgress,cts.Token)).ToString();
        }
        private Task<int> MyMethodAsync(IProgress<int> ChangeProgressBar, CancellationToken cancellTocken)
        {
            return Task.Run(() =>
            {
                int i = 0;
                for (; i <= 20; i++)
                {
                    if (cancellTocken.IsCancellationRequested)
                        return i;
                    Thread.Sleep(200);
                    ChangeProgressBar.Report((int)(i/20f*100f));
                }
                return i;
            });
        }
    }
}
