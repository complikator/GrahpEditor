using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GraphEditor.Graph;

namespace GraphEditor.GraphLogic
{
    /// <summary>
    /// Interface for identyfing vertices inside concrete graph implementation
    /// Only graph know how to use it 
    /// </summary>
    interface IVertexIdentifier
    {

    }

    /// <summary>
    /// Interface for identyfing edges inside concrete graph implementation
    /// Only graph know how to use it 
    /// </summary>
    interface IEdgeIdentifier
    {

    }
    /// <summary>
    /// Base interface for every graph used in appllication
    /// </summary>
    interface IGraph
    {
        IVertexIdentifier AddVertex(Position position);
        void RemoveVertex(IVertexIdentifier id);
        IEdgeIdentifier AddEdge(EdgeData data);
        void RemoveEdge(EdgeData data);
        List<VertexData> GetSortedVertices();
        List<EdgeData> GetEdges();
        List<DistanceData> GetVerticesDistance(Position position);
        VertexData GetVertexData(IVertexIdentifier id);
        EdgeData GetEdgeData(IEdgeIdentifier id);
        void MoveVertex(IVertexIdentifier id, Position position);
        bool EdgeExist(IVertexIdentifier begin, IVertexIdentifier end);
    }
}
