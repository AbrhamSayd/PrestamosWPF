using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace PrestamosWPF.Utilities;

public class MyObservableListWrapper<T> : IList<T>, INotifyCollectionChanged
{
    private readonly IList<T> _list;

    public MyObservableListWrapper(IList<T> list)
    {
        _list = list;
    }

    public void Insert(int index, T item)
    {
        _list.Insert(index, item);
        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index);
        OnCollectionChanged(e);
    }

    public void Add(T item)
    {
        _list.Add(item);
        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item);
        OnCollectionChanged(e);
    }

    public void Clear()
    {
        _list.Clear();
        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
        OnCollectionChanged(e);
    }

    public bool Remove(T item)
    {
        var result = _list.Remove(item);
        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item);
        OnCollectionChanged(e);

        return result;
    }

    public void RemoveAt(int index)
    {
        _list.RemoveAt(index);
        var e = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, this[index], index);
        OnCollectionChanged(e);
    }

    public int IndexOf(T item)
    {
        return _list.IndexOf(item);
    }

    public T this[int index]
    {
        get => _list[index];
        set => _list[index] = value;
    }

    public bool Contains(T item)
    {
        return _list.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _list.CopyTo(array, arrayIndex);
    }

    public int Count => _list.Count;

    public bool IsReadOnly => _list.IsReadOnly;

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_list).GetEnumerator();
    }

    public event NotifyCollectionChangedEventHandler CollectionChanged;

    protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
    {
        if (CollectionChanged != null) CollectionChanged(this, e);
    }
}