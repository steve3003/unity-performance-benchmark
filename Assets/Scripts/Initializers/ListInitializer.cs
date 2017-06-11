using System;
using System.Collections.Generic;

public class ListInitializer<T> : IInitializer<List<T>>, IInitializer<IEnumerable<T>>
{
    private T defaultValue;
    private int size;

    public ListInitializer(T defaultValue, int size)
    {
        this.defaultValue = defaultValue;
        this.size = size;
    }

    public void Initialize(List<T> target)
    {
        for (int i = 0; i < size; ++i)
        {
            target.Add(defaultValue);
        }
    }

    void IInitializer<IEnumerable<T>>.Initialize(IEnumerable<T> target)
    {
        Initialize((List<T>)target);
    }

    void IInitializer<List<T>>.Initialize(List<T> target)
    {
        Initialize(target);
    }
}

