using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace PixelFlow
{
    public partial class OptionsBar : UserControl
    {

        //private MainWindow mainWindow;

        public OptionsBar()
        {
            InitializeComponent();  
        }

        public int GetCurrentScale()
        {
            return (int)zoomPercent.Value;
        }

        private void lineThickness_ValueChanged(object sender, EventArgs e)
        {
            MainWindow.Instance.GetDrawPane().SetLineThickness((int)lineThickness.Value);
        }

        private void zoomPercent_ValueChanged(object sender, EventArgs e)
        {
            
            MainWindow.Instance.GetDrawPane().SetScale((int)zoomPercent.Value);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            
            MainWindow.Instance.GetDrawPane().Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            
            MainWindow.Instance.GetDrawPane().Redo();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportControl exp = new ExportControl();
            DialogueForm dialogue = new DialogueForm(exp, "Export");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("ohfuckyah.png", FileMode.Open);
            MainWindow.Instance.GetDrawPane().ImportPNG(stream, (int)zoomPercent.Value, 10); // should do this through drawpane => DrawPane.LoadImage() or maybe ImportImage()
            stream.Close();
        }
    }
}
