namespace App06
{
    public interface IPipeline<TInput,TOutput>
        where TInput : BaseRequest
        where TOutput : IDisposable, new()
    {
        TOutput EjecutarTarea(TInput request);
    }
}
