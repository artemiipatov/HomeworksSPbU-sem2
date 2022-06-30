namespace Hw2Task1;

/// <summary>
/// Prefix tree containing strings
/// </summary>
public class Trie
{
    private class Node
    {
        public Dictionary<char, Node> Next { get; }
        public int NumberOfSons { get; internal set; } = 0;
        public bool Terminal { get; set; } = false;
        
        public Node(char? symbol)
        {
            this.Next = new Dictionary<char, Node>();
        }
    }

    private Node root = new Node(null);

    public int Size { get; private set; }

    private bool AddItemRecursive(string element, Node currentNode, int i)
    {
        if (currentNode.Next.ContainsKey(element[i]))
        {
            if (i == element.Length - 1)
            {
                if (!currentNode.Next[element[i]].Terminal)
                {
                    ++Size;
                    ++currentNode.NumberOfSons;
                    ++currentNode.Next[element[i]].NumberOfSons;
                    currentNode.Terminal = true;
                    return true;
                }
                return false;
            }
            if (AddItemRecursive(element, currentNode.Next[element[i]], ++i))
            {
                ++currentNode.NumberOfSons;
                return true;
            }
        }
        else
        {
            var newNode = new Node(element[i]);
            currentNode.Next.Add(element[i], newNode);
            if (i == element.Length - 1)
            {
                ++Size;
                ++currentNode.NumberOfSons;
                ++currentNode.Next[element[i]].NumberOfSons;
                newNode.Terminal = true;
                return true;
            }
            if (AddItemRecursive(element, currentNode.Next[element[i]], ++i))
            {
                ++currentNode.NumberOfSons;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Adds item to prefix tree
    /// </summary>
    /// <param name="element"></param>
    /// <returns>returns true if there has been no such string in the trie, false if this string is already in the trie</returns>
    public bool AddItem(string element)
    {
        return AddItemRecursive(element, root, 0);
    }

    private static bool RemoveRecursive(string element, int symbolIndex, Node pos, ref bool canDelete)
    {
        if (symbolIndex < element.Length)
        {
            if (!pos.Next.ContainsKey(element[symbolIndex])
                || !RemoveRecursive(element, symbolIndex + 1, pos.Next[element[symbolIndex]], ref canDelete))
            {
                return false;
            }
        }
        else if (symbolIndex == element.Length)
        {
            if (!pos.Terminal)
            {
                return false;
            }
            if (pos.Next.Count != 0)
            {
                pos.Terminal = false;
                canDelete = false;
            }

            --pos.NumberOfSons;
            return true;
        }

        if (pos.Next.Count > 1)
        {
            canDelete = false;
        }

        if (canDelete)
        {
            pos.Next.Remove(element[symbolIndex]);
        }

        --pos.NumberOfSons;
        return true;
    }

    /// <summary>
    /// Removes item from prefix tree
    /// </summary>
    /// <param name="element"></param>
    /// <returns>True if the string was present in the trie, false if it wasn't</returns>
    public bool Remove(string element)
    {
        var canDelete = true;
        if (RemoveRecursive(element, 0, root, ref canDelete))
        {
            --Size;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if item is in prefix tree. Returns true if it is in tree, false if it is not
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool Contains(string element)
    {
        var currentNode = root;
        for (var i = 0; i < element.Length; i++)
        {
            if (!currentNode.Next.ContainsKey(element[i]) || (i == element.Length - 1 && !currentNode.Next[element[i]].Terminal))
            {
                return false;
            }
            currentNode = currentNode.Next[element[i]];
        }
        return true;
    }

    /// <summary>
    /// Returns number of strings in prefix tree which start with given prefix
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        var currentNode = root;
        for (var i = 0; i < prefix.Length; i++)
        {
            if (!currentNode.Next.ContainsKey(prefix[i]))
            {
                return 0;
            }
            currentNode = currentNode.Next[prefix[i]];
        }

        return currentNode.NumberOfSons;
    }
}