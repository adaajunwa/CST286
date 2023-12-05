using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Class for the graph - Implements a graph using Adjacency List representation
public class AdjListGraph: IAdjListGraph
{
    public ArrayList aList;// Declare a public array list
    
    //Constructor for the graph
    public AdjListGraph(int size)
    {
        aList = new ArrayList();// instantiate an array list
    }

    //Implements the Add method in the IAdjListGraph interface; Adds a vertice node to a list, then to the Array list
    public void Add(GraphNode node)
    {
        List<GraphNode> currentList = new List<GraphNode>();//Instantiate a list that stores vertices
        currentList.Add(node);//Add vertice to the list
        aList.Add(currentList);// Add list to array list
    }

    //Implements the addEdge method in the IAdjListGraph interface; adds an edge - destination vertex is added as a new element
    //to its corresponding source list
    public void AddEdge(int src, int dest)
    {
        List<GraphNode> currentList = (List <GraphNode>) aList[src];//Pick list in array list index[src] as currentList

        List<GraphNode> destList = (List<GraphNode>)aList[dest];// Pick list in array list index[dest] as destList
        GraphNode destNode = destList[0];// Get the first vertex element in destList
        currentList.Add(destNode); // Add that the first vertex element in destList to currentList

    }
    

    public void Display()
    {
        foreach (List<GraphNode> currentList in aList)//For each list item in the arraylist
        {
            foreach (GraphNode node in currentList) //For each vertex in each list
            {
                Console.Write(node.data + "->");// Display the vertex node data with an arrow on screen
            }
            Console.WriteLine();// Enter a new line
        }

    }
}

