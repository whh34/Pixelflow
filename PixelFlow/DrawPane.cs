﻿using System;
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
        private MainWindow mainWindow;

        //private Bitmap image;
        public DrawingGrid Grid;

        private bool dragable = false;
        private int drawX;
        private int drawY;

        //private Graphics drawspace;
        //private Pen pen;
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

            //this.image = new Bitmap(32, 32);
            Grid = new DrawingGrid(size.Width, size.Height, scale);
            this.Size = new Size(size.Width * scale, size.Height * scale);  // temporary, will resize with scale later
            //this.scale = 10;

            mainWindow = (MainWindow)this.Parent;

            //this.drawspace = this.CreateGraphics();
            //this.pen = new Pen(primaryColor, lineThickness); // apparently this doesn't work because you need a new pen every time you draw. idk.

            frame = 1;//mainWindow.GetAnimationPane().GetAnimationPreview().animation.Count + 1;

            history = new List<Bitmap>();
            history.Add(Grid.DisplayMap);
        }

        /*
        public DrawPane(Bitmap newImage)
        {
            InitializeComponent();
            this.image = newImage;

        } */

        public void DisplayImage(Bitmap newImage)
        {
            Graphics g = this.CreateGraphics();
            g.DrawImage(newImage, 0, 0, newImage.Width, newImage.Height);
        }

        public void DisplayImage()
        {
            Graphics g = CreateGraphics();
            g.DrawImage(Grid.DisplayMap, 0, 0, Grid.DisplayMap.Width, Grid.DisplayMap.Height);
        }

        private void DrawPane_Load(object sender, EventArgs e)
        {
            //DisplayImage(image);
            //scale = 10;
        }

        public void Undo()
        {
            //this.drawspace.Clear(Color.White);
            currentHistory--;
            if (currentHistory < 0)
            {
                currentHistory = 0;
            }
            //drawspace.ScaleTransform(scale, scale);
            DisplayImage(history[currentHistory]);
            
            SetScale(scale);

            Debug.WriteLine(history);
        }

        public void Redo()
        {
            //this.drawspace.Clear(Color.White);
            currentHistory++;
            if (currentHistory > history.Count - 1)
            {
                currentHistory = history.Count - 1;
            }
            DisplayImage(history[currentHistory]);

            SetScale(scale);

            Debug.WriteLine(history);
        }

        public void SetScale(int newScale)
        {
            Grid.Scale = newScale;
            scale = newScale;
            this.Size = new Size(size.Width * newScale, size.Height * newScale); // this is kind of cheesy currently, we might want to maintain the true image size somewhere in here
            DisplayImage();
        }

        /*public void FixPixels()
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
        }*/

        /*public void ScanAndRecolor(int x, int y, int scale)
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
        }*/

        /*
         * Sets the color of the pixel at the input point to the input color
         */
        public void ColorPixel(int x, int y, Color color)
        {
            try
            {
                // Color a pixel on the grid representation
                Grid.DrawToGrid(x, y, color);
                //DisplayImage();

                // tell the animator to update this frame
                ((MainWindow)Parent).GetAnimationPane().GetAnimationPreview().animation[frame - 1] = Grid.DisplayMap;
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
            /*Brush brush = new SolidBrush(actingPrimaryColor);
            drawspace.FillRectangle(brush, e.X / scale, e.Y / scale, lineThickness, lineThickness);
            image.SetPixel(e.X / scale, e.Y / scale, actingPrimaryColor);*/
            ColorPixel(e.X / scale, e.Y / scale, actingPrimaryColor);
            drawX = e.X;
            drawY = e.Y;
            DisplayImage();
            //brush.Dispose();
            //FixPixels();
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
            //FixPixels();
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

            //Brush brush = new SolidBrush(actingPrimaryColor);

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

            //drawspace.FillRectangle(brush, sX, sY, lineThickness, lineThickness);
            //image.SetPixel(sX, sY, actingPrimaryColor);
            ColorPixel(sX, sY, actingPrimaryColor);
            for (int i = 0; i < steps; i++)
            {
                x += dx;
                y += dy;
                //drawspace.FillRectangle(brush, (int)(x + 0.5), (int)(y + 0.5), lineThickness, lineThickness);
                //image.SetPixel((int)(x + 0.5), (int)(y + 0.5), actingPrimaryColor);
                ColorPixel((int)(x + 0.5), (int)(y + 0.5), actingPrimaryColor);
            }

            DisplayImage();
            //pen.dispose();
            //brush.Dispose();
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
            /* Yeah we're gonna have to redo this in terms of ColorPixel()
             * 
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

            //FixPixels();
            */ 
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
            //FixPixels();
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
            /* This needs to be redone to work with the Grid object
             * 
            Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(drawX, drawY), new Point(e.X, e.Y), primaryColor, secondaryColor);
            drawspace.FillRectangle(brush, e.Y, e.X, 30, 30);

            LinearGradientBrush brush = new LinearGradientBrush(new Point(drawX, drawY), new Point(e.X, e.Y + 1), actingPrimaryColor, actingSecondaryColor); // in case of OutOfMemory errors (don't make a gradient that just goes up 1)

            drawspace.FillRectangle(brush, e.X / scale, e.Y / scale, 100, 100);

            //FixPixels();
            */
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



            /* I don't really want to mess with this at the moment, but it needs to be slightly changed to work with the grid object
             * 



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
            }*/

            int sX = e.X / scale;
            int sY = e.Y / scale;

            if (e.Button == MouseButtons.Left)
            {
                SetPrimaryColor(GetPixel(sX, sY));
                mainWindow.GetToolbar().SetPrimaryColorSelector(GetPixel(sX, sY));
            }
            if (e.Button == MouseButtons.Right)
            {
                SetSecondaryColor(GetPixel(sX, sY));
                mainWindow.GetToolbar().SetSecondaryColorSelector(GetPixel(sX, sY));
            }
            
        }
    }
}
