namespace FreeWheel.Domain.Commands
{
    public interface ICommand<T>
    {
        T Execute();
    }
}
