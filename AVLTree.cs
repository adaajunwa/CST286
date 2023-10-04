//AVL Class is a self-balancing Binary search tree
public class AVL : IAVLTree
    {
       
        public AVLTNode root; //The root node of the AVL tree
        
        public void Add(int data) //Implements the IAVLTree Add method: adds a new node containing the data value, and self-balances
        {
            AVLTNode newItem = new AVLTNode(data);//Create new AVL node
            if (root == null) // if the tree is empty
            {
                root = newItem; //Make newItem the root
            }
            else
            {
                root = RecursiveInsert(root, newItem);// Call the Add method recursive helper
            }
        }
        
        //The Add method's recursive helper searches inorder for an appropriate location
        // inserts the new node, then self-balances it.
        //The private method takes in the tree's root and the new node as arguments
        private AVLTNode RecursiveInsert(AVLTNode current, AVLTNode n)
        {
            if (current == null) //Checks if tree is empty
            {
                current = n;// make new node the root node
                return current; //return new node
            }
            else if (n.data < current.data)// if tree is not empty
            {
                //recursively go to the left child, and insert new node as left child  
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);// Call the balance method to balance the tree
            }
            else if (n.data > current.data)
            {  //recursively go to the right child, and insert new node as right child 
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current); // Call the balance method to balance the tree
            }
            return current; //return the current node
        }
        private AVLTNode balance_tree(AVLTNode current)
        {
            int b_factor = balance_factor(current);//Call balance_factor method of current node
            if (b_factor > 1)//If balance factor of node > 1
            {
                if (balance_factor(current.left) > 0) //if balance factor of node's left child > 0
                {
                    current = RotateR(current); //Rotate right on current node
                }
                else //if balance factor of node's left child < 0
                {
                    current = RotateLR(current); //Rotate left then right
                }
            }
            else if (b_factor < -1) //If balance factor of node < -1
            {
                if (balance_factor(current.right) > 0) //if balance factor of node's right child > 0
                {
                    current = RotateRL(current); //Rotate right then left
                }
                else
                {
                    current = RotateL(current); //Rotate left on current node
                }
            }
            return current; // Return current node
        }
        
        //Implements the IAVLTree Delete method: deletes a node from the tree, then self-balances. 
        public void Delete(int target)
        {//and here
            root = Delete(root, target);// Calls the delete method helper
        }
        
        //The private Delete method helper accepts the root and value to delete as arguments
        private AVLTNode Delete(AVLTNode current, int target)
        {
            AVLTNode parent; //The root of the tree
            if (current == null) //If the tree is empty
            { return null; } //Return null (you have fallen off the tree
            else //If the tree is not empty
            {
                //left subtree
                if (target < current.data) //If the value passed < the current node's data
                {
                    current.left = Delete(current.left, target); //Recursively move left, and delete if found
                    if (balance_factor(current) == -2) //If balance factor is equal to -2
                    {
                        if (balance_factor(current.right) <= 0)//If balance factor of current node's right child <= 0
                        {
                            current = RotateL(current); //Rotate Left on current node
                        }
                        else
                        {
                            current = RotateRL(current);// Rotate right then left 
                        }
                    }
                }
                //right subtree
                else if (target > current.data) //If the value passed > the current node's data
                {
                    current.right = Delete(current.right, target); //Recursively move right, and delete if found
                    if (balance_factor(current) == 2) //If balance factor is equal to 2
                    {
                        if (balance_factor(current.left) >= 0) //If balance factor of current node's left child >= 0
                        {
                            current = RotateR(current); //Rotate right on current node
                        }
                        else
                        {
                            current = RotateLR(current); //Rotate left then right
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null) //if current node has a right child
                    {
                        //delete its inorder successor
                        parent = current.right; //Move to right child of current node
                        while (parent.left != null) //while right child has a left node
                        {
                            parent = parent.left; //Get leftmost node
                        }
                        current.data = parent.data;//Copy contents of inorder successor to node
                        current.right = Delete(current.right, parent.data); //Delete sucessor
                        if (balance_factor(current) == 2) // Checks and re-balances
                        {
                            if (balance_factor(current.left) >= 0) // if balance factor of left child >= 0
                            {
                                current = RotateR(current);// Rotate right on current node
                            }
                            else { current = RotateLR(current); } //Rotate left then right
                        }
                    }
                    else
                    {   //if current.left != null, return left child
                        return current.left;
                    }
                }
            }
            return current; // Return node
        }
        
        //Implements the AVLTree Find method: searches for the node containing a given value
        public void Find(int key)
        {
            if (Find(key, root).data == key) //If the key was found
            {
                Console.WriteLine("{0} was found!", key); //Display a "found" message
            }
            else //If the key was not found
            {
                Console.WriteLine("Nothing found!"); //Display a "not found" message
            }
        }
        
        //The Find method's helper, accepts the value to search for and the root as agruments
        private AVLTNode Find(int target, AVLTNode current)
        {

            if (target < current.data) //If the value to be deleted < current node's data
            {
                if (target == current.data) //If value to be deleted = current node's data
                {
                    return current;// Return the current node
                }
                else //If value to be deleted != current node's data
                    return Find(target, current.left); //Move to the left child
            }
            else //If the value to be deleted > current node's data
            {
                if (target == current.data) //If value to be deleted = current node's data
                {
                    return current; //Return the current node
                }
                else
                    return Find(target, current.right); //Move to the right child
            }

        }
        
        // Implements the IAVLTree InOrderDisplayTree method: Transverses through the tree inorder
        public void InOrderDisplayTree(AVLTNode current)
        {
            if (current != null) // If tree is not empty
            {
                InOrderDisplayTree(current.left);//Move to left child
                Console.Write("({0}) ", current.data); //Display contents of node
                InOrderDisplayTree(current.right); // Move to right child
            }
        }
        private int max(int l, int r) //The max method returns the subtree with the higher height
        {
            return l > r ? l : r; //returns the subtree with the higher height
        }
        //Implements the AVLTree getHeight method: returns the height of a given node in a tree
        public int getHeight(AVLTNode current)
        {
            int height = 0; // initialize height to 0
            if (current != null) //if tree is not empty
            {
                int l = getHeight(current.left); //Get the height of the left subtree
                int r = getHeight(current.right); //Get the height of the right subtree
                int m = max(l, r); // get the subtree with the higher height
                height = m + 1; //Add 1 to the height of the heigher subtree
            }
            return height; // return height
        }
        private int balance_factor(AVLTNode current) //This method returns the balance factor of a given node
        {
            int l = getHeight(current.left); // Get the height of the left subtree
            int r = getHeight(current.right); // Get the height of the right subtree
            int b_factor = l - r; //subtract right height from left height
            return b_factor; // Return balance factor
        }
        private AVLTNode RotateL(AVLTNode parent) //Method performs a Left rotation
        {
            AVLTNode pivot = parent.right; //Move right child into pivot variable 
            parent.right = pivot.left; //Make node's right child, parent's left child
            pivot.left = parent; // Make parent node left child
            return pivot; //Return node
        }
       
        private AVLTNode RotateR(AVLTNode parent) //Method performs a Right rotation
        {
            AVLTNode pivot = parent.left; // Move left child into pivot variable
            parent.left = pivot.right; // Make node's left child, parent's right child
            pivot.right = parent; // Make parent node right child
            return pivot; //Return node
        }
       
        private AVLTNode RotateLR(AVLTNode parent)  //Method performs a Left-Right rotation
        {
            AVLTNode pivot = parent.left; //Move left child into pivot variable
            parent.left = RotateL(pivot); //Left rotate from Left child as pivot
            return RotateR(parent); //Right rotate from parent
        }
      
        private AVLTNode RotateRL(AVLTNode parent) //Method performs a Right-Left rotation
        {
            AVLTNode pivot = parent.right; //Move right child into pivot variable
            parent.right = RotateR(pivot); //Right rotate from right child as pivot
            return RotateL(parent); //Left rotate from parent
        }
       
    }