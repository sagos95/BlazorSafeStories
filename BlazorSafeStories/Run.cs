namespace BlazorSafeStories;

public class Run
{
    private readonly IUIExceptionReceiver _exceptionReceiver;

    public Run(IUIExceptionReceiver exceptionReceiver)
    {
        _exceptionReceiver = exceptionReceiver;
    }

    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="action"></param>
    /// <param name="onError"></param>
    public void AsSafe(Action action, Action<Exception>? onError = null)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            onError?.Invoke(ex);
            _exceptionReceiver.Receive(ex);
        }
    }

    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="func"></param>
    /// <param name="onErrorTask"></param>
    public async void AsSafe(Func<Task> func, Func<Exception, Task> onErrorTask)
    {
        try
        {
            await func();
        }
        catch (Exception ex)
        {
            await onErrorTask.Invoke(ex);
            _exceptionReceiver.Receive(ex);
        }
    }

    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="func"></param>
    /// <param name="onError"></param>
    public T? AsSafe<T>(Func<T> func, Action<Exception>? onError = null)
    {
        try
        {
            return func();
        }
        catch (Exception ex)
        {
            onError?.Invoke(ex);
            _exceptionReceiver.Receive(ex);
            return default;
        }
    }

    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="task"></param>
    /// <param name="onError"></param>
    public async void AsSafe(Func<Task> task, Action<Exception>? onError = null)
    {
        try
        {
            await task();
        }
        catch (Exception ex)
        {
            onError?.Invoke(ex);
            _exceptionReceiver.Receive(ex);
        }
    }

    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="func"></param>
    /// <param name="onErrorValueFactory"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T AsSafeValue<T>(Func<T> func, Func<Exception, T> onErrorValueFactory)
    {
        try
        {
            return func();
        }
        catch (Exception ex)
        {
            var newValue = onErrorValueFactory.Invoke(ex);
            _exceptionReceiver.Receive(ex);
            return newValue;
        }
    }

    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="task"></param>
    /// <param name="onError"></param>
    /// <returns></returns>
    public async Task AsSafeTask(Func<Task> task, Action<Exception>? onError = null)
    {
        try
        {
            await task();
        }
        catch (Exception ex)
        {
            onError?.Invoke(ex);
            _exceptionReceiver.Receive(ex);
        }
    }
}
