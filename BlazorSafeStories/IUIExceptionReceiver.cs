namespace BlazorSafeStories;

public interface IUIExceptionReceiver
{
    void Receive(Exception ex);
}