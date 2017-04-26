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
    public partial class FrameButton : UserControl
    {
        private int frameIndex;
        public FrameButton(int index)
        {
            InitializeComponent();
            frameIndex = index;
            UpdatePreviewImage();
        }

        private void button_Click(object sender, EventArgs e)
        {
            MainWindow.Instance.SetDrawPane(frameIndex);
        }

        public void UpdatePreviewImage()
        {
            //Graphics g = button.CreateGraphics();
            //g.DrawImage(MainWindow.Instance.GetDrawPane(frameIndex).GetImage(), 0, 0, button.Width, button.Height);
            button.BackgroundImage = MainWindow.Instance.GetDrawPane(frameIndex).GetImage();
            Refresh();
        }
    }
}
