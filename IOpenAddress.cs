


public interface IOpenAddress
{
    /// <summary>
    /// Inserts a hash node with a given key and value into the hash table using the linear probe
    /// </summary>
    /// <param name="key">The key in the key-value pair</param>
    /// <param name="value">The value in the key-value pair</param>
    /// <returns>void</returns>
    void linearInsert(int key, int value);

    /// <summary>
    /// Deletes a given key
    /// </summary>
    /// <param name="key">The key in the key-value pair</param>
    /// <returns>0 if index is null, or 1 if deletion was sucessful</returns>
    int linearDeleteKey(int key);

    /// <summary>
    /// Searches for and displays the key, then returns the value if it exists 
    /// </summary>
    ///<param name="key">The key in the key-value pair </param>
    /// <returns>The index value if found, otherwise returns -1</returns>
    int linearFind(int key);

    /// <summary>
    /// inserts a hash node with a given key and value into the hash table using the quadratic probe
    /// </summary>
    /// <param name="key">The key in the key-value pair</param>
    /// <param name="value">The value in the key-value pair</param>
    /// <returns>void</returns>
    void insertQuard(int key, int value);

}

