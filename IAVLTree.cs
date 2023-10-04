public interface IAVLTree
{
    /// <summary>
    /// Adds a new node to the binary tree and self-balances
    /// </summary>
    /// <param name="data">The value the new node should contain</param>
    /// <returns>True or False</returns>
    void Add(int data);

    /// <summary>
    /// Transverses the binary tree in order and displays the values
    /// </summary>
    /// <param name="current">The node to start transversing inorder from</param>
    /// <returns>void</returns>
    void InOrderDisplayTree(AVLTNode current);

    
    /// <summary>
    /// Returns height of the binary tree from a given node
    /// </summary>
    ///<param name="current">The node to start balancing from /param>
    /// <returns>The height of the tree</returns>
    int getHeight(AVLTNode current);

    /// <summary>
    /// Searches the Binary tree for the passed value and displays a message
    /// </summary>
    /// <param name="key">The value being searched for</param>
    /// <returns>void</returns>
    void Find(int key);

    /// <summary>
    /// Searches the Binary tree for the passed value, deletes it, and balances itself
    /// </summary>
    /// <param name="target">The value to be deleted</param>
    /// <returns>void</returns>
    void Delete(int target);

  

}