using System;
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
        private static MainWindow _mainWindow;
        public static MainWindow Instance
        {
            get
            {
                return _mainWindow;
            }
        }

        private int currentFrameIndex;
        private List<DrawPane> _Frames;
        public List<DrawPane> Frames
        {
            get { return _Frames; }
        }

        public MainWindow()
        {
            _mainWindow = this;
            InitializeComponent();

            _Frames = new List<DrawPane>();
            currentFrameIndex = -1;
        }

        private void penTool_Click(object sender, EventArgs e)
        {

        }

        private void toolbarPane1_Load(object sender, EventArgs e)
        {

        }

        public int GetCurrentFrameIndex()
        {
            return currentFrameIndex;
        }

        public int GetNumberOfFrames()
        {
            return Frames.Count;
        }

        // Adds a new DrawPane and returns the index of the DrawPane
        public int AddNewFrame()
        {
            int toReturn = Frames.Count;
            currentFrameIndex = toReturn;
            DrawPane newFrame = new DrawPane();
            Frames.Add(newFrame);
            drawPanePanel.Controls.Clear();
            drawPanePanel.Controls.Add(newFrame);

            return toReturn;
        }

        public int CopyFrame()
        {
            int toReturn = Frames.Count;

            DrawPane newFrame = new DrawPane(new Utilities.DrawingGrid(GetDrawPane(currentFrameIndex).Grid.DisplayMap, GetOptionsBar().GetCurrentScale(), GetOptionsBar().GetCurrentScale()));
            Frames.Add(newFrame);

            currentFrameIndex = toReturn;
            drawPanePanel.Controls.Clear();
            drawPanePanel.Controls.Add(newFrame);

            return toReturn;
        }

        // Sets the active DrawPane to an existing DrawPane in the Frame list
        public void SetDrawPane(int index)
        {
            currentFrameIndex = index;
            drawPanePanel.Controls.Clear();
            drawPanePanel.Controls.Add(Frames[index]);
            Frames[index].DisplayImage();
        }

        // Returns the current frame
        public DrawPane GetDrawPane()
        {
            return Frames[currentFrameIndex];
        }

        // Returns a specified DrawPane
        public DrawPane GetDrawPane(int index)
        {
            return Frames[index];
        }

        public ToolbarPane GetToolbar()
        {
            return this.toolbarPane1;
        }

        public AnimationPane GetAnimationPane()
        {
            return this.animationPane1;
        }

        public OptionsBar GetOptionsBar()
        {
            return optionsBar1;
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
            
        }

        private void drawPanePanel_Scroll(object sender, ScrollEventArgs e)
        {
            GetDrawPane().DisplayImage();
        }
    }
}
