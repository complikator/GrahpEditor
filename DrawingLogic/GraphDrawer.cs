using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphEditor.DrawingLogic
{
    internal class GraphDrawer
    {
        private int radius;
        private Font font;
        private Color backgroundColor;

        public GraphDrawer(int radius, int fontSize, Color background)
        {
            this.radius = radius;
            this.font = new Font("Arial", fontSize);
            this.backgroundColor = background;
        }

        public void DrawGraph(Bitmap targetBitmap, List<DrawerVertexData> drawerVertices, List<DrawerEdgeData> drawerEdges)
        {
            Pen pen = new Pen(backgroundColor);
            using (Graphics g = Graphics.FromImage(targetBitmap))
            {
                g.Clear(backgroundColor);

                foreach (var e in drawerEdges)
                {
                    pen.Color = e.color;
                    g.DrawLine(pen, new Point(e.StartPosition.X, e.StartPosition.Y), new Point(e.EndPosition.X, e.EndPosition.Y));
                }

                foreach (var v in drawerVertices)
                {
                    // clear lines inside ellipse
                    Rectangle rect = new Rectangle(v.Position.X - radius, v.Position.Y - radius, radius * 2, radius * 2);
                    g.FillEllipse(new SolidBrush(backgroundColor), rect);

                    // then draw actual ellipse / vertex
                    pen.Color = v.color;
                    g.DrawEllipse(pen, rect);

                    TextRenderer.DrawText(g, v.Number.ToString(), font, rect, v.color, backgroundColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.GlyphOverhangPadding);
                }
            }
        }
    }
}
