using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Utilities
{
    public class DrawingGrid
    {
        public class GridCell
        {
            public Color color { get; set; }

            public GridCell(int r = 255, int g = 255, int b = 255, int a = 0)
            {
                color = Color.FromArgb(a, r, g, b);
            }

            public GridCell(Color color)
            {
                this.color = color;
            }
        }

        public GridCell[,] Grid;
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
            Grid = new GridCell[sizeX, sizeY];
            Scale = scale;
        }

        // Initializes a new display bitmap and corresponding graphics object
        public void UpdateDisplayMap()
        {
            DisplayMap = new Bitmap(Grid.GetLength(0) * Scale, Grid.GetLength(1) * Scale);
            DisplayGraphics = Graphics.FromImage(DisplayMap);

            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.GetLength(1); y++)
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
            Bitmap b = new Bitmap(Grid.GetLength(0) * scale, Grid.GetLength(1) * scale);
            Graphics bGraphics = Graphics.FromImage(b);

            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                for (int y = 0; y < Grid.GetLength(1); y++)
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
