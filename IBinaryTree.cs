using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface IBinaryTree
    {
    /// <summary>
    /// Adds a new node to the binary tree
    /// </summary>
    /// <param name="value">The value the new node should contain</param>
    /// <returns>True or False</returns>
    bool Add(int value);

    /// <summary>
    /// Transverses the binary tree in preorder and displays the values
    /// </summary>
    /// <param name="parent">The node to start transversing inorder from</param>
    /// <returns>void</returns>
    void TraversePreOrder(Node parent);

    /// <summary>
    /// Transverses the binary tree in order and displays the values
    /// </summary>
    /// <param name="parent">The node to start transversing inorder from</param>
    /// <returns>void</returns>
    void TraverseInOrder(Node parent);

    /// <summary>
    /// Transverses the binary tree in postorder and displays the values
    /// </summary>
    /// <param name="parent">The node to start transversing inorder from</param>
    /// <returns>void</returns>
    void TraversePostOrder(Node parent);

    /// <summary>
    /// Returns height of the binary tree
    /// </summary>
    /// <returns>The height of the tree</returns>
    int GetTreeHeight();

    /// <summary>
    /// Searches the Binary tree for the passed value and displays a message
    /// </summary>
    /// <param name="value">The value being searched for</param>
    /// <returns>void</returns>
    void Find(int value);

    /// <summary>
    /// Searches the Binary tree for the passed value and deletes it
    /// </summary>
    /// <param name="value">The value to be deleted</param>
    /// <returns>void</returns>
    public void Remove(int value);

    /// <summary>
    /// Returns the minimum value in a given subtree 
    /// </summary>
    /// <param name="node">The node to start the minimum value search from</param>
    /// <returns>The minimum value in a sub tree (from a given node)</returns>
    int MinValue(Node node);

    }

