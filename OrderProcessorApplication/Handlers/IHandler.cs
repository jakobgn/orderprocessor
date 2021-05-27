namespace OrderProcessorApplication.Handlers
{
    public interface IHandler<T>
    {
        void Process(T request);
    }
}