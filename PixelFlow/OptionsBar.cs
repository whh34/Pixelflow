using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelFlow
{
    public partial class OptionsBar : UserControl
    {

        private MainWindow mainWindow;

        public OptionsBar()
        {
            InitializeComponent();

            mainWindow = (MainWindow)this.Parent;
        }

        private void lineThickness_ValueChanged(object sender, EventArgs e)
        {
            mainWindow = (MainWindow)this.Parent;
            mainWindow.GetDrawPane().SetLineThickness((int)lineThickness.Value);
        }

        private void zoomPercent_ValueChanged(object sender, EventArgs e)
        {
            mainWindow = (MainWindow)this.Parent;
            mainWindow.GetDrawPane().SetScale((int)zoomPercent.Value);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
