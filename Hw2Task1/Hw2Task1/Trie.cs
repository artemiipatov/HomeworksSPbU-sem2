namespace Hw2Task1;

public class Trie : ITrie
{
    private class Node
    {
        public Dictionary<char, Node> Next { get; set; }

        public bool Terminal { get; set; } = false;
        public Node(char? symbol)
        {
            this.Next = new Dictionary<char, Node>();
        }
    }
    private Node root = new Node(null);

    private int Size { get; set; } = 0;

    public bool AddItem(string element)
    {
        var currentNode = root;
        for (var i = 0; i < element.Length; i++)
        {
            if (currentNode.Next.ContainsKey(element[i]))
            {
                if (i == element.Length - 1)
                {
                    currentNode.Terminal = true;
                }
                currentNode = currentNode.Next[element[i]];
            }
            else
            {
                var newNode = new Node(element[i]);
                currentNode.Next.Add(element[i], newNode);
                if (i == element.Length - 1)
                {
                    newNode.Terminal = true;
                    Size++;
                    return true;
                }

                currentNode = currentNode.Next[element[i]];
            }
        }

        return false;
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

        return true;
    }

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

    public bool Contains(string element)
    {
        var currentNode = root;
        for (var i = 0; i < element.Length; i++)
        {
            if (!currentNode.Next.ContainsKey(element[i]) || (i == element.Length - 1 && currentNode.Next[element[i]].Terminal == false))
            {
                return false;
            }
            currentNode = currentNode.Next[element[i]];
        }
        return true;
    }

    private static int HowManyStartsWithPrefixRecursive(Node pos)
    {
        var counter = 0;
        if (pos.Terminal)
        {
            ++counter;
        }

        foreach (var ch in pos.Next.Keys)
        {
            counter += HowManyStartsWithPrefixRecursive(pos.Next[ch]);
        }

        return counter;
    }

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
        return HowManyStartsWithPrefixRecursive(currentNode);
    }
}