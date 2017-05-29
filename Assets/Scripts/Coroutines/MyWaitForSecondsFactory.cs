public class MyWaitForSecondsFactory : IFactory<object>
{
    private readonly float seconds;

    public MyWaitForSecondsFactory(float seconds)
    {
        this.seconds = seconds;
    }

    object IFactory<object>.Create()
    {
        return new MyWaitForSeconds(seconds);
    }
}