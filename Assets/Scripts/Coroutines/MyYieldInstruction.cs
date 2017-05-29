using System.Collections;

public abstract class MyYieldInstruction : IEnumerator
{
    public static float Time = 0;

    public abstract object Current { get; }
    public abstract bool MoveNext();
    public abstract void Reset();
}