using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace PixelFlow
{
    public partial class DrawPane : UserControl
    {
        private MainWindow mainWindow;

        private Bitmap image;

        private bool dragable = false;
        private int drawX;
        private int drawY;

        private Graphics drawspace;
        //private Pen pen;
        private Color primaryColor = Color.Black;
        private Color secondaryColor = Color.White;
        private Color actingPrimaryColor = Color.Black;
        private Color actingSecondaryColor = Color.White;
        private int primaryAlpha = 255;
        private int secondaryAlpha = 0;
        private int lineThickness = 1;
        private int scale = 1;

        public DrawPane()
        {
            InitializeComponent();

            mainWindow = (MainWindow)this.Parent;

            this.drawspace = this.CreateGraphics();
            //this.pen = new Pen(primaryColor, lineThickness); // apparently this doesn't work because you need a new pen every time you draw. idk.

            this.image = new Bitmap(32, 32);
        }

        private void DrawPane_Load(object sender, EventArgs e)
        {

        }

        public void SetScale(int newScale)
        {
            drawspace.ScaleTransform((float)newScale / (float)scale, (float)newScale / (float)scale); // close, but causes weird problems with what the pen tool actually does.
            //drawspace.PageUnit = GraphicsUnit.Pixel;
            //drawspace.PageUnit = (System.Drawing.GraphicsUnit)((float)newScale / (float)scale);
            this.scale = newScale;
            
        }

        public void FixPixels()
        {
            // loop through every n pixels in the drawspace, where n is scale
            for (int x = 0; x < (int)drawspace.DpiX; x += scale)
            {
                for (int y = 0; y < (int)drawspace.DpiY; y += scale)
                {
                    // Colorize the entire scale x scale area that encompasses a real pixel with the color in it
                    // (there will never be two colors in one real pixel, but if there is, just colorize it by the first.
                    //ScanAndRecolor(x, y, scale);

                    // Colorize that pixel of the bitmap
                    //image.SetPixel(x / scale, y / scale, Color.Black);
                    
                }
            }
        }

        public void ScanAndRecolor(int x, int y, int scale)
        {
            for (int i = x; i < x + scale; i++)
            {
                for (int j = y; j < y + scale; j++)
                {
                    //drawspace.get the fuckin color at a spot
                    Brush brush = new SolidBrush(primaryColor);
                    drawspace.FillRectangle(brush, x, y, scale, scale);
                }
            }
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
            mainWindow = (MainWindow)this.Parent;
            string tool = mainWindow.GetToolbar().GetActiveTool();

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

            mainWindow = (MainWindow)this.Parent;
            string tool = mainWindow.GetToolbar().GetActiveTool();

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

            mainWindow = (MainWindow)this.Parent;
            string tool = mainWindow.GetToolbar().GetActiveTool();

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
                //DrawFillUp(e);
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
        }


        /***********************************************************************/
        /*                               PENCIL                                */
        /***********************************************************************/

        private void DrawPencilDown(MouseEventArgs e)
        {
            Brush brush = new SolidBrush(actingPrimaryColor);
            drawspace.FillRectangle(brush, e.X / scale, e.Y / scale, lineThickness, lineThickness);
            drawX = e.X;
            drawY = e.Y;
            brush.Dispose();
            FixPixels();
        }

        private void DrawPencilMove(MouseEventArgs e)
        {
            Pen pen = new Pen(actingPrimaryColor, lineThickness);
            
            if (dragable == true)
            {
                //drawspace.DrawLine(pen, drawX / scale, drawY / scale, e.X / scale, e.Y / scale);  // causes plus signs instead of solid lines because DrawLine makes a flat area that covers stuff instead of a rectangle.

                DrawLineUp(e);
                drawX = e.X;
                drawY = e.Y;

            }
            pen.Dispose();
            FixPixels();
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
            /*Pen pen = new Pen(actingPrimaryColor, lineThickness);
            drawspace.DrawLine(pen, drawX / scale, drawY / scale, e.X / scale, e.Y / scale);*/

            Brush brush = new SolidBrush(actingPrimaryColor);

            int sX = drawX / scale;
            int sY = drawY / scale;
            int eX = e.X / scale;
            int eY = e.Y / scale;

            /* OLD WAY
            float originalSlope = (float)(sX - eX) / (float)(sY - eY);
            float slope = originalSlope;
            while (sX != eX || sY != eY)
            {
                drawspace.FillRectangle(brush, sX, sY, lineThickness, lineThickness);

                slope = (float)(sX - eX) / (float)(sY - eY);
                if (sX < eX && slope <= originalSlope)
                {
                    sX++;
                }
                else if (sX > eX && slope >= originalSlope)
                {
                    sX--;
                }

                slope = (float)(sX - eX) / (float)(sY - eY); // uncomment to allow going both vertically and horizontally in one iteration
                if (sY < eY && slope >= originalSlope)
                {
                    sY++;
                }
                else if (sY > eY && slope <= originalSlope)
                {
                    sY--;
                }
            }*/

            // NEW WAY

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

            drawspace.FillRectangle(brush, sX, sY, lineThickness, lineThickness);
            for (int i = 0; i < steps; i++)
            {
                x += dx;
                y += dy;
                drawspace.FillRectangle(brush, (int)(x + 0.5), (int)(y + 0.5), lineThickness, lineThickness);
            }

            //pen.dispose();
            brush.Dispose();
            //FixPixels();
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
            Brush brush = new SolidBrush(actingPrimaryColor);
            if (drawX < e.X && drawY < e.Y)
            {
                drawspace.FillEllipse(brush, drawX / scale, drawY / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }
            else if (drawX < e.X && drawY > e.Y)
            {
                drawspace.FillEllipse(brush, drawX / scale, e.Y / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }
            else if (drawX > e.X && drawY < e.Y)
            {
                drawspace.FillEllipse(brush, e.X / scale, drawY / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }
            else if (drawX > e.X && drawY > e.Y)
            {
                drawspace.FillEllipse(brush, e.X / scale, e.Y / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }

            FixPixels();
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
            Brush brush = new SolidBrush(actingPrimaryColor);
            if (drawX < e.X && drawY < e.Y)
            {
                drawspace.FillRectangle(brush, drawX / scale, drawY / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }
            else if (drawX < e.X && drawY > e.Y)
            {
                drawspace.FillRectangle(brush, drawX / scale, e.Y / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }
            else if (drawX > e.X && drawY < e.Y)
            {
                drawspace.FillRectangle(brush, e.X / scale, drawY / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }
            else if (drawX > e.X && drawY > e.Y)
            {
                drawspace.FillRectangle(brush, e.X / scale, e.Y / scale, Math.Abs(drawX / scale - e.X / scale), Math.Abs(drawY / scale - e.Y / scale));
            }

            FixPixels();
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
            /*Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(drawX, drawY), new Point(e.X, e.Y), primaryColor, secondaryColor);
            drawspace.FillRectangle(brush, e.Y, e.X, 30, 30);*/

            LinearGradientBrush brush = new LinearGradientBrush(new Point(drawX, drawY), new Point(e.X, e.Y + 1), actingPrimaryColor, actingSecondaryColor); // in case of OutOfMemory errors (don't make a gradient that just goes up 1)

            drawspace.FillRectangle(brush, e.X / scale, e.Y / scale, 100, 100);

            FixPixels();
        }


        /***********************************************************************/
        /*                                FILL                                 */
        /***********************************************************************/




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
            Bitmap image = new Bitmap((int)drawspace.DpiX, (int)drawspace.DpiY, drawspace);

            if (e.X >= 0 && e.Y >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    SetPrimaryColor(image.GetPixel(e.X, e.Y));
                    mainWindow.GetToolbar().SetPrimaryColorSelector(image.GetPixel(e.X, e.Y));
                }
                if (e.Button == MouseButtons.Right)
                {
                    SetSecondaryColor(image.GetPixel(e.X, e.Y));
                    mainWindow.GetToolbar().SetSecondaryColorSelector(image.GetPixel(e.X, e.Y));
                }
            }
        }
    }
}
