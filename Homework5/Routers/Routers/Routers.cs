namespace Routers;

using System.Collections.Generic;
using System.Text;

public static class TopologyBuilder
{
    public class GraphEdge
    {
        public int FirstVertex;

        public int SecondVertex;

        public int Weight;

        public GraphEdge(int firstVertex, int secondVertex, int weight)
        {
            this.FirstVertex = firstVertex;
            this.SecondVertex = secondVertex;
            this.Weight = weight;
        }
    }

    public static string FindMaximumSpeedTopology(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Topology can't be null!");
        }

        if (input == string.Empty)
        {
            throw new ArgumentException("Topology can't be empty!");
        }

        var (graphEdges, vertexesNumber) = ParseTopology(input);

        var connectedVertexes = new HashSet<int>() { graphEdges[0].FirstVertex };

        List<GraphEdge> resultEdges = new();

        while (connectedVertexes.Count < vertexesNumber)
        {
            var maximumWeightEdge = GetMaximumWeigthEdge(graphEdges, connectedVertexes);

            if (maximumWeightEdge.Weight == int.MinValue)
            {
                throw new ArgumentException("Not all routers are reachable!");
            }

            resultEdges.Add(maximumWeightEdge);
            connectedVertexes.Add(maximumWeightEdge.FirstVertex);
            connectedVertexes.Add(maximumWeightEdge.SecondVertex);
        }

        return GetTopology(resultEdges, connectedVertexes.Count);
    }

    private static (List<GraphEdge>, int) ParseTopology(string topology)
    {
        var parsedTopology = new List<GraphEdge>();

        var vertexes = new HashSet<int>();

        foreach (var line in topology.Split("\n"))
        {
            var fromVertex = line.Split(":")[0];
            var toVertexes = line.Split(":")[1].Split(",");

            if (!int.TryParse(fromVertex, out var firstVertex))
            {
                throw new ArgumentException("Incorrect topology!");
            }

            vertexes.Add(firstVertex);

            foreach (var incidentVertex in toVertexes)
            {
                var vertex = incidentVertex.Split("(")[0];
                if (!int.TryParse(vertex, out var secondVertex))
                {
                    throw new ArgumentException("Incorrect topology");
                }

                vertexes.Add(secondVertex);

                if (!int.TryParse(incidentVertex.Split("(")[1].Split(")")[0], out var weight))
                {
                    throw new ArgumentException("Incorrect topology");
                }

                parsedTopology.Add(new GraphEdge(firstVertex, secondVertex, weight));
            }
        }

        return (parsedTopology, vertexes.Count);
    }

    private static GraphEdge GetMaximumWeigthEdge(List<GraphEdge> graphEdges, HashSet<int> connectedVertexes)
    {
        var maximumWeightEdge = new GraphEdge(-1, -1, int.MinValue);

        foreach (var edge in graphEdges)
        {
            if (connectedVertexes.Contains(edge.FirstVertex) ^ connectedVertexes.Contains(edge.SecondVertex))
            {
                if (maximumWeightEdge.Weight < edge.Weight)
                {
                    maximumWeightEdge = edge;
                }
            }
        }

        return maximumWeightEdge;
    }

    private static string GetTopology(List<GraphEdge> graphEdges, int vertexesNumber)
    {
        var resultTopology = new StringBuilder();
        var vertexes = new HashSet<int>();

        for (int i = 1; i <= vertexesNumber; ++i)
        {
            var currentLine = new StringBuilder();

            foreach (var edge in graphEdges)
            {
                if (edge.FirstVertex == i && !vertexes.Contains(edge.SecondVertex))
                {
                    currentLine.Append($"{edge.SecondVertex} ({edge.Weight}), ");
                }
                if (edge.SecondVertex == i && !vertexes.Contains(edge.FirstVertex))
                {
                    currentLine.Append($"{edge.FirstVertex} ({edge.Weight}), ");
                }
            }

            vertexes.Add(i);
            if (currentLine.Length != 0)
            {
                resultTopology.Append($"{i}: ").Append(currentLine.Remove(currentLine.Length - 2, 2)).Append("\n");
            }
        }

        resultTopology.Remove(resultTopology.Length - 1, 1);
        return resultTopology.ToString();
    }
}
