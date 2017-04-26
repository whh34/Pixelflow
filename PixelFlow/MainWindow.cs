﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PixelFlow
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void penTool_Click(object sender, EventArgs e)
        {

        }

        private void drawPane1_Load(object sender, EventArgs e)
        {

        }

        private void toolbarPane1_Load(object sender, EventArgs e)
        {

        }

        public ToolbarPane GetToolbar()
        {
            return this.toolbarPane1;
        }

        public DrawPane GetDrawPane()
        {
            return this.drawPane1;
        }

        public AnimationPane GetAnimationPane()
        {
            return this.animationPane1;
        }

        private void optionsBar1_Load(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // this is necessary to close the animating thread. There's probably a better way

            this.GetAnimationPane().GetAnimationPreview().animating = false;
            this.GetAnimationPane().GetAnimationPreview().animator.Interrupt();
            this.GetAnimationPane().GetAnimationPreview().animator.Join();
        }

        private void toolbarPane1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
