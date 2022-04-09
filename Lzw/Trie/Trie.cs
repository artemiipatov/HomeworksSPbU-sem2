namespace Trie;

/// <summary>
/// Prefix tree containing byte sequence
/// </summary>
public class Trie
{
    private class Node
    {
        public Dictionary<byte, Node> Next { get; set; }

        public int Terminal { get; set; } = -1;
        public Node(byte? symbol)
        {
            this.Next = new Dictionary<byte, Node>();
        }
    }
    private Node root = new Node(null);

    public int Size { get; private set; }

    /// <summary>
    /// Adds item to prefix tree
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public bool AddItem(byte[] sequence)
    {
        var currentNode = root;
        for (var i = 0; i < sequence.Length; i++)
        {
            if (currentNode.Next.ContainsKey(sequence[i]))
            {
                if (i == sequence.Length - 1)
                {
                    currentNode.Terminal = Size;
                }
                currentNode = currentNode.Next[sequence[i]];
            }
            else
            {
                var newNode = new Node(sequence[i]);
                currentNode.Next.Add(sequence[i], newNode);
                if (i == sequence.Length - 1)
                {
                    newNode.Terminal = Size;
                    Size++;
                    return true;
                }

                currentNode = currentNode.Next[sequence[i]];
            }
        }

        return false;
    }

    private bool RemoveRecursive(byte[] sequence, int symbolIndex, Node pos, ref bool canDelete)
    {
        if (symbolIndex < sequence.Length)
        {
            if (!pos.Next.ContainsKey(sequence[symbolIndex])
                || !RemoveRecursive(sequence, symbolIndex + 1, pos.Next[sequence[symbolIndex]], ref canDelete))
            {
                return false;
            }
        }
        else if (symbolIndex == sequence.Length)
        {
            if (pos.Terminal == -1)
            {
                return false;
            }
            if (pos.Next.Count != 0)
            {
                pos.Terminal = -1;
                canDelete = false;
            }
            return true;
        }

        if (pos.Next.Count > 1)
        {
            canDelete = false;
        }

        if (canDelete)
        {
            pos.Next.Remove(sequence[symbolIndex]);
        }

        return true;
    }

    /// <summary>
    /// Removes item from prefix tree
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public bool Remove(byte[] sequence)
    {
        var canDelete = true;
        if (RemoveRecursive(sequence, 0, root, ref canDelete))
        {
            --Size;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Checks if item is in prefix tree. Returns true if it is in tree, false if it is not
    /// </summary>
    /// <param name="sequence"></param>
    /// <returns></returns>
    public bool Contains(byte[] sequence)
    {
        var currentNode = root;
        for (var i = 0; i < sequence.Length; i++)
        {
            if (!currentNode.Next.ContainsKey(sequence[i]) || (i == sequence.Length - 1 && currentNode.Next[sequence[i]].Terminal == -1))
            {
                return false;
            }
            currentNode = currentNode.Next[sequence[i]];
        }
        return true;
    }

    public int GetNumber(byte[] sequence)
    {
        var currentNode = root;
        for (var i = 0; i < sequence.Length; i++)
        {
            if (!currentNode.Next.ContainsKey(sequence[i]))
            {
                return -1;
            }
            if (i == sequence.Length - 1)
            {
                return currentNode.Next[sequence[i]].Terminal == -1 ? -1 : currentNode.Next[sequence[i]].Terminal; // Убрать лишнее
            }
            currentNode = currentNode.Next[sequence[i]];
        }

        return -1;
    }
}