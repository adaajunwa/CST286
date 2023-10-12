using System;
using System.Reflection;

//HashTable class consists of an array of hash entries that chain in a Linked List during collision
public class HashTable<TKey, TValue> : IHashTable <TKey, TValue>
{
    private int InitialCapacity = 10; //Size of array
    private const double LoadFactor = 0.75;//number of elements in a hash table divided by the number of slots

    public Entry<TKey, TValue>[] table;//Hash table entry
    private int size; //Takes count of number of entries in the hash table

    // Inner class for entry (linked list nodes)
    public class Entry<TKey, TValue>
    {
        public TKey Key{ get; set; }// Key
        public TValue Value{ get; set; }// Value
        public Entry<TKey, TValue> Next { get; set; }// Next pointer
    }

    //HashTable method creates an array of hashtable entries
    public HashTable()
    {
        table = new Entry<TKey, TValue>[InitialCapacity];// Create new entries table
        size = 0;// Initialize size to 0
    }
    
    //Implements the GetIndex method of the IHashTable interface: Gets the hash index
    public int GetIndex(TKey key)
    {
        int hashCode = key.GetHashCode();// Get the hash code of the key
        int index = Math.Abs(hashCode) % table.Length;// Get the hash index (the reminder when absolute value of
                                                       // of the hash code is divided by the size of the entry table
        return index;// Return index
    }
    
   
    //Method ResizeTable doubles the size of the entry table
    private int ResizeTable()
    {
        InitialCapacity = InitialCapacity * 2;// Double size of entry table
        return InitialCapacity;// return new size value 
    }

    // Implements the TryGetValue method of the IHashTable interface: Gets the value of a given key
    public TValue TryGetValue(TKey key )
    {
        int index = GetIndex(key); //Get the index of the key
        var entry = table[index];//put the table element with the said index into entry variable
        TValue value;// declared a variable value as type TValue

        while (entry != null) // While the table is not empty
        {
            
            if (entry.Key.Equals(key)) // If the index' key is equal to the passes key
            {
               return value = entry.Value;// Return the index' value
                
            }
            entry = entry.Next; //Go to next entry in the linked list (the chain)
        }
        return value = default(TValue);// Return a null value   
    }


    // Implements the Remove method of the IHashTable interface: Deletes a given key from the Hash table.
    // If key is in a linked list node, transverse linked list (chain) until found
    public bool Remove(TKey key)
    {
        int index = GetIndex(key);// Get the hash index
        var entry = table[index];//Assign the entry table elements with the index to variable node entry
        Entry<TKey, TValue> prevEntry = null; //initialize node variable to hold the previous node to null
        
        while (entry != null)// While current node is not empty
        {
            if (entry.Key.Equals(key))// If the current node's key is equal to the passed key
            {
                if (prevEntry != null)// If previous node is not null
                {
                    prevEntry.Next = entry.Next;// Make current node's next, the previous node's next
                }
                else // If previous node is null
                    table[index] = entry.Next; // Make current node's next to be table index

                size--;// Reduce number of entries by 1
                return true;// Return true
            }

            prevEntry = entry;// Put current node in Previous node variable
            entry = entry.Next; // Make cureent node's next to be current node
        }

        return false;// Return false
    }

    //Implements the AddOrUpdate method of the IHashTable interface: Adds a new entry or updates the entry
    //value if the key already exists
    public void AddOrUpdate(TKey key, TValue value)
    {
        int index = GetIndex(key);//Get index using hash function in the GetIndex method
        var entry = table[index];//Assign the entry table elements with the index to variable node entry

        while (entry != null) //While current node is not empty
        {
            if (entry.Key.Equals(key))// If the current node's key is equal to the passed key 
            {
                entry.Value = value;// Make passed value the current node's value (update node)
                return; // return
            }
            entry = entry.Next; //Move to next entry node
        }
        
        // Create new entry node using passed values

        Entry<TKey, TValue> newEntry = new Entry<TKey, TValue>
        {
            Key = key,
            Value = value,
            Next = table[index]
        };

        table[index] = newEntry; //Make new entry the table index entry
        size++; // increment number of entries by 1

        if (size >= table.Length * LoadFactor) //If number of number of entries >= Hash table lenght * load factor
            ResizeTable();// Call ResizeTable method
    }
 
}