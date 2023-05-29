namespace Routers;

using System.Collections.Generic;
using System.Text;

/// <summary>
/// Utility for building topology of network based on minimum spanning tree.
/// </summary>
public static class TopologyBuilder
{
    private class GraphEdge
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

    /// <summary>
    /// Finds minimum spanning tree - maximum speed topology - in input topology.
    /// </summary>
    /// <param name="input">Input topology.</param>
    /// <returns>Maximum speed topology.</returns>
    public static string FindMaximumSpeedTopology(string? input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("Topology can't be null!");
        }

        if (input == string.Empty)
        {
            throw new ArgumentException("Topology can't be empty!");
        }

        (List<GraphEdge> graphEdges, int vertexesNumber) = ParseTopology(input);

        var connectedVertexes = new HashSet<int>() { graphEdges[0].FirstVertex };

        List<GraphEdge> resultEdges = new();

        while (connectedVertexes.Count < vertexesNumber)
        {
            GraphEdge? maximumWeightEdge = GetMaximumWeigthEdge(graphEdges, connectedVertexes);

            if (maximumWeightEdge == null)
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
            var splittedLine = line.Split(":");
            if (splittedLine.Length != 2)
            {
                throw new ArgumentException("Incorrect topology!");
            }
            var fromVertex = splittedLine[0];
            var toVertexes = splittedLine[1].Split(",");

            if (!int.TryParse(fromVertex, out var firstVertex))
            {
                throw new ArgumentException("Incorrect topology!");
            }

            vertexes.Add(firstVertex);

            foreach (var incidentVertex in toVertexes)
            {
                var splittedIncidentVertex = incidentVertex.Split("(");
                var vertex = splittedIncidentVertex[0];
                if (!int.TryParse(vertex, out var secondVertex))
                {
                    throw new ArgumentException("Incorrect topology");
                }

                vertexes.Add(secondVertex);

                if (!int.TryParse(splittedIncidentVertex[1].Split(")")[0], out var weight) || weight <= 0)
                {
                    throw new ArgumentException("Incorrect topology");
                }


                parsedTopology.Add(new GraphEdge(firstVertex, secondVertex, weight));
            }
        }

        return (parsedTopology, vertexes.Count);
    }

    private static GraphEdge? GetMaximumWeigthEdge(List<GraphEdge> graphEdges, HashSet<int> connectedVertexes)
    {
        GraphEdge? maximumWeightEdge = null;
        var maximumWeight = int.MinValue;

        foreach (var edge in graphEdges)
        {
            if (connectedVertexes.Contains(edge.FirstVertex) ^ connectedVertexes.Contains(edge.SecondVertex))
            {
                if (maximumWeight < edge.Weight)
                {
                    maximumWeightEdge = edge;
                    maximumWeight = edge.Weight;
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
