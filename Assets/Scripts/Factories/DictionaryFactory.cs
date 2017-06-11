using System;
using System.Collections.Generic;

public class DictionaryFactory<TKey, TValue> : IFactory<Dictionary<TKey, TValue>>, IFactory<IEnumerable<KeyValuePair<TKey, TValue>>>
{
    private int size;

    public DictionaryFactory(int size)
    {
        this.size = size;
    }

    public Dictionary<TKey, TValue> Create()
    {
        return new Dictionary<TKey, TValue>(size);
    }

    IEnumerable<KeyValuePair<TKey, TValue>> IFactory<IEnumerable<KeyValuePair<TKey, TValue>>>.Create()
    {
        return Create();
    }

    Dictionary<TKey, TValue> IFactory<Dictionary<TKey, TValue>>.Create()
    {
        return Create();
    }
}

