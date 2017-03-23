﻿namespace PixelFlow
{
    partial class ToolbarPane
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolbarPane));
            this.pencilTool = new System.Windows.Forms.Button();
            this.rectangleTool = new System.Windows.Forms.Button();
            this.circleTool = new System.Windows.Forms.Button();
            this.fillTool = new System.Windows.Forms.Button();
            this.selectTool = new System.Windows.Forms.Button();
            this.gradientTool = new System.Windows.Forms.Button();
            this.eyedropperTool = new System.Windows.Forms.Button();
            this.lineTool = new System.Windows.Forms.Button();
            this.primaryColorSelector = new System.Windows.Forms.Button();
            this.primaryColorDialog = new System.Windows.Forms.ColorDialog();
            this.secondaryColorSelector = new System.Windows.Forms.Button();
            this.secondaryColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolsToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // pencilTool
            // 
            this.pencilTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pencilTool.BackgroundImage")));
            this.pencilTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pencilTool.Location = new System.Drawing.Point(3, 171);
            this.pencilTool.Name = "pencilTool";
            this.pencilTool.Size = new System.Drawing.Size(50, 50);
            this.pencilTool.TabIndex = 0;
            this.toolsToolTips.SetToolTip(this.pencilTool, "Pencil Tool");
            this.pencilTool.UseVisualStyleBackColor = true;
            this.pencilTool.Click += new System.EventHandler(this.pencilTool_Click);
            // 
            // rectangleTool
            // 
            this.rectangleTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rectangleTool.BackgroundImage")));
            this.rectangleTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rectangleTool.Location = new System.Drawing.Point(57, 115);
            this.rectangleTool.Name = "rectangleTool";
            this.rectangleTool.Size = new System.Drawing.Size(50, 50);
            this.rectangleTool.TabIndex = 1;
            this.toolsToolTips.SetToolTip(this.rectangleTool, "Rectangle Tool");
            this.rectangleTool.UseVisualStyleBackColor = true;
            this.rectangleTool.Click += new System.EventHandler(this.rectangleTool_Click);
            // 
            // circleTool
            // 
            this.circleTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circleTool.BackgroundImage")));
            this.circleTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.circleTool.Location = new System.Drawing.Point(3, 115);
            this.circleTool.Name = "circleTool";
            this.circleTool.Size = new System.Drawing.Size(50, 50);
            this.circleTool.TabIndex = 2;
            this.toolsToolTips.SetToolTip(this.circleTool, "Circle Tool");
            this.circleTool.UseVisualStyleBackColor = true;
            this.circleTool.Click += new System.EventHandler(this.circleTool_Click);
            // 
            // fillTool
            // 
            this.fillTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fillTool.BackgroundImage")));
            this.fillTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fillTool.Location = new System.Drawing.Point(57, 59);
            this.fillTool.Name = "fillTool";
            this.fillTool.Size = new System.Drawing.Size(50, 50);
            this.fillTool.TabIndex = 3;
            this.toolsToolTips.SetToolTip(this.fillTool, "Fill Tool");
            this.fillTool.UseVisualStyleBackColor = true;
            this.fillTool.Click += new System.EventHandler(this.fillTool_Click);
            // 
            // selectTool
            // 
            this.selectTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectTool.BackgroundImage")));
            this.selectTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectTool.Location = new System.Drawing.Point(3, 3);
            this.selectTool.Name = "selectTool";
            this.selectTool.Size = new System.Drawing.Size(50, 50);
            this.selectTool.TabIndex = 4;
            this.toolsToolTips.SetToolTip(this.selectTool, "Selector");
            this.selectTool.UseVisualStyleBackColor = true;
            this.selectTool.Click += new System.EventHandler(this.selectTool_Click);
            // 
            // gradientTool
            // 
            this.gradientTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gradientTool.BackgroundImage")));
            this.gradientTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gradientTool.Location = new System.Drawing.Point(3, 59);
            this.gradientTool.Name = "gradientTool";
            this.gradientTool.Size = new System.Drawing.Size(50, 50);
            this.gradientTool.TabIndex = 5;
            this.toolsToolTips.SetToolTip(this.gradientTool, "Gradient Tool");
            this.gradientTool.UseVisualStyleBackColor = true;
            this.gradientTool.Click += new System.EventHandler(this.gradientTool_Click);
            // 
            // eyedropperTool
            // 
            this.eyedropperTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eyedropperTool.BackgroundImage")));
            this.eyedropperTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eyedropperTool.Location = new System.Drawing.Point(57, 3);
            this.eyedropperTool.Name = "eyedropperTool";
            this.eyedropperTool.Size = new System.Drawing.Size(50, 50);
            this.eyedropperTool.TabIndex = 6;
            this.toolsToolTips.SetToolTip(this.eyedropperTool, "Eyedropper");
            this.eyedropperTool.UseVisualStyleBackColor = true;
            this.eyedropperTool.Click += new System.EventHandler(this.eyedropperTool_Click);
            // 
            // lineTool
            // 
            this.lineTool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lineTool.BackgroundImage")));
            this.lineTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lineTool.Location = new System.Drawing.Point(57, 172);
            this.lineTool.Name = "lineTool";
            this.lineTool.Size = new System.Drawing.Size(50, 49);
            this.lineTool.TabIndex = 7;
            this.toolsToolTips.SetToolTip(this.lineTool, "Line Tool");
            this.lineTool.UseVisualStyleBackColor = true;
            this.lineTool.Click += new System.EventHandler(this.lineTool_Click);
            // 
            // primaryColorSelector
            // 
            this.primaryColorSelector.BackColor = System.Drawing.SystemColors.InfoText;
            this.primaryColorSelector.Location = new System.Drawing.Point(57, 281);
            this.primaryColorSelector.Name = "primaryColorSelector";
            this.primaryColorSelector.Size = new System.Drawing.Size(35, 35);
            this.primaryColorSelector.TabIndex = 8;
            this.primaryColorSelector.UseVisualStyleBackColor = false;
            this.primaryColorSelector.Click += new System.EventHandler(this.primaryColorSelector_Click);
            // 
            // primaryColorDialog
            // 
            this.primaryColorDialog.FullOpen = true;
            // 
            // secondaryColorSelector
            // 
            this.secondaryColorSelector.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.secondaryColorSelector.Location = new System.Drawing.Point(72, 296);
            this.secondaryColorSelector.Name = "secondaryColorSelector";
            this.secondaryColorSelector.Size = new System.Drawing.Size(35, 35);
            this.secondaryColorSelector.TabIndex = 9;
            this.secondaryColorSelector.UseVisualStyleBackColor = false;
            this.secondaryColorSelector.Click += new System.EventHandler(this.secondaryColorSelector_Click);
            // 
            // secondaryColorDialog
            // 
            this.secondaryColorDialog.FullOpen = true;
            // 
            // toolsToolTips
            // 
            this.toolsToolTips.Tag = "";
            this.toolsToolTips.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // ToolbarPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.primaryColorSelector);
            this.Controls.Add(this.secondaryColorSelector);
            this.Controls.Add(this.lineTool);
            this.Controls.Add(this.eyedropperTool);
            this.Controls.Add(this.gradientTool);
            this.Controls.Add(this.selectTool);
            this.Controls.Add(this.fillTool);
            this.Controls.Add(this.circleTool);
            this.Controls.Add(this.rectangleTool);
            this.Controls.Add(this.pencilTool);
            this.Name = "ToolbarPane";
            this.Size = new System.Drawing.Size(112, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pencilTool;
        private System.Windows.Forms.Button rectangleTool;
        private System.Windows.Forms.Button circleTool;
        private System.Windows.Forms.Button fillTool;
        private System.Windows.Forms.Button selectTool;
        private System.Windows.Forms.Button gradientTool;
        private System.Windows.Forms.Button eyedropperTool;
        private System.Windows.Forms.Button lineTool;
        private System.Windows.Forms.Button primaryColorSelector;
        private System.Windows.Forms.ColorDialog primaryColorDialog;
        private System.Windows.Forms.Button secondaryColorSelector;
        private System.Windows.Forms.ColorDialog secondaryColorDialog;
        private System.Windows.Forms.ToolTip toolsToolTips;
    }
}
