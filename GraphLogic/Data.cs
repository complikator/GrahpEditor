using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphEditor.GraphLogic
{
    struct VertexData
    {
        public IVertexIdentifier Id;
        public Position Position;

        public VertexData(IVertexIdentifier id, Position position)
        {
            Id = id;
            Position = position;
        }
    }
    struct EdgeData
    {
        public IVertexIdentifier Begin;
        public IVertexIdentifier End;

        public EdgeData(IVertexIdentifier begin, IVertexIdentifier end)
        {
            Begin = begin;
            End = end;
        }
    }
    struct DistanceData
    {
        public IVertexIdentifier Id;
        public double Distance;

        public DistanceData(IVertexIdentifier id, double distance)
        {
            Id = id;
            Distance = distance;
        }
    }
}
