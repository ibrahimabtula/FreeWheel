namespace FreeWheel.Domain.Queries
{
    public interface IQuery<T>
    {
        T Execute();
    }
}
