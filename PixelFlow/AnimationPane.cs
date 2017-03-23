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
    public partial class AnimationPane : UserControl
    {
        public AnimationPane()
        {
            InitializeComponent();
            this.playPause.BackColor = Color.LightGray;
            this.stepBackward.BackColor = Color.LightGray;
            this.stepForward.BackColor = Color.LightGray;
        }
    }
}
