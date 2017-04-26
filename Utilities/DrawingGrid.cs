using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Media.Imaging;

namespace Utilities
{
    public class DrawingGrid
    {
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
        private int _width;
        private int _height;
        public Size size { get; }
        private int _Scale;
        public int Scale
        {
            get { return _Scale; }
            set { _Scale = value; UpdateDisplayMap(); }
        }

        public Bitmap DisplayMap;
        private Graphics DisplayGraphics;

        // Constructor for DrawingGrid
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

        // Initializes a new display bitmap and corresponding graphics object
        private void UpdateDisplayMap()
        {
            DisplayMap = new Bitmap(size.Width * Scale, size.Height * Scale);
            DisplayGraphics = Graphics.FromImage(DisplayMap);
            //DisplayGraphics.CompositingMode = CompositingMode.SourceCopy;

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

        // Creates a BitmapSource object from the current drawing
        public BitmapSource CreateSource(int scale)
        {
            Bitmap temp = CreateImage(scale);
            var bitmapData = temp.LockBits(new Rectangle(0, 0, temp.Width, temp.Height), ImageLockMode.ReadOnly, temp.PixelFormat);
            var bitmapSource = BitmapSource.Create(bitmapData.Width, bitmapData.Height, 96, 96, System.Windows.Media.PixelFormats.Bgra32, null, bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            temp.UnlockBits(bitmapData);
            return bitmapSource;
        }

        //Copies a region to another grid
        public GridCell[,] CopyRegion(Rectangle r)
        {
            
            GridCell[,] region = new GridCell[r.Width, r.Height];
            for (int i = 0; i < r.Width; i++)
            {
                for (int j = 0; j < r.Height; j++)
                {
                    region[i, j] = new GridCell(this.GetCell(r.X + i, r.Y + j));
                }
            }
            return region;
        }

        //Overwrites a region with the provided one
        public void PasteRegion(int x, int y, GridCell[,] region)
        { 
            TestBounds(new Rectangle(x, y, region.GetLength(0) + x, region.GetLength(1) + y));
            for ()
        }

        //Tests to make sure a given rectangle is within bounds
        private void TestBounds(Rectangle r)
        {
            if (r.Y < 0 || r.X < 0 || r.Top >= size.Height || r.Width >= size.Width)
            {
                throw new ArgumentOutOfRangeException("Region out of bounds " + r);
            }
        }
    }
}
