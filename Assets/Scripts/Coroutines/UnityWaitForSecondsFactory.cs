using UnityEngine;

public class UnityWaitForSecondsFactory : IFactory<object>
{
    private readonly float seconds;

    public UnityWaitForSecondsFactory(float seconds)
    {
        this.seconds = seconds;
    }

    object IFactory<object>.Create()
    {
        return new WaitForSeconds(seconds);
    }
}