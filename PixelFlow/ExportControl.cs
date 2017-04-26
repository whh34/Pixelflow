﻿using System;
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
    public partial class ExportControl : UserControl
    {
        public ExportControl()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = formatBox.SelectedIndex;

            // Save as .png selected
            if (index == 0)
            {
                PngExport pex = new PngExport();
                exportPanel.Controls.Add(pex);
            }
        }
    }
}
