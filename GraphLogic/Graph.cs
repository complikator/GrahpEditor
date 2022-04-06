using GraphEditor.GraphLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphEditor
{
    class Graph : IGraph
    {
        #region data

        private List<Edge> edges = new List<Edge>();
        private List<Vertex> vertices = new List<Vertex>();

        #endregion

        #region data structures 

        private class Vertex : IVertexIdentifier
        {
            private static int vertexCounter = 0;

            public int VertexId;
            public Position Position;
            public Vertex(Position position)
            {
                this.Position = position;
                this.VertexId = vertexCounter++;
            }
        }

        private class Edge : IEdgeIdentifier
        {
            public Vertex Begin;
            public Vertex End;

            public Edge(Vertex begin, Vertex end)
            {
                this.Begin = begin;
                this.End = end;
            }
        }

        #endregion

        #region private methods

        private void removeVertexEdges(Vertex v)
        {
            edges.RemoveAll(e => e.Begin == v || e.End == v);
        }

        #endregion

        #region IGraph interface methods

        public IEdgeIdentifier AddEdge(EdgeData data)
        {
            if (!(data.Begin is Vertex) || !(data.End is Vertex))
                throw new ArgumentException();

            Vertex begin = data.Begin as Vertex;
            Vertex end = data.End as Vertex;

            var e = new Edge(begin, end);

            edges.Add(e);
            return e;
        }

        public IVertexIdentifier AddVertex(Position position)
        {
            Vertex v = new Vertex(position);
            vertices.Add(v);

            return v;
        }

        public List<EdgeData> GetEdges()
        {
            return edges.Select(e => new EdgeData(e.Begin, e.End)).ToList();
        }

        public List<VertexData> GetSortedVertices()
        {
            return vertices.OrderBy(v => v.VertexId).Select(v => new VertexData(v, v.Position)).ToList();
        }

        public List<DistanceData> GetVerticesDistance(Position position)
        {
            return vertices.Select(v =>
            {
                double distance = Math.Sqrt(Math.Pow(v.Position.X - position.X, 2) + Math.Pow(v.Position.Y - position.Y, 2));

                return new DistanceData(v, distance);
            }).ToList();
        }

        public void RemoveEdge(EdgeData data)
        {
            edges.Remove(edges.Find(e => e.Begin == data.Begin && e.End == data.End));
        }

        public void RemoveVertex(IVertexIdentifier id)
        {
            vertices.Remove(id as Vertex);

            removeVertexEdges(id as Vertex);
        }
        public VertexData GetVertexData(IVertexIdentifier id)
        {
            return new VertexData(id, (id as Vertex).Position);
        }
        public EdgeData GetEdgeData(IEdgeIdentifier id)
        {
            return new EdgeData((id as Edge).Begin, (id as Edge).End);
        }

        public void MoveVertex(IVertexIdentifier id, Position position)
        {
            vertices.Find(v => v == id).Position = position;
        }
        public bool EdgeExist(IVertexIdentifier begin, IVertexIdentifier end)
        {
            return edges.Find(e => e.Begin == begin && e.End == end) != null;
        }

        #endregion
    }
}