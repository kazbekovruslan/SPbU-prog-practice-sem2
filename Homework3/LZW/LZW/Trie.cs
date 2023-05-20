namespace LZW;

/// <summary>
/// Trie data structure
/// </summary>
internal class Trie
{
    private Vertex root;

    public int Size { get; private set; }

    public Trie()
    {
        this.root = new Vertex();
        this.Size = 0;
    }

    /// <summary>
    /// Separate element of trie.
    /// </summary>
    private class Vertex
    {
        public Vertex()
        {
            this.Next = new Dictionary<byte, Vertex>();
        }

        public Vertex(int value)
        {
            this.Next = new Dictionary<byte, Vertex>();
            this.Value = value;
        }

        /// <summary>
        /// Collection of next vertexes.
        /// </summary>
        /// <value></value>
        public Dictionary<byte, Vertex> Next;

        /// <summary>
        /// Vertex's value.
        /// </summary>
        public int Value = 0;

        /// <summary>
        /// Shows that vertex is ending of some word.
        /// </summary>
        public bool IsTerminal;
    }

    /// <summary>
    /// Adds new element to trie.
    /// </summary>
    /// <param name="element">String that is being added.</param>
    /// <returns>
    /// true - if there was no such string,
    /// false - if there was such string.
    /// </returns>
    public bool Add(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element can't be null");
        }

        if (!element.Any())
        {
            return false;
        }

        if (Contains(element))
        {
            return false;
        }

        var currentVertex = root;
        foreach (var currentByte in element)
        {
            if (!currentVertex.Next.ContainsKey(currentByte))
            {
                currentVertex.Next[currentByte] = new Vertex(Size++);
            }

            currentVertex = currentVertex.Next[currentByte];
        }

        currentVertex.IsTerminal = true;

        return true;
    }

    /// <summary>
    /// Checks if trie contains element.
    /// </summary>
    /// <param name="element">String you want to check for being in trie.</param>
    /// <returns>
    /// true - if trie contains this string,
    /// false - if trie doesn't contain this string.
    /// </returns>
    public bool Contains(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element can't be null!");
        }

        if (!element.Any())
        {
            return false;
        }

        var currentVertex = root;

        foreach (var currentByte in element)
        {
            if (!currentVertex.Next.ContainsKey(currentByte))
            {
                return false;
            }

            currentVertex = currentVertex.Next[currentByte];
        }

        return currentVertex.IsTerminal;
    }

    public int GetValueOfElement(List<byte> element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element can't be null!");
        }

        if (!Contains(element))
        {
            return -1;
        }

        var currentVertex = root;
        foreach (var currentByte in element)
        {
            currentVertex = currentVertex.Next[currentByte];
        }

        return currentVertex.Value;
    }

    public void InitTrie()
    {
        for (int i = 0; i <= 255; ++i)
        {
            var newElementOfTrie = new List<byte>();
            newElementOfTrie.Add((byte)i);
            this.Add(newElementOfTrie);
        }
    }
}