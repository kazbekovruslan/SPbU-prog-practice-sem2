namespace Trie;

using System;
using System.Collections.Generic;

/// <summary>
/// Trie data structure
/// </summary>
class Trie
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
            this.Next = new Dictionary<char, Vertex>();
            this.AmountOfWordsWithSamePrefix = 0;
            this.IsTerminal = false;
        }

        /// <summary>
        /// Collection of next vertexes.
        /// </summary>
        /// <value></value>
        public Dictionary<char, Vertex> Next { get; }

        /// <summary>
        /// Shows how many words start with prefix that made by sequence of previous vertexes.
        /// </summary>
        public int AmountOfWordsWithSamePrefix;

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
    public bool Add(string? element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element can't be null");
        }

        if (Contains(element))
        {
            return false;
        }

        var currentVertex = root;
        foreach (var symbol in element)
        {
            ++currentVertex.AmountOfWordsWithSamePrefix;

            if (!currentVertex.Next.ContainsKey(symbol))
            {
                currentVertex.Next[symbol] = new Vertex();
            }

            currentVertex = currentVertex.Next[symbol];
        }

        ++currentVertex.AmountOfWordsWithSamePrefix;
        ++Size;
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
    public bool Contains(string? element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element can't be null!");
        }

        var currentVertex = root;

        foreach (var symbol in element)
        {
            if (!currentVertex.Next.ContainsKey(symbol))
            {
                return false;
            }

            currentVertex = currentVertex.Next[symbol];
        }

        return currentVertex.IsTerminal;
    }

    /// <summary>
    /// Removes element from trie.
    /// </summary>
    /// <param name="element">String you want to remove from the trie.</param>
    /// <returns>
    /// true - if there was such string in trie,
    /// false - if there was no such string in trie.
    /// </returns>
    public bool Remove(string? element)
    {
        if (element == null)
        {
            throw new ArgumentNullException("Element can't be null!");
        }

        if (!Contains(element))
        {
            return false;
        }

        var currentVertex = root;
        foreach (var symbol in element)
        {
            --currentVertex.AmountOfWordsWithSamePrefix;

            if (currentVertex.Next[symbol].AmountOfWordsWithSamePrefix == 1)
            {
                currentVertex.Next.Remove(symbol);
                --Size;
                return true;
            }

            currentVertex = currentVertex.Next[symbol];
        }

        --currentVertex.AmountOfWordsWithSamePrefix;
        --Size;
        currentVertex.IsTerminal = false;

        return true;
    }

    /// <summary>
    /// Return how many elements in trie start with this prefix
    /// </summary>
    /// <param name="prefix">Some string that is a prefix.</param>
    /// <returns>Amount of elements in trie that start with this prefix.</returns>
    public int HowManyStartWithPrefix(string? prefix)
    {
        if (prefix == null)
        {
            throw new ArgumentNullException("Prefix can't be null!");
        }

        var currentVertex = root;
        foreach (var symbol in prefix)
        {
            if (!currentVertex.Next.ContainsKey(symbol))
            {
                return 0;
            }

            currentVertex = currentVertex.Next[symbol];
        }

        return currentVertex.AmountOfWordsWithSamePrefix;
    }
}