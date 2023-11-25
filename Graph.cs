using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Class for the graph - implements a graph using 2D array (Matrix) representation
public class Graph: IGraph
{
    public List<GraphNode> nodes; //list for graph vertices
    public List<int> visited = new List<int>(); // List for visited vertex nodes
    public List<int> unvisited = new List<int>();// List for unvisited vertex nodes
    public List<int> distValue = new List<int>();// List holding vertex node shortest path costs
    public List<int> unvisitedNeighbours = new List<int>();// List holding unvisited adjecent vertex nodes
    public List<int> neighbours = new List<int>();// List holding adjecent vertex nodes
    int[,] pickedEdge;// 2D array holding minimum spanning edges
    int[,] matrix;// 2D array holding graph edges

    //Constructor for the graph
    public Graph(int size)
    {
        nodes = new List<GraphNode>();// Instantiate a list of vertices
        matrix = new int[size, size];// instantiate a V*V matrix, where V is number of vertices in Graph
    }

    //Implements the addNode method in the IGraph interface; Adds a vertice node to the list
    public void addNode(GraphNode node)
    {
        nodes.Add(node);//Adds a vertice node to the list

    }

    //Implements the addEdge method in the IGraph interface; Adds an edge representation to the matrix
    public void addEdge(int src, int dest)
    {
        matrix[src, dest] = 1; //Insert 1 into the corresponding matrix' row and column
    }

    //Implements the addEdgeWeight method in the IGraph interface; Adds an edge weight to the matrix
    public void addEdgeWeight(int src, int dest, int weight)
    {
        if (matrix[src, dest] == 0 && src != dest)//if edge does not exist and there's no loop
        {

            matrix[src, dest] = weight; //Insert weight into the corresponding matrix' row and column

        }
        else if (matrix[src, dest] != 0 && matrix[src, dest] > weight)//if edge exists and existing weight > new weight
        {
            matrix[src, dest] = weight; //Insert weight into the corresponding matrix' row and column
        }
        else if (src == dest) //if a loop exists
        {
            matrix[src, dest] = 0; //Eliminate the loop
        }
    }

    //Implements the checkEdge method in the IGraph interface; checks if an edge exists in the matrix
    public void checkEdge(int src, int dest)
    {
        if (matrix[src, dest] != 0)// if matrix element is not 0
            Console.WriteLine("Edge " + matrix[src, dest] + " exists");// Display message that edge with said representation/ weight exists
        else //else if matrix element is 0
            Console.WriteLine("Edge does not exist"); // Display message that does not exist
    }


    //Implements the displayMatrix method in the IGraph interface; displays the Vertice Nodes and Matrix representation of the edges.
    public void displayMatrix()
    {
        Console.Write("  ");// Add 2 spaces to align matrix column headers on the same line
        foreach (GraphNode graphNode in nodes)// for each vertice node in the list
        {
            Console.Write(graphNode.data + " "); //Display vertice node's data and a space on the same line
        }
        Console.WriteLine(); //enter a new line

        for (int i = 0; i < matrix.GetLength(0); i++)// While i is less than the matrix row lenght, increment i by 1
        {
            Console.Write(nodes[i].data + " ");// Display list index i's data and a space on the same line 
            for (int j = 0; j < matrix.GetLength(1); j++)// While j is less than the matrix column lenght, increment i by 1
                                                         // For loop displays each matrix row
            {
                Console.Write(matrix[i, j] + " ");// Display matrix' data at row i and column j, and a space on the same line
            }
            Console.WriteLine(); //enter a new line
        }
    }

    public void depthFirstSearchRec(int src)//Recursive Depth-First Search
    {
        bool[] isvisited = new bool[matrix.GetLength(0)];//instantiate array with lenght (matrix rows)
        depthFirstSearchHelper(src, isvisited);// call recursive method helper
    }

    private void depthFirstSearchHelper(int src, bool[] isvisited)//recursive method helper
    {
        if (isvisited[src] == true)// if vertex node has been visited
        {
            return;//return
        }
        else //if vertex node has not been visited
            isvisited[src] = true;// mark vertex as visited
        Console.WriteLine(nodes[src].data + " = visited");// Display vertex
        int i = 0;// initialize counter
        while (i < matrix.GetLength(0))//while counter < matrix row lenght
        {
            if (matrix[src, i] != 0)// if adjecent edge exists
            {
                depthFirstSearchHelper(i, isvisited);// call recursively with adjacent vertex and "isvisited" list
            }
            i++;// increment counter by 1
        }
    }

    //Implements the breadthFirstSearch method in the IGraph interface; Transverses the graph in a breadth-first manner.
    public void breadthFirstSearch(int src)
    {
        Queue<int> queue = new Queue<int>();//Instantiate Queue object
        bool[] isvisited = new bool[matrix.GetLength(0)]; //Instantiate array object
        queue.Enqueue(src);//put first vertex in queue
        isvisited[src] = true;//mark vertex as visited
        while (queue.Count != 0)// while queue is not empty
        {
            src = queue.Dequeue();// remove first vertex in queue
            Console.WriteLine(nodes[src].data + " = visited");// Display vertex
            int i = 0;// initialize while counter
            while (i < matrix.GetLength(0))// while counter < lenght of matrix rows
            {
                if (matrix[src, i] != 0 && !isvisited[i])//if edge exists and adjacent vertex node is not visited
                {
                    queue.Enqueue(i);//put unvisited vertex node in queue
                    isvisited[i] = true;// put unvisited vertex node in "isvisited" array
                }
                i++;//increment counter by 1
            }
        }

    }

    //Implements the breadthFirstSearch method in the IGraph interface; Transverses the graph in a depth-first manner.
    public void depthFirstSearch(int src)//Iterative DepthFirstSearch
    {
        int flag = 0;// Initialize flag that shows stack is empty
        visited.Clear(); //clear public list "visited"
        Stack<int> myStack = new Stack<int>(); //instantiate stack object
        while (src < matrix.GetLength(0) && flag != -1)//while vertex node is within given vertices and stack is not empty
        {
            if (visited.Contains(src) == false)// if vertex is not visted
            {
                visited.Add(src);// add vertex to visited list
                myStack.Push(src);// add vertex to stack
                Console.WriteLine(nodes[src].data + " = visited"); //Console.WriteLine(src);//Display vertex node

            }
            neighbours.Clear();//clear public list "neighbours"
            unvisitedNeighbours.Clear();//clear public list "unvisitedNeighbours"
            int nextNeigbour = findMinNeighbours(src);// Call findMinNeighbours method with current vertex, and assign to "src"

            src = nextNeigbour;// assign nextNeigbour to src
            if ((nextNeigbour <= -1) && myStack.Count != 0)//If no unvisited neighbours and stack is not empty
            {
                myStack.Pop();//Remove from stack
                if (myStack.Count != 0)//if stack is not empty
                {
                    src = myStack.Peek();//assign next item in stack to src

                    //if (nextNeigbour == -1 && !neighbours.Contains(src))//if a cycle exixts
                    //{
                    //    Console.WriteLine("A Cycle Exists");//Display message
                    //    break;
                    //}
                }
                else //If stack is empty
                    flag = -1;// assign -1 to flag

            }

        }
    }

    //Implements the displayShortestPath method in the IGraph interface; Displays the shortest path from a given single source.
    public void displayShortestPath(int src)
    {
        int smallest;//Holds minimum adjecent vertex node
        int cost;// Holds vertex cost

        distValue.Add(0);//Add 0 to "distValue" list as the first vertex' cost
       
        for (int x = 1; x < matrix.GetLength(0); x++)//from the second vertex to the lenght of the matrix row
        {
            distValue.Add(int.MaxValue);//make each vertex' cost in "distValue" list the maximum int value

        }

        for (int y = 1; y < matrix.GetLength(0); y++)//from the second vertex to the lenght of the matrix row
        {
            unvisited.Add(y);//Add each vertex node to "unvisited" list

        }
        unvisitedNeighbours.Clear(); //Clear "unvisitedNeighbours" list
        visited.Clear();
        //unvisitedNeighbours.Clear();
        neighbours.Clear();
        int i = 1;// initialize while counter
        while (i <= matrix.GetLength(0) && unvisited.Count != 0)// while counter <= matrix row lenght, and unvisited list is not empty
        {
            if (visited.Count != matrix.GetLength(0))//if all vertices have not been visited  
            {
                smallest = findMinNeighbours(src);//call findMinNeighbours method with current vertex
                if (smallest <= -1 && visited.Count != 0)//if there are no unvisted adjecent vertices, and "visited" list is not empty
                {
                     visited.Add(unvisited.First());//mark first vertex in "unvisited" list as visited
                     smallest = findMinNeighbours(visited.Last());//"Backtrack" call findMinNeighbours method with last vertex in "visited" list
                    src = visited.Last();// assign last vertex in "visited" list to src
                   
                    visited.Add(smallest);//mark next unvisited adjecent vertex as visited
                    unvisited.RemoveAt(0);////remove first vertex in "unvisited" list
                    unvisited.Remove(smallest);//remove next unvisited adjecent vertex from "unvisited" list
                }
                else //if there are unvisted adjecent vertices
                {
                    visited.Add(src);//mark unvisited adjecent vertex as visited
                    unvisited.Remove(src);//remove unvisited adjecent vertex from "unvisited" list
                }
              
                for (int j = 0; j < unvisitedNeighbours.Count; j++)//for counter < number of unvisited adjecent vertices of current vertex node
                { 
                    if (unvisitedNeighbours.Count == 0)//If there are no unvisited adjecent vertices of current vertex
                    { cost = distValue[src] + matrix[src, unvisited[0]]; }//cost = cost of current vertex + edge weight of
                                                                          //(current vertex and first "unvisited" list element)
                    else//If there are unvisited adjecent vertices of current vertex
                    { cost = distValue[src] + matrix[src, unvisitedNeighbours[j]]; }//cost = cost of current vertex + edge weight of
                                                                                    //(current vertex and unvisited adjecent vertex node)
                   if (Math.Abs(distValue[unvisitedNeighbours[j]]) > cost)//if cost of unvisited adjecent vertex > cost
                    {
                       distValue[unvisitedNeighbours[j]] = cost;//new cost of unvisited adjecent vertex
                    }
                   
                }
                unvisitedNeighbours.Clear(); //Clear "unvisitedNeighbours" list
                src = smallest;//Assign smallest adjecent vertex to src 
            }
            i++;// increment while counter by 1
                        
        }
        //Display vertex node letters on same line
        foreach (GraphNode graphNode in nodes)
        {
            Console.Write(graphNode.data + " ");
        }
        Console.WriteLine(); //display a new line
        //Display each shortest path
        foreach (int item in distValue)
        {
            Console.Write(item + " ");
        }
    }

    private int findMinNeighbours(int src)// Returns smallest adjacent edge
    {
        int i = 0;// initialize while counter
        
        while (i < matrix.GetLength(0)) // while counter < matrix row lenght, iterate through the matrix src row
        {
            if (matrix[src, i] != 0) // if an edge exists
            {
                neighbours.Add(i);
                if (visited.Contains(i) == false)//if adjecent neigbour vertex is not visited
                {
                    unvisitedNeighbours.Add(i);// add to "unvisitedNeighbours" list
                }

            }
            i++;//increment counter by 1
        }
       
        if (unvisitedNeighbours.Count != 0)//if unvisitedNeighbours list is not empty
        {
            return unvisitedNeighbours.Min();//return the smallest number in the list(smallest adjecent vertex)
        }
        else if (neighbours.Count > 0 && unvisitedNeighbours.Count == 0)//if there are no unvisted adjecent vertices and a cycle exists
        {
            return -1;// return -1
        }
        else //if there are no unvisted adjecent vertices
        {
            return -2;//return -2
        }
        
    }

    //Implements the displayShortestPath method in the IGraph interface; Displays the minimum spanning tree using Prim's Algorithm
    public void minSpanTree(int src)
    {
        pickedEdge = new int[matrix.GetLength(0), matrix.GetLength(0)];//instantiate a 2d matrix with number of vertices as lenght
        var tupleList = new List<Tuple<int, int, int>>();// instatiate a list of tuples (with 3 items)
        int flag = 0;// Initialize flag that shows stack is empty
        visited.Clear(); //clear public list "visited"
        Stack<int> myStack = new Stack<int>(); //instantiate stack object
        int element = 0;// Variable for tuple index
        int i = 0;// initialize while counter
        
        
            while (src < matrix.GetLength(0) && flag != -1)//while vertex node is part of given vertices and stack is not empty
            {
            if (visited.Contains(src) == false)// if vertex is not visted
            {
                visited.Add(src);// add vertex to visited list
                myStack.Push(src);// add vertex to stack
                //Console.WriteLine(src);//Display vertex node

            }
            neighbours.Clear();
            unvisitedNeighbours.Clear();//clear public list "unvisitedNeighbours"
                int nextNeigbour = findMinNeighbours(src);// Call findMinNeighbours method with current vertex, and assign to "src"

                for (int j = 0; j < unvisitedNeighbours.Count; j++)
                {
                    if (matrix[src, unvisitedNeighbours[j]] != 0 && pickedEdge[src, unvisitedNeighbours[j]] == 0 && !tupleList.Contains(new Tuple<int,int,int>(src, unvisitedNeighbours[j], matrix[src, unvisitedNeighbours[j]])))//if edge exists im matrix, and edge has not been picked and tuple does not contain edge
                    {
                        int weight = matrix[src, unvisitedNeighbours[j]];//
                        tupleList.Add(new Tuple<int, int, int>(src, unvisitedNeighbours[j], weight));//add to tuple list source vertex, destination vertex, and edge weight
                    }
                }
            //src = nextNeigbour;// assign nextNeigbour to src
            if (tupleList.Count != 0 && nextNeigbour > 0)//if tuple list is not empty and source vertex had unvisited adjacent vertices
            {
                int smallestEdge = tupleList[0].Item3;//assign first edge weight in tuple list to smallest edge
                i = 0;// initialize while counter
                
                while (i < tupleList.Count)//iterate through tuple list find smallest weight
                {

                    if (smallestEdge >= tupleList[i].Item3)// if first tuple list element's edge weight >= next tuple list element's weight
                    {
                        smallestEdge = tupleList[i].Item3;//assign smaller edge weight to "smallestEdge"
                        element = i;//Assign tuple list element to "element"
                    }
                    i++;//increment counter by 1
                }
                
                    pickedEdge[tupleList[element].Item1, tupleList[element].Item2] = tupleList[element].Item3;//
                    src = tupleList[element].Item2;
                    
                 if (visited.Contains(tupleList[element].Item1) && visited.Contains(tupleList[element].Item2))// If both vertices have been visited (A cycle exists)
                 {
                    pickedEdge[tupleList[element].Item1, tupleList[element].Item2] = 0;//Update edge in pickedEdge matrix to 0
                    nextNeigbour = -1;// Assigng -1 to nextNeigbour so we can backtrack
                 } 
                tupleList.RemoveAt(element);
            }
            if ((nextNeigbour <= -1) && myStack.Count != 0)//If no unvisited neighbours and stack is not empty
                {
                    myStack.Pop();//Remove from stack
                    if (myStack.Count != 0)//if stack is not empty
                    {
                        src = myStack.Peek();//assign next item in stack to src
                        //if (nextNeigbour == -1 && !neighbours.Contains(src))//if a cycle exixts
                        //    {
                        //        Console.WriteLine("A Cycle Exists");//Display message
                        //        //pickedEdge[tupleList[element].Item1, tupleList[element].Item2] = 0;
                        //    }
                    }
            else //If stack is empty
                        flag = -1;// assign -1 to flag
                }
        }
        
    }

    //Implements the displayMinSpan method in the IGraph interface; displays the Minimum spanning tree in a Matrix representation.
    public void displayMinSpan()
    {
        Console.Write("  ");// Add 2 spaces to align matrix column headers on the same line
        foreach (GraphNode graphNode in nodes) // for each vertice node in the list
        {
            Console.Write(graphNode.data + " ");//Display vertice node's data and a space on the same line
        }
        Console.WriteLine();//enter a new line

        for (int i = 0; i < pickedEdge.GetLength(0); i++)// While i is less than the matrix row lenght, increment i by 1
        {
            Console.Write(nodes[i].data + " ");// Display list index i's data and a space on the same line 
            for (int j = 0; j < pickedEdge.GetLength(1); j++)// While j is less than the matrix column lenght, increment i by 1
                                                             // For loop displays each matrix row
            {
                Console.Write(pickedEdge[i, j] + " ");// Display matrix' data at row i and column j, and a space on the same line
            }
            Console.WriteLine();//enter a new line
        }
    }

   



}
