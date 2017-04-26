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
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Utilities;

namespace PixelFlow
{
    public partial class DrawPane : UserControl
    {
        public DrawingGrid Grid;

        private bool dragable = false;
        private int drawX;
        private int drawY;

        private Color primaryColor = Color.Black;
        private Color secondaryColor = Color.White;
        private Color actingPrimaryColor = Color.Black;
        private Color actingSecondaryColor = Color.White;
        private int primaryAlpha = 255;
        private int secondaryAlpha = 255;
        private int lineThickness = 1;
        private int scale = 10;
        private Size size;

        private List<Bitmap> history;
        private int currentHistory;

        public int frame = 1; // the frame of the animation this will act as

        public DrawPane()
        {
            InitializeComponent();
            size = new Size(32, 32);
            
            Grid = new DrawingGrid(size.Width, size.Height, scale);
            this.Size = new Size(size.Width * scale, size.Height * scale); 

            frame = 1;

            history = new List<Bitmap>();
            history.Add(Grid.DisplayMap);
        }

        public void ImportPNG(Stream pngStream, int scale, int nativeScale)
        {
            Grid = new DrawingGrid(pngStream, scale, nativeScale);
            this.size = Grid.size;
            this.Size = new Size(size.Width * scale, size.Height * scale);
            DisplayImage();
        }

        public void DisplayImage(Bitmap newImage)
        {
            Graphics g = this.CreateGraphics();
            g.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height);
        }

        public void DisplayImage()
        {
            Graphics g = CreateGraphics();
            g.DrawImage(Grid.DisplayMap, 0, 0, Grid.DisplayMap.Width, Grid.DisplayMap.Height);
            int index = MainWindow.Instance.GetCurrentFrameIndex();
            MainWindow.Instance.GetAnimationPane().GetFramePreview().GetPreviewButton(index).UpdatePreviewImage();
        }

        private void DrawPane_Load(object sender, EventArgs e)
        {
            
        }

        public void Undo()
        {
            currentHistory--;
            if (currentHistory < 0)
            {
                currentHistory = 0;
            }

            //Grid = new DrawingGrid(history[currentHistory].Width, history[currentHistory].Height, scale);
            Grid.DisplayMap = history[currentHistory];
            DisplayImage(history[currentHistory]);
            
            SetScale(scale);

            Debug.WriteLine(history);
        }

        public void Redo()
        {
            currentHistory++;
            if (currentHistory > history.Count - 1)
            {
                currentHistory = history.Count - 1;
            }
            Grid.DisplayMap = history[currentHistory];
            DisplayImage(history[currentHistory]);

            SetScale(scale);

            Debug.WriteLine(history);
        }

        public void SetScale(int newScale)
        {
            Grid.Scale = newScale;
            scale = newScale;
            this.Size = new Size(size.Width * newScale, size.Height * newScale);
            DisplayImage();
        }


        /*
         * Sets the color of the pixel at the input point to the input color
         */
        public void ColorPixel(int x, int y, Color color)
        {
            try
            {
                // Color a pixel on the grid representation
                Grid.DrawToGrid(x, y, color);

                // tell the animator to update this frame, currently borked
                //MainWindow.Instance.GetAnimationPane().GetAnimationPreview().animation[frame - 1] = Grid.DisplayMap;
            }
            catch (IndexOutOfRangeException ex)
            {
                // no op
            }
        }


        /*
         * Overload that takes a point instead of 2 ints
         */
        public void ColorPixel(Point p, Color color)
        {
            ColorPixel(p.X, p.Y, color);
        }


        /*
         * Gets the color at the specified point
         */
        public Color GetPixel(int x, int y)
        {
            return Grid.GetCell(x, y);
        }


        /*
         * Overload that takes a point instead of 2 ints
         */ 
        public Color GetPixel(Point p)
        {
            return GetPixel(p.X, p.Y);
        }
        
        
        public Bitmap GetImage()
        {
            return Grid.DisplayMap;
            // I'm not certain that this will do what we want
        }

        public void SetImage(Bitmap image)
        {
            // This might need some work...
        }
        

        public void SetPrimaryColor(Color c)
        {
            primaryColor = c;
        }

        public void SetSecondaryColor(Color c)
        {
            secondaryColor = c;
        }

        public void SetLineThickness(int thickness)
        {
            lineThickness = thickness;
        }

        public void SetPrimaryAlpha(int a)
        {
            primaryAlpha = a;
        }

        public void SetSecondaryAlpha(int a)
        {
            secondaryAlpha = a;
        }

        private void DrawPane_MouseDown(object sender, MouseEventArgs e)
        {
            
            dragable = true;
            string tool = MainWindow.Instance.GetToolbar().GetActiveTool();

            if (e.Button == MouseButtons.Left)
            {
                actingPrimaryColor = Color.FromArgb(primaryAlpha, primaryColor);
                actingSecondaryColor = Color.FromArgb(secondaryAlpha, secondaryColor);
            }
            else if (e.Button == MouseButtons.Right)
            {
                actingPrimaryColor = Color.FromArgb(secondaryAlpha, secondaryColor);
                actingSecondaryColor = Color.FromArgb(primaryAlpha, primaryColor);
            }

            if (tool == "pencil")
            {
                DrawPencilDown(e);
            }
            else if (tool == "line")
            {
                DrawLineDown(e);
            }
            else if (tool == "circle")
            {
                DrawCircleDown(e);
            }
            else if (tool == "rectangle")
            {
                DrawRectangleDown(e);
            }
            else if (tool == "gradient")
            {
                DrawGradientDown(e);
            }
            else if (tool == "fill")
            {
                //DrawFillDown(e);
            }
            else if (tool == "select")
            {
                //DrawSelectDown(e);
            }
            else if (tool == "eyedropper")
            {
                DrawEyedropperDown(e);
            }
            else
            {
                Console.WriteLine("No viable tool selected");
            }
        }

        private void DrawPane_MouseMove(object sender, MouseEventArgs e)
        {

            string tool = MainWindow.Instance.GetToolbar().GetActiveTool();

            if (tool == "pencil")
            {
                DrawPencilMove(e);
            }
            else if (tool == "line")
            {
                DrawLineMove(e);
            }
            else if (tool == "circle")
            {
                DrawCircleMove(e);
            }
            else if (tool == "rectangle")
            {
                DrawRectangleMove(e);
            }
            else if (tool == "gradient")
            {
                DrawGradientMove(e);
            }
            else if (tool == "fill")
            {
                //DrawFillMove(e);
            }
            else if (tool == "select")
            {
                //DrawSelectMove(e);
            }
            else if (tool == "eyedropper")
            {
                DrawEyedropperMove(e);
            }
            else
            {
                Console.WriteLine("No viable tool selected");
            }
        }

        private void DrawPane_MouseUp(object sender, MouseEventArgs e)
        {
            string tool = MainWindow.Instance.GetToolbar().GetActiveTool();

            if (tool == "pencil")
            {
                DrawPencilUp(e);
            }
            else if (tool == "line")
            {
                DrawLineUp(e);
            }
            else if (tool == "circle")
            {
                DrawCircleUp(e);
            }
            else if (tool == "rectangle")
            {
                DrawRectangleUp(e);
            }
            else if (tool == "gradient")
            {
                DrawGradientUp(e);
            }
            else if (tool == "fill")
            {
                DrawFillUp(e);
            }
            else if (tool == "select")
            {
                //DrawSelectUp(e);
            }
            else if (tool == "eyedropper")
            {
                DrawEyedropperUp(e);
            }
            else
            {
                Console.WriteLine("No viable tool selected");
            }

            dragable = false;

            // update history
            if (currentHistory != history.Count - 1)
            {
                history.RemoveRange(currentHistory, history.Count - 1);
            }

            history.Add((Bitmap)Grid.DisplayMap.Clone());
            currentHistory = history.Count - 1;
        }


        /***********************************************************************/
        /*                               PENCIL                                */
        /***********************************************************************/

        private void DrawPencilDown(MouseEventArgs e)
        {

            ColorPixel(e.X / scale, e.Y / scale, actingPrimaryColor);
            drawX = e.X;
            drawY = e.Y;
            DisplayImage();
        }

        private void DrawPencilMove(MouseEventArgs e)
        {
            
            if (dragable == true)
            {
                DrawLineUp(e);
                drawX = e.X;
                drawY = e.Y;
                DisplayImage();
            }
        }
        private void DrawPencilUp(MouseEventArgs e)
        {
            // no action
        }


        /***********************************************************************/
        /*                                LINE                                 */
        /***********************************************************************/

        private void DrawLineDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawLineMove(MouseEventArgs e)
        {
            // show where the line will be
        }
        private void DrawLineUp(MouseEventArgs e)
        {

            int sX = drawX / scale;
            int sY = drawY / scale;
            int eX = e.X / scale;
            int eY = e.Y / scale;

            DrawLine(sX, sY, eX, eY);

            /*int steps;
            if (Math.Abs(sX - eX) > Math.Abs(sY - eY))
            {
                steps = Math.Abs(sX - eX);
            }
            else
            {
                steps = Math.Abs(sY - eY);
            }

            float dx = (float)(eX - sX) / (float)steps;
            float dy = (float)(eY - sY) / (float)steps;

            float x = sX;
            float y = sY;

            ColorPixel(sX, sY, actingPrimaryColor);
            for (int i = 0; i < steps; i++)
            {
                x += dx;
                y += dy;
                ColorPixel((int)(x + 0.5), (int)(y + 0.5), actingPrimaryColor);
            }*/

            DisplayImage();
        }

        public void DrawLine(int sX, int sY, int eX, int eY)
        {
            int steps;
            if (Math.Abs(sX - eX) > Math.Abs(sY - eY))
            {
                steps = Math.Abs(sX - eX);
            }
            else
            {
                steps = Math.Abs(sY - eY);
            }

            float dx = (float)(eX - sX) / (float)steps;
            float dy = (float)(eY - sY) / (float)steps;

            float x = sX;
            float y = sY;

            ColorPixel(sX, sY, actingPrimaryColor);
            for (int i = 0; i < steps; i++)
            {
                x += dx;
                y += dy;
                ColorPixel((int)(x + 0.5), (int)(y + 0.5), actingPrimaryColor);
            }

            DisplayImage();
        }


        /***********************************************************************/
        /*                               CIRCLE                                */
        /***********************************************************************/

        private void DrawCircleDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawCircleMove(MouseEventArgs e)
        {
            // show where the circle will be
        }
        private void DrawCircleUp(MouseEventArgs e)
        {

            int minX = Math.Min(drawX, e.X) / scale;
            int maxX = Math.Max(drawX, e.X) / scale + 1;
            int minY = Math.Min(drawY, e.Y) / scale;
            int maxY = Math.Max(drawY, e.Y) / scale + 1;

            int cenX = (maxX + minX) / 2;
            int cenY = (maxY + minY) / 2;

            double xRad = (double)(maxX - minX) / 2.0;
            double yRad = (double)(maxY - minY) / 2.0;

            /*double step = 10.0 / (xRad + yRad);
            int numSteps = (int)(2 * Math.PI / step) + 1;*/

            int lastX = (int)(cenX + Math.Cos(/*step*/.1) * xRad);
            int lastY = (int)(cenY + Math.Sin(/*step*/.1) * yRad);

            for (double theta = .2; theta < 6.4; theta+= .1)
            //for (int i = 1; i < numSteps + 2; i++) 
            {
                //double theta = step * (double)i;
                int x = (int)(cenX + Math.Cos(theta) * xRad);
                int y = (int)(cenY + Math.Sin(theta) * yRad);

                if (x != lastX || y != lastY)
                {
                    DrawLine(lastX, lastY, x, y);
                }

                lastX = x;
                lastY = y;

            }

            DisplayImage();
        }


        /***********************************************************************/
        /*                              RECTANGLE                              */
        /***********************************************************************/

        private void DrawRectangleDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawRectangleMove(MouseEventArgs e)
        {
            // show where the rectangle will be
        }
        private void DrawRectangleUp(MouseEventArgs e)
        {
            //Brush brush = new SolidBrush(actingPrimaryColor);
            int minX = Math.Min(drawX, e.X) / scale;
            int maxX = Math.Max(drawX, e.X) / scale;
            int minY = Math.Min(drawY, e.Y) / scale;
            int maxY = Math.Max(drawY, e.Y) / scale;

            for (int x = minX; x < maxX + 1; x++)
            {
                for (int y = minY; y < maxY + 1; y++)
                {
                    ColorPixel(x, y, actingPrimaryColor);
                }
            }

            DisplayImage();
        }


        /***********************************************************************/
        /*                              GRADIENT                               */
        /***********************************************************************/

        private void DrawGradientDown(MouseEventArgs e)
        {
            drawX = e.X;
            drawY = e.Y;
        }

        private void DrawGradientMove(MouseEventArgs e)
        {

        }

        private void DrawGradientUp(MouseEventArgs e)
        {

        }


        /***********************************************************************/
        /*                                FILL                                 */
        /***********************************************************************/

        private void DrawFillUp(MouseEventArgs e)
        {
            int sX = e.X / scale;
            int sY = e.Y / scale;

            HashSet<Point> inFill = new HashSet<Point>();
            Queue<Point> openList = new Queue<Point>();
            openList.Enqueue(new Point(sX, sY));
            Color color = GetPixel(sX, sY);
            while (openList.Count > 0)
            {

                Point active = openList.Dequeue();
                int x = active.X;
                int y = active.Y;
                ColorPixel(x, y, actingPrimaryColor);
                int xMax = size.Width;
                int yMax = size.Height;
                Point[] points = { new Point(x + 1, y), new Point(x, y + 1), new Point(x - 1, y), new Point(x, y - 1) };
                foreach (Point p in points)
                {
                    if (p.X < xMax && p.Y < yMax && p.X >= 0 && p.Y >= 0 && !inFill.Contains(p) && !openList.Contains(p)
                        && GetPixel(p.X, p.Y).Equals(color))
                    {
                        openList.Enqueue(p);
                    }
                }

                inFill.Add(active);
            }
            DisplayImage();
        }




        /***********************************************************************/
        /*                               SELECT                                */
        /***********************************************************************/




        /***********************************************************************/
        /*                             EYEDROPPER                              */
        /***********************************************************************/

        private void DrawEyedropperDown(MouseEventArgs e)
        {
            // no action
        }

        private void DrawEyedropperMove(MouseEventArgs e)
        {
            // no action
        }

        private void DrawEyedropperUp(MouseEventArgs e)
        {

            int sX = e.X / scale;
            int sY = e.Y / scale;

            if (e.Button == MouseButtons.Left)
            {
                SetPrimaryColor(GetPixel(sX, sY));
                MainWindow.Instance.GetToolbar().SetPrimaryColorSelector(GetPixel(sX, sY));
            }
            if (e.Button == MouseButtons.Right)
            {
                SetSecondaryColor(GetPixel(sX, sY));
                MainWindow.Instance.GetToolbar().SetSecondaryColorSelector(GetPixel(sX, sY));
            }
            
        }
    }
}
