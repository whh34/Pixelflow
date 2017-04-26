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
    public partial class AnimationPreview : UserControl
    {
        public int currentFrame = 1;
        public int frameRate = 0;
        public System.Threading.Thread animator;

        public bool paused = true;
        public volatile bool animating = true;

        public List<int> testAnim = new List<int>();
        public List<Bitmap> animation = new List<Bitmap>(10);

        Graphics drawspace;

        public AnimationPreview()
        {
            InitializeComponent();
            //Test
            testAnim.Add(1);
            testAnim.Add(2);
            testAnim.Add(3);
            testAnim.Add(4);
        }

        private void AnimationPreview_Load(object sender, EventArgs e)
        {
            //animation.Add(MainWindow.Instance.GetDrawPane().GetImage());

            animator = new System.Threading.Thread(Play);
            animator.Start();
        }

        /*private void AnimationPreview_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            animating = false;
            animator.Interrupt();
            animator.Join();
        }*/

        public void Play()
        {
            while(animating)
            {
                if (!paused)
                {
                    if (frameRate != 0)
                    {
                        System.Threading.Thread.Sleep(1000 / frameRate);

                        MethodInvoker mi = delegate ()
                        {
                            StepToFrame(currentFrame + 1);
                        };
                        this.Invoke(mi);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }          
            }
        }

        public void PlayPause()
        {
            paused = !paused;
        }

        public void StepToFrame(int frame)
        {
            currentFrame = frame;
            if (currentFrame > testAnim.Count)
            {
                currentFrame = 1;
            }
            else if (currentFrame < 1)
            {
                currentFrame = testAnim.Count;
            }

            DisplayFrame(currentFrame);
        }

        public void DisplayFrame(int frame)
        {
            //Test
            //this.testAnimText.Text = testAnim[currentFrame - 1].ToString();
            drawspace = this.CreateGraphics();
            drawspace.DrawImage(animation[frame], new PointF(0, 0));
            //DrawToDisplay(animation[frame]);
        }

        public void DrawToDisplay(Bitmap image)
        {
            int scale = (int)Math.Min(drawspace.DpiX / image.Width, drawspace.DpiY / image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {

                    ColorPixel(x, y, scale, image.GetPixel(x, y));
                }
            }
        }

        public void ColorPixel(int x, int y, int scale, Color color)
        {
            // draw the pixel to the screen and the bitmap representation
            Brush brush = new SolidBrush(color);
            drawspace.FillRectangle(brush, x, y, scale, scale);
            //image.SetPixel(x, y, actingPrimaryColor);
            brush.Dispose();

            // tell the animator to update this frame
            //mainWindow = (MainWindow)this.Parent;
            //mainWindow.GetAnimationPane().GetAnimationPreview().animation.Add(image);//[frame - 1] = image;
        }
    }
}
