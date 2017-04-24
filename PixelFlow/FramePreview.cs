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
    public partial class FramePreview : UserControl
    {

        private List<Bitmap> animation = new List<Bitmap>();
        public int numFrames;
        public int currFrame;

        public FramePreview()
        {
            InitializeComponent();
        }

        public void AddFrame(Bitmap image)
        {
            animation.Add(image);
            numFrames = animation.Count;
        }

        public Bitmap GetCurrentFrame()
        {
            return animation[currFrame];
        }
    }
}