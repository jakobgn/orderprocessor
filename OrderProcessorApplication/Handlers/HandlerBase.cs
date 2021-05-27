namespace OrderProcessorApplication.Handlers
{
    public abstract class HandlerBase<T> : IHandler<T>
    {
        private IHandler<T> _next;

        public void SetNext(IHandler<T> handler)
        {
            _next = handler;
        }

        public virtual void Process(T request)
        {
            _next?.Process(request);
        }
    }
}