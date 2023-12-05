using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IAdjListGraph
{
    /// <summary>
    /// Adds a new vertice node to the graph
    /// </summary>
    /// <param name="node">The value the new vertice node should contain</param>
    /// <returns>void</returns>
    void Add(GraphNode node);

    /// <summary>
    /// Adds an edge representation to the matrix
    /// </summary>
    /// <param name="src">The source vertice representation</param>
    /// <param name="dest">The destination vertice representation</param>
    /// <returns>void</returns>
    void AddEdge(int src, int dest);


    /// <summary>
    /// Displays the Graph's vertice nodes in a Matrix representation
    /// </summary>
    /// <returns>void</returns>
    void Display();
}
