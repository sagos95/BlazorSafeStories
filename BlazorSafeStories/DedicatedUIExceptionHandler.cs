namespace BlazorSafeStories;

public class DedicatedUIExceptionHandler : IUIExceptionReceiver
{
    private Action<Exception> _onException;

    public DedicatedUIExceptionHandler(Action<Exception> onException)
    {
        _onException = onException;
    }

    public void Receive(Exception ex)
    {
        _onException(ex);
    }
}