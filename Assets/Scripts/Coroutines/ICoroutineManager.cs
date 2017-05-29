using System.Collections;

public interface ICoroutineManager
{
    IEnumerator StartCoroutine(IEnumerator coroutine);
    void StopCoroutine(IEnumerator coroutine);
    void StopAllCoroutines();
    void Update();
}

