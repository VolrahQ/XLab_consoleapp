
using System.Collections;

public class MyList : IEnumerable<int>
{
    private int[] _array = new int[4];
    private int _count = 0;

    public int Count
    {
        get { return _count; }
    }

    public void AddResize()
    {
        if (_count == _array.Length)
        {
            Array.Resize(ref _array, _count + 4);
        }
    }
    public void Add(int item)
    {
        AddResize();

        _array[_count++] = item;
    }

    public void Remove(int item)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_array[i] == item)
            {
                _array[i] = _array[_count - 1];
                _count--;
                Array.Resize(ref _array, _count);
                return;
            }
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        for (int i = index; i < _count - 1; i++)
        {
            _array[i] = _array[i + 1];
        }

        _count--;
        Array.Resize(ref _array, _count);
    }

    public void Insert(int index, int item)
    {
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException();
        }

        AddResize();

        for (int i = _count - 1; i >= index; i--)
        {
            _array[i + 1] = _array[i];
        }

        _array[index] = item;
        _count++;
    }

    public void Clear()
    {
        Array.Clear(_array, 0, _count);
        _count = 0;
        Array.Resize(ref _array, _count);
    }

    public new string ToString()
    {
        return string.Join(", ", _array);
    }
    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void ForEach(Action<int> action)
    {
        foreach (int item in this)
        {
            action(item);
        }
    }
}