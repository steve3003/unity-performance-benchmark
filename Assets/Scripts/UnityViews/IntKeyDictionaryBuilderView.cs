using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IntKeyDictionaryBuilderView
{
    [SerializeField]
    private ObjectType type = ObjectType.Int;
    [SerializeField]
    private int size = 10;

    public ObjectType Type
    {
        get
        {
            return type;
        }
    }

    public int Size
    {
        get
        {
            return size;
        }
    }

    public Dictionary<int, T> Build<T>()
    {
        var factory = new DictionaryFactory<int, T>(size);
        var list = factory.Create();
        var initializer = new IntKeyDictionaryInitializer<T>(default(T), size);
        initializer.Initialize(list);
        return list;
    }
}

