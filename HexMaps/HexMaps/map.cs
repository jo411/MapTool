using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HexMaps
{
    public partial class map : Form
    {

        int HexHeight = 100;
        List<PointF> Hexagons;

        HexGrid hexMap;
        public map()
        {
            InitializeComponent();
            Hexagons = new List<PointF>();
        }

        private void map_Load(object sender, EventArgs e)
        {

        }

        public void initAndShow(HexGrid map)
        {
            this.hexMap = map;
            this.Show();
        }



        private PointF[] HexToPoints(float height, float row, float col)
        {
            // Start with the leftmost corner of the upper left hexagon.
            float width = HexWidth(height);
            float y = height / 2;
            float x = 0;

            // Move down the required number of rows.
            y += row * height;

            // If the column is odd, move down half a hex more.
            if (col % 2 == 1) y += height / 2;

            // Move over for the column number.
            x += col * (width * 0.75f);

            // Generate the points.
            return new PointF[]
                {
            new PointF(x, y),
            new PointF(x + width * 0.25f, y - height / 2),
            new PointF(x + width * 0.75f, y - height / 2),
            new PointF(x + width, y),
            new PointF(x + width * 0.75f, y + height / 2),
            new PointF(x + width * 0.25f, y + height / 2),
                };
        }

        // Return the width of a hexagon.
        private float HexWidth(float height)
        {
            return (float)(4 * (height / 2 / Math.Sqrt(3)));
        }


        private void DrawHexGrid(Graphics gr, Pen pen,float height)
        {
            if (hexMap == null) return;
            // Loop until a hexagon won't fit.
            for (int row = 0; row<hexMap.height; row++)
            {
                // Get the points for the row's first hexagon.
                PointF[] points = HexToPoints(height, row, 0);

              
                // Draw the row.
                for (int col = 0;col<hexMap.width; col++)
                {
                    // Get the points for the row's next hexagon.
                    points = HexToPoints(height, row, col);
                    gr.DrawPolygon(pen, points);
                    // If it fits vertically, draw it.
                  
                }
            }
        }




        private void PointToHex(float x, float y, float height,
    out int row, out int col)
        {
            // Find the test rectangle containing the point.
            float width = HexWidth(height);
            col = (int)(x / (width * 0.75f));

            if (col % 2 == 0)
                row = (int)(y / height);
            else
                row = (int)((y - height / 2) / height);

            // Find the test area.
            float testx = col * width * 0.75f;
            float testy = row * height;
            if (col % 2 == 1) testy += height / 2;

            // See if the point is above or
            // below the test hexagon on the left.
            bool is_above = false, is_below = false;
            float dx = x - testx;
            if (dx < width / 4)
            {
                float dy = y - (testy + height / 2);
                if (dx < 0.001)
                {
                    // The point is on the left edge of the test rectangle.
                    if (dy < 0) is_above = true;
                    if (dy > 0) is_below = true;
                }
                else if (dy < 0)
                {
                    // See if the point is above the test hexagon.
                    if (-dy / dx > Math.Sqrt(3)) is_above = true;
                }
                else
                {
                    // See if the point is below the test hexagon.
                    if (dy / dx > Math.Sqrt(3)) is_below = true;
                }
            }

            // Adjust the row and column if necessary.
            if (is_above)
            {
                if (col % 2 == 0) row--;
                col--;
            }
            else if (is_below)
            {
                if (col % 2 == 1) row++;
                col--;
            }
        }

        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            this.Text = "(" + row + ", " + col + ")";    

          
        }

        private void map_MouseClick(object sender, MouseEventArgs e)
        {
            Hexagons.Clear();
            int row, col;
            PointToHex(e.X, e.Y, HexHeight, out row, out col);
            if(col<hexMap.width&&row<hexMap.height)
            Hexagons.Add(new PointF(row, col));

            this.Refresh();
        }

        private void map_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the selected hexagons.
            foreach (PointF point in Hexagons)
            {
                e.Graphics.FillPolygon(Brushes.LightBlue,
                    HexToPoints(HexHeight, point.X, point.Y));
            }

            // Draw the grid.
            DrawHexGrid(e.Graphics, new Pen(Color.Black,2),HexHeight);
        }
    }
}
