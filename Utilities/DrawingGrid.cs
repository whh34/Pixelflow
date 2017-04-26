using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Media.Imaging;
using System.IO;

namespace Utilities
{
    public class DrawingGrid
    {
        // An abstraction class of System.Drawing.Color
        //      Allows for more interesting ways to initialize colors.
        public class GridCell
        {
            public Color color { get; set; }

            public GridCell(int r = 255, int g = 255, int b = 255, int a = 255)
            {
                color = Color.FromArgb(a, r, g, b);
            }

            public GridCell(Color color)
            {
                this.color = color;
            }

            public GridCell()
            {
                this.color = Color.White;
            }
        }

        public GridCell[,] Grid;
        //private int _width;
        //private int _height;
        public Size size { get; }
        private int _Scale;
        public int Scale
        {
            get { return _Scale; }
            set { _Scale = value; UpdateDisplayMap(); }
        }

        public Bitmap DisplayMap;
        private Graphics DisplayGraphics;

        // Constructor for creating a blank DrawingGrid
        public DrawingGrid(int sizeX, int sizeY, int scale)
        {
            size = new Size(sizeX, sizeY);
            Grid = new GridCell[sizeX, sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                    Grid[x, y] = new GridCell();
            }

            Scale = scale;
        }

        // Constructor for creating a DrawingGrid of an input Bitmap
        public DrawingGrid(Bitmap inputMap, int scale, int nativeScale)
        {
            size = new Size(inputMap.Size.Width / nativeScale, inputMap.Size.Height / nativeScale);
            Grid = new GridCell[size.Width, size.Height];

            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                    Grid[x, y] = new GridCell(inputMap.GetPixel(x * nativeScale, y * nativeScale));
            }

            Scale = scale;
        }

        // Constructor for creating a DrawingGrid of an input .png file
        public DrawingGrid(Stream pngStream, int scale, int nativeScale) : this(BitmapConverters.CreateBitmapFromPNG(pngStream), scale, nativeScale)
        {
            
        }

        // Initializes a new display bitmap and corresponding graphics object
        private void UpdateDisplayMap()
        {
            DisplayMap = new Bitmap(size.Width * Scale, size.Height * Scale);
            DisplayGraphics = Graphics.FromImage(DisplayMap);

            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    SolidBrush brush = new SolidBrush(Grid[x, y].color);
                    DisplayGraphics.FillRectangle(brush, x * Scale, y * Scale, Scale, Scale);
                    brush.Dispose();
                }
            }
        }

        // Paints the specified cell, and updates the display bitmap
        public void DrawToGrid(int x, int y, Color c)
        {
            Grid[x, y].color = c;
            SolidBrush brush = new SolidBrush(c);
            DisplayGraphics.FillRectangle(brush, x * Scale, y * Scale, Scale, Scale);
            brush.Dispose();
        }

        // Retrieves the Color from a specified cell
        public Color GetCell(int x, int y)
        {
            return Grid[x, y].color;
        }

        // Creates a Bitmap image of the current drawing at a specified scale
        public Bitmap CreateImage(int scale)
        {
            Bitmap b = new Bitmap(size.Width * scale, size.Height * scale);
            Graphics bGraphics = Graphics.FromImage(b);

            for (int x = 0; x < size.Width; x++)
            {
                for (int y = 0; y < size.Height; y++)
                {
                    SolidBrush brush = new SolidBrush(Grid[x, y].color);
                    bGraphics.FillRectangle(brush, x * scale, y * scale, scale, scale);
                    brush.Dispose();
                }
            }

            return b;
        }
    }
}
