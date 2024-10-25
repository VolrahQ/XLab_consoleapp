using System;

public class MyList<T>
{
    private T[] _items;
    private int _size;

    private const int DefaultCapacity = 4;

    public MyList()
    {
        _items = new T[DefaultCapacity];
        _size = 0;
    }

    public int Count
    {
        get { return _size; }
    }

    public int Capacity
    {
        get { return _items.Length; }
        set
        {
            if (value < _size)
                throw new ArgumentOutOfRangeException(nameof(value), "Новая емкость должна быть больше _size");

            if (value != _items.Length)
            {
                T[] newItems = new T[value];
                Array.Copy(_items, newItems, _size);
                _items = newItems;
            }
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");

            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _size)
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");

            _items[index] = value;
        }
    }

    public void Add(T item)
    {
        if (_size == _items.Length)
        {
            EnsureCapacity(_size + 1);
        }
        _items[_size++] = item;
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");

        _size--;
        if (index < _size)
        {
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }
        _items[_size] = default(T);
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (Equals(_items[i], item))
                return i;
        }
        return -1;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void Clear()
    {
        for (int i = 0; i < _size; i++)
        {
            _items[i] = default(T);
        }
        _size = 0;
    }

    private void EnsureCapacity(int min)
    {
        if (_items.Length < min)
        {
            int newCapacity = _items.Length == 0 ? DefaultCapacity : _items.Length * 2;
            if (newCapacity < min) newCapacity = min;
            Capacity = newCapacity;
        }
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > _size)
            throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");

        if (_size == _items.Length)
        {
            EnsureCapacity(_size + 1);
        }

        if (index < _size)
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }

        _items[index] = item;
        _size++;
    }

    public T[] ToArray()
    {
        T[] array = new T[_size];
        Array.Copy(_items, array, _size);
        return array;
    }

    public override string ToString()
    {
        if (_size == 0)
        {
            return "[]";
        }

        string result = "[";
        for (int i = 0; i < _size; i++)
        {
            result += _items[i];
            if (i < _size - 1)
            {
                result += ", ";
            }
        }
        result += "]";
        return result;
    }

    public void ForEach(Action<T> action)
    {
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        for (int i = 0; i < _size; i++)
        {
            action(_items[i]);
        }
    }

    public T Find(Predicate<T> match)
    {
        if (match == null)
            throw new ArgumentNullException(nameof(match));

        for (int i = 0; i < _size; i++)
        {
            if (match(_items[i]))
            {
                return _items[i];
            }
        }
        return default(T);
    }

    public void Sort()
    {
        Array.Sort(_items, 0, _size);
    }

    public void Sort(IComparer<T> comparer)
    {
        Array.Sort(_items, 0, _size, comparer);
    }

    public void Sort(Comparison<T> comparison)
    {
        if (comparison == null)
            throw new ArgumentNullException(nameof(comparison));

        Array.Sort(_items, 0, _size, Comparer<T>.Create(comparison));
    }
}