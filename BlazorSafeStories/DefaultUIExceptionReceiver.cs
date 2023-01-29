namespace BlazorSafeStories;

public class DefaultUIExceptionReceiver : IUIExceptionReceiver
{
    public event EventHandler<Exception>? OnUIException;

    public void Receive(Exception ex)
    {
        if (OnUIException == null)
            return;

        foreach(EventHandler<Exception> del in OnUIException.GetInvocationList())
        {
            try
            {
                del(this, ex);
            }
            catch(Exception e)
            {
                // ignored
            }
        }
    }
}