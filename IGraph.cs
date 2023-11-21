using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGraph
{
    /// <summary>
    /// Adds a new vertice node to the graph
    /// </summary>
    /// <param name="node">The value the new vertice node should contain</param>
    /// <returns>void</returns>
    void addNode(GraphNode node);

    /// <summary>
    /// Adds an edge representation to the matrix
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <param name="dest">The destination vertice representation</param>
    /// <returns>void</returns>
    void addEdge(int src, int dest);

    /// <summary>
    /// Adds an edge weight to the matrix
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <param name="dest">The destination vertice representation</param>
    /// <param name="weight">The weight of the edge</param>
    /// <returns>void</returns>
    void addEdgeWeight(int src, int dest, int weight);

    /// <summary>
    /// checks if an edge exists in the matrix
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <param name="dest">The destination vertice representation</param>
    /// <returns>void</returns>
    void checkEdge(int src, int dest);

    /// <summary>
    /// Displays the Graph's vertice nodes in a Matrix representation
    /// </summary>
    /// <returns>void</returns>
    void displayMatrix();

    /// <summary>
    /// Transverses the graph in a breadth-first manner
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <returns>void</returns>
    void breadthFirstSearch(int src);

    /// <summary>
    /// Transverses the graph in a depth-first manner
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <returns>void</returns>
    void depthFirstSearch(int src);

    /// <summary>
    /// Displays the shortest path from a given single source
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <returns>void</returns>
    void displayShortestPath(int src);

    /// <summary>
    /// Displays the minimum spanning tree using Prim's Algorithm
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <returns>void</returns>
    void minSpanTree(int src);

    /// <summary>
    /// displays the Minimum spanning tree in a Matrix representation
    /// </summary>
    /// <returns>void</returns>
    void displayMinSpan();

}

