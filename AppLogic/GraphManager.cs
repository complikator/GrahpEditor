using GraphEditor.GraphLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEditor.AppLogic
{
    class GraphManager
    {
        private IGraph graph;
        private Color currentColor;

        private Dictionary<IVertexIdentifier, Color> vertex2ColorMapper = new Dictionary<IVertexIdentifier, Color>();

        public GraphManager(IGraph graph)
        {
            this.graph = graph;
        }
        public void HandleClick(LeftClick _, Position position)
        {
            var vertexId = graph.AddVertex(position);
            vertex2ColorMapper.Add(vertexId, currentColor);
        }
        public void HandleClick(RightClick _, Position position)
        {

        }
        // TODO: change it to observer - subject pattern
        public void ChangeColor(Color color)
        {
            currentColor = color;
        }
    }
}
