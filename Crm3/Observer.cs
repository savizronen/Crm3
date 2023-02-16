public class Observer : IObserver<int>
{
    public int Value { get; private set; }

    public void OnNext(int value)
    {
        Value = value;
    }

    public void OnError(Exception error)
    {
        throw error;
    }

    public void OnCompleted()
    {
        // Do nothing
    }
}