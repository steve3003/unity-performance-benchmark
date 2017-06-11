using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ListBuilderView
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

    public List<T> Build<T>()
    {
        var factory = new ListFactory<T>(size);
        var list = factory.Create();
        var initializer = new ListInitializer<T>(default(T), size);
        initializer.Initialize(list);
        return list;
    }
}

