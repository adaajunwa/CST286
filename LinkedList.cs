//Create a linked list class that implements the ILinked List interface
public class LinkList: ILinkedList //Inherits ILinkedList Interface
{
    public Node first;//The head of the linked list
    
    //Implements the Insertfirst method: it adds a new node to the
    //beginning of the linked list
    public void InsertFirst(int data) 
    {
        //create the new node
        Node newNode = new Node();
        //Put data in the node
        newNode.Data = data;
        //Put old node in next:
        newNode.Next = first;
        //Make the head (First) the new node
        first = newNode;
    }

    public Node DeleteFirst() // Implements the Deletes the first node in the linked list
    {
        //Assisn the temporary variable
        Node Temp = first;
        //Make the next node the head
        first = first.Next;
        return Temp;
    }


    public void DisplayList() //Displays the data in the linked list
    {
        Console.WriteLine("Iterating through linkedlist...");
        Node current = first;

        while (current != null) // While the tail has not been reached
        {
            int data = current.Data; // store current node's data in data variable
            Console.WriteLine(data); // display current node's data
            current = current.Next; // Move to next node
        }
    }
}    