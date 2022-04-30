using System.Diagnostics.Metrics;

namespace SkipList;

using System.Collections;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private class SkipListElement
    {
        public SkipListElement?[] Next = new SkipListElement?[5];

        public int NumberOfLevels = 0;

        public T? Value { get; private set; }
        
        public SkipListElement(T? value, int numberOfLevels)
        {
            Value = value;
            NumberOfLevels = numberOfLevels;
        }
    }

    private SkipListElement _firstElement = new SkipListElement(default, 1);

    public SkipList()
    {
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        if (_firstElement.Next[0] == null)
        {
            Random rand = new Random();
            _firstElement.Next[0] = new SkipListElement(item, 1);
            return;
        }
        AddRecursive(item, _firstElement, _firstElement.NumberOfLevels);
    }

    private SkipListElement AddRecursive(T item, SkipListElement currentElement, int currentLevel)
    {
        while (currentElement.Next[currentLevel - 1] != null && currentElement.Next[currentLevel - 1]!.Value!.CompareTo(item) > 0)
        {
            currentElement = currentElement.Next[currentLevel - 1]!;
        }

        if (currentLevel == 1)
        {
            int level = new Random().Next(1, _firstElement.NumberOfLevels);
            var newElement = new SkipListElement(item, level);
            newElement.Next[0] = currentElement.Next[0];
            currentElement.Next[0] = newElement;
            return newElement;
        }

        var addedElement = AddRecursive(item, currentElement, currentLevel - 1);
        if (currentLevel <= addedElement.NumberOfLevels)
        {
            addedElement.Next[currentLevel - 1] = currentElement.Next[currentLevel - 1];
            currentElement.Next[currentLevel - 1] = addedElement.Next[currentLevel - 1];
        }
        return addedElement;
    }

    public void Clear()
    {
        _firstElement = new SkipListElement(default, 1);
    }

    public bool Contains(T item)
    {
        return ContainsRecursive(item, _firstElement, _firstElement.NumberOfLevels);
    }

    private bool ContainsRecursive(T item, SkipListElement currentElement, int currentLevel)
    {
        while (currentElement.Next[currentLevel - 1] != null && currentElement.Next[currentLevel - 1]!.Value!.CompareTo(item) > 0)
        {
            currentElement = currentElement.Next[currentLevel - 1]!;
        }

        return currentElement.Next[currentLevel - 1] != null &&
               currentElement.Next[currentLevel - 1]!.Value!.CompareTo(item) == 0 ||
               currentLevel != 1 && ContainsRecursive(item, currentElement, currentLevel - 1);
    }
    
    public void CopyTo(T[] array, int arrayIndex)
    {
        var currentElement = _firstElement.Next[0];
        int counter = 0;
        while (currentElement != null)
        {
            array[counter] = currentElement.Value!; // null-ом быть не может, так как метод Add добавляет значения с типом T
            currentElement = currentElement.Next[0];
            counter++;
        }
    }

    public bool Remove(T item)
    {
        if (_firstElement.Next[0] == null)
        {
            return false;
        }

        return RemoveRecursive(item, _firstElement, _firstElement.NumberOfLevels) != -1;
    }

    private int RemoveRecursive(T item, SkipListElement currentElement, int currentLevel)
    {
        while (currentElement.Next[currentLevel - 1] != null && currentElement.Next[currentLevel - 1]!.Value!.CompareTo(item) > 0)
        {
            currentElement = currentElement.Next[currentLevel - 1]!;
        }

        if (currentLevel == 1)
        {
            if (currentElement.Next[1] == null)
            {
                return -1;
            }
            if (currentElement.Next[currentLevel - 1]!.Value!.CompareTo(item) == 0)
            {
                int level = currentElement.Next[1]!.NumberOfLevels;
                return level;
            }
        }

        int levelOfRemovedElement = RemoveRecursive(item, currentElement, currentLevel - 1);
        if (levelOfRemovedElement == -1)
        {
            return -1;
        }

        if (currentLevel >= levelOfRemovedElement)
        {
            currentElement.Next[currentLevel - 1] = currentElement.Next[currentLevel - 1]!.Next[currentLevel - 1];
        }

        return levelOfRemovedElement;
    }

    public int Count { get; private set; }
    public bool IsReadOnly { get; }
    public int IndexOf(T item)
    {
        var currentElement = _firstElement.Next[0];
        int counter = 0;
        while (currentElement != null && currentElement.Value!.CompareTo(item) > 0)
        {
            currentElement = currentElement.Next[0];
        }

        if (currentElement != null && currentElement!.Value!.CompareTo(item) == 0)
        {
            return counter;
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        throw new NotImplementedException();
    }

    public void RemoveAt(int index)
    {
        throw new NotImplementedException();
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}