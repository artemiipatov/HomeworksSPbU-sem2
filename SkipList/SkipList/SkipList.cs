namespace SkipList;

using System.Collections;

public class SkipList<T> : IList<T> where T : class, IComparable
{
    private class SkipListElement
    {
        /// <summary>
        /// Node is infinite if value is null
        /// </summary>
        public T? Value { get; private set; }
        public SkipListElement? Next { get; set; }
        public SkipListElement? Down { get; set; }

        public SkipListElement(T? value)
        {
            Value = value;
        }
    }

    // private IComparer<T> Comparer;
    private int _numberOfLevels = 2;
    private SkipListElement? _minLevel;
    private SkipListElement? _maxLevel;

    public SkipList(/*IComparer<T> comparer*/)
    {
        _minLevel = new SkipListElement(null);
        _maxLevel = _minLevel;
        // Comparer = comparer;
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
        if (_minLevel!.Value == null)
        {
            _minLevel.Next = new SkipListElement(item);
            return;
        }

        bool levelUp;
        AddRecursive(item, _maxLevel!, out levelUp);
        if (Math.Log2(Count) >= _numberOfLevels)
        {
            var newLevel = new SkipListElement(null) {Down = _maxLevel};
            _maxLevel = newLevel;
            ++_numberOfLevels;
        }
    }

    private void AddRecursive(T item, SkipListElement currentElement, out bool levelUp)
    {
        // SkipListElement? currentElement = currentLevel.Next;
        // SkipListElement? nextLevel = currentLevel.Down;
        while (currentElement.Next?.Value != null && item.CompareTo(currentElement.Next.Value) >= 0)
        {
            currentElement = currentElement.Next;
        }

        Random rand = new Random();
        
        if (currentElement.Down == null)
        {
            var newElement = new SkipListElement(item) {Next = currentElement.Next};
            currentElement.Next = newElement;
            Count++;
            // Дошел до первого уровня. Элемент вставлен. Теперь нужно вставить (если повезет) элементы в предыдущие уровни.
            if (rand.Next(2) == 1) // Выпала единица -- вставка на верхний уровень.
            {
                levelUp = true;
                return;
            }

            levelUp = false;
            return;
        }

        AddRecursive(item, currentElement.Down, out levelUp);
        if (levelUp)
        {
            var newElement = new SkipListElement(item) {Next = currentElement.Next};
            currentElement.Next = newElement;
        }
        else
        {
            return;
        }
        levelUp = rand.Next(2) == 1;
    }

    // private void LevelUpInsert(T item, SkipListElement currentLevel)
    // {
    //         
    // }
    
    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; private set; }
    public bool IsReadOnly { get; }
    public int IndexOf(T item)
    {
        throw new NotImplementedException();
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