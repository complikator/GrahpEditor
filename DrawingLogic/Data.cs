using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEditor.DrawingLogic
{
    struct DrawerVertexData
    {
        public Position Position;
        public Color color;
        public int Number;
        public bool IsActive;

        public DrawerVertexData(Position position, Color color, int number, bool isActive)
        {
            Position = position;
            this.color = color;
            Number = number;
            IsActive = isActive;
        }
    }

    struct DrawerEdgeData
    {
        public Position StartPosition;
        public Position EndPosition;
        public Color color;

        public DrawerEdgeData(Position startPosition, Position endPosition, Color color)
        {
            StartPosition = startPosition;
            EndPosition = endPosition;
            this.color = color;
        }
    }
}
