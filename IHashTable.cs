using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IHashTable<TKey, TValue>
    {
    /// <summary>
    /// Gets hash index from a hash function
    /// </summary>
    /// <param name="key">The key in the key-value pair</param>
    /// <returns>The index</returns>
    int GetIndex(TKey key);

    /// <summary>
    /// Gets the value of a given key
    /// </summary>
    /// <param name="key">The key in the key-value pair</param>
    /// <returns>Returns its value if the key is found, or else returns null</returns>
    TValue TryGetValue(TKey key);

    /// <summary>
    /// Deletes a given key from the Hash table. If key is in a linked list node, transverse linked list (chain) until found
    /// </summary>
    ///<param name="key">The key in the key-value pair </param>
    /// <returns>Returns true if found and removed, otherwise returns false</returns>
    bool Remove(TKey key);

    /// <summary>
    /// Adds a new entry or updates the entry value if the key already exists
    /// </summary>
    /// <param name="key">The key in the key-value pair</param>
    /// <param name="value">The value in the key-value pair</param>
    /// <returns>void</returns>
    void AddOrUpdate(TKey key, TValue value);

 }

   

