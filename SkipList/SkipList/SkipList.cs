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

        public SkipListElement(T? value)
        {
            Value = value;
        }
    }

    // private IComparer<T> Comparer;
    private int _numberOfLevels = 1;
    private SkipListElement? _minLevel;
    private SkipListElement? _maxLevel;

    public SkipList(/*IComparer<T> comparer*/)
    {
        _minLevel = new SkipListElement(default) {Down = null, Next = null};
        _maxLevel = _minLevel;
        Count = 0;
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
        ++Count;
        if (_minLevel!.Next == null)
        {
            _minLevel.Next = new SkipListElement(item);
            return;
        }

        bool levelUp;
        AddRecursive(item, _maxLevel!, out levelUp);
        
        if (Math.Log2(Count) >= _numberOfLevels && _maxLevel!.Down is not {Next: null})
        {
            var newLevel = new SkipListElement(default) {Down = _maxLevel, Next = null};
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
            var newElement = new SkipListElement(item) {Down = null, Next = currentElement.Next};
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
            var newElement = new SkipListElement(item) {Down = bottomElement, Next = currentElement.Next};
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
        _minLevel = new SkipListElement(default);
        _maxLevel = _minLevel;
        Count = 0;
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
            if (item.CompareTo(currentElement.Next!.Value) == 0)
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
        throw new NotImplementedException();
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

        // Если в списке есть элементы с одинаковыми значениями, то удаляться будет самый крайний
        var value = currentElement!.Value;
        currentElement = _maxLevel!.Next;
        var previousElement = _maxLevel;
        if (currentElement == null) // Исправить ошибку здесь. Ошибка: может быть такое, что искомое значение меньше, чем current.next.value
        {
            currentElement = _maxLevel.Down!.Next;
            previousElement = _maxLevel.Down;
        }
        RemoveAtRecursive(value!, currentElement!, previousElement);
    }

    private SkipListElement? RemoveAtRecursive(T item, SkipListElement currentElement, SkipListElement previousElement)
    {
        if (!(currentElement.Value!.Equals(item) && (currentElement.Next == null || !currentElement.Next.Value!.Equals(item))))
        {
            while (previousElement!.Next != currentElement)
            {
                previousElement = previousElement.Next!;
            }
            while (currentElement!.Next != null && currentElement.Value!.CompareTo(currentElement.Next.Value) >= 0)
            {
                currentElement = currentElement.Next;
                previousElement = previousElement.Next!;
            }
        }
        
        if (currentElement.Down == null)
        {
            previousElement!.Next = currentElement.Next;
            return currentElement;
        }

        if (RemoveAtRecursive(item, currentElement.Down, previousElement.Down!) == currentElement.Down)
        {
            previousElement.Next = currentElement.Next;
            return currentElement;
        }

        return null;
    }

    public T this[int index]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}