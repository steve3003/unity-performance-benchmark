using System;
using System.Collections.Generic;

public class IntKeyDictionaryInitializer<T> : IInitializer<Dictionary<int, T>>, IInitializer<IEnumerable<KeyValuePair<int, T>>>
{
    private T defaultValue;
    private int size;

    public IntKeyDictionaryInitializer(T defaultValue, int size)
    {
        this.defaultValue = defaultValue;
        this.size = size;
    }

    public void Initialize(Dictionary<int, T> target)
    {
        for (int i = 0; i < size; ++i)
        {
            target.Add(i, defaultValue);
        }
    }

    void IInitializer<Dictionary<int, T>>.Initialize(Dictionary<int, T> target)
    {
        Initialize(target);
    }

    void IInitializer<IEnumerable<KeyValuePair<int, T>>>.Initialize(IEnumerable<KeyValuePair<int, T>> target)
    {
        Initialize((Dictionary<int, T>)target);
    }
}

