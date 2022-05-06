namespace SkipList;

using System.Collections;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private class SkipListElement
    {
        /// <summary>
        /// Node is infinite if value is null
        /// </summary>
        public T? Value { get; private set; }
        public SkipListElement? Next { get; set; }
        public SkipListElement? Down { get; set; }
        public int Key { get; }
        
        public SkipListElement(T? value, int currentKey)
        {
            Value = value;
            Key = currentKey;
        }
    }

    // private IComparer<T> Comparer;
    private int _numberOfLevels = 1;
    private SkipListElement? _minLevel;
    private SkipListElement? _maxLevel;

    public SkipList()
    {
        _minLevel = new SkipListElement(default, -1) {Down = null, Next = null};
        _maxLevel = _minLevel;
        Count = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetList().GetEnumerator();
    }

    private List<T> GetList()
    {
        var list = new List<T>();
        if (_minLevel == null)
        {
            return list;
        }
        var curElement = _minLevel.Next;
        for (int i = 0; i < Count; i++)
        {
            list.Add(curElement!.Value!);
            curElement = curElement.Next;
        }
        return list;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public void Add(T item)
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        ++Count;
        ++_currentKey;
        if (_minLevel!.Next == null)
        {
            _minLevel.Next = new SkipListElement(item, _currentKey);
            return;
        }

        bool levelUp;
        AddRecursive(item, _maxLevel!, out levelUp);
        
        if (Math.Log2(Count) >= _numberOfLevels && _maxLevel!.Down is not {Next: null})
        {
            var newLevel = new SkipListElement(default, _currentKey) {Down = _maxLevel, Next = null};
            _maxLevel = newLevel;
            ++_numberOfLevels;
        }
    }

    private SkipListElement? AddRecursive(T item, SkipListElement currentElement, out bool levelUp)
    {
        while (currentElement.Next != null && item.CompareTo(currentElement.Next.Value) >= 0)
        {
            currentElement = currentElement.Next;
        }

        Random rand = new Random();
        
        if (currentElement.Down == null)
        {
            var newElement = new SkipListElement(item, _currentKey) {Down = null, Next = currentElement.Next};
            currentElement.Next = newElement;
            // Дошел до первого уровня. Элемент вставлен. Теперь нужно вставить (если повезет) элементы в предыдущие уровни.
            if (rand.Next(2) == 1) // Выпала единица -- вставка на верхний уровень.
            {
                levelUp = true;
                return newElement;
            }

            levelUp = false;
            return newElement;
        }

        var bottomElement = AddRecursive(item, currentElement.Down, out levelUp);
        if (levelUp)
        {
            var newElement = new SkipListElement(item, _currentKey) {Down = bottomElement, Next = currentElement.Next};
            currentElement.Next = newElement;
        }
        else
        {
            return null;
        }
        levelUp = rand.Next(2) == 1;
        return currentElement.Next;
    }

    public void Clear()
    {
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        Count = 0;
        _currentKey = 0;
        _minLevel = new SkipListElement(default, -1);
        _maxLevel = _minLevel;
    }

    public bool Contains(T item)
    {
        if (_minLevel!.Next == null)
        {
            return false;
        }
        var currentElement = _maxLevel;
        while (true)
        {
            while (currentElement!.Next != null && item.CompareTo(currentElement.Next.Value) > 0)
            {
                currentElement = currentElement.Next;
            }

            if (currentElement.Next != null && item.CompareTo(currentElement.Next.Value) == 0)
            {
                return true;
            }

            if (currentElement.Down == null)
            {
                return false;
            }

            currentElement = currentElement.Down;
        }
    }
    
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (_minLevel!.Next == null)
        {
            throw new ArgumentNullException();
        }

        if (arrayIndex >= Count || arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        int counter = 0;
        var currentElement = _minLevel.Next;
        while (counter < arrayIndex)
        {
            currentElement = currentElement!.Next;
            counter++;
        }

        for (counter = 0; currentElement != null; counter++)
        {
            array[counter] = currentElement.Value!; // Не может быть null-ом, потому что добавить можно только значения типа T, а не T?
            currentElement = currentElement.Next;
        }
    }

    public bool Remove(T item)
    {
        if (_minLevel!.Next == null)
        {
            return false;
        }
        var isRemoved = RemoveRecursive(item, _maxLevel!);
        if (!isRemoved) return false;
        --Count;
        var currentLevel = _maxLevel;
        while (currentLevel!.Down?.Next == null)
        {
            _maxLevel = _maxLevel!.Down;
            currentLevel = _maxLevel;
            --_numberOfLevels;
        }
        return isRemoved;
    }

    private bool RemoveRecursive(T item, SkipListElement currentElement)
    {
        while (currentElement.Next != null && item.CompareTo(currentElement.Next.Value) > 0)
        {
            currentElement = currentElement.Next;
        }

        if (currentElement.Down == null)
        {
            if (currentElement.Next != null && item.CompareTo(currentElement.Next!.Value) == 0)
            {
                currentElement.Next = currentElement.Next.Next;
                return true;
            }

            return false;
        }

        if (RemoveRecursive(item, currentElement.Down!))
        {
            if (currentElement.Next != null && item.CompareTo(currentElement.Next!.Value) == 0)
            {
                currentElement.Next = currentElement.Next.Next;
            }

            return true;
        }

        return false;
    }

    private int _currentKey = 0;
    public int Count { get; private set; }
    public bool IsReadOnly { get; }
    public int IndexOf(T item)
    {
        int counter = 0;
        var currentElement = _minLevel!.Next;
        while (currentElement != null && !currentElement.Value!.Equals(item))
        {
            currentElement = currentElement.Next;
            ++counter;
        }

        if (currentElement != null && currentElement.Value!.Equals(item))
        {
            return counter;
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        throw new NotSupportedException("Insertion by index is not supported because the the list is sorted");
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (IsReadOnly)
        {
            throw new NotSupportedException();
        }
        
        int counter = 0;
        var currentElement = _minLevel!.Next;
        while (counter < index)
        {
            currentElement = currentElement!.Next;
            counter++;
        }

        var value = currentElement!.Value;
        int key = currentElement.Key;

        currentElement = _maxLevel;
        while (currentElement!.Next == null || value!.CompareTo(currentElement.Next.Value) < 0 ||
               value.Equals(currentElement.Next.Value) && currentElement.Next.Key > key) // не может быть нуллом, так как в начале метода есть проверка на количество элементов в спсике
        {
            currentElement = currentElement.Down;
        }
        RemoveAtRecursive(key, value, currentElement);
    }

    private void RemoveAtRecursive(int key, T value, SkipListElement currentElement)
    {
        while (currentElement.Next != null && (currentElement.Next!.Value!.CompareTo(value) < 0 ||
            (currentElement.Next.Value.Equals(value) && currentElement.Next.Key < key)))
        {
            currentElement = currentElement.Next;
        }

        if (currentElement.Down == null)
        {
            currentElement.Next = currentElement.Next!.Next;
            return;
        }

        RemoveAtRecursive(key, value, currentElement.Down);

        if (currentElement.Next != null && currentElement.Next.Value!.Equals(value) && currentElement.Next.Key == key)
        {
            currentElement.Next = currentElement.Next.Next;
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int counter = 0;
            var curElement = _minLevel;
            while (counter < index)
            {
                curElement = curElement!.Next;
                counter++;
            }

            return curElement!.Next!.Value!;
        }
        set => throw new NotSupportedException("Setting value by index is not supported because the list is sorted");
    }

    public bool IsEmpty()
    {
        return _minLevel?.Next == null;
    }
}