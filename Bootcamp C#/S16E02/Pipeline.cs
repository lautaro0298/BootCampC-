﻿namespace App06
{
    public class Pipeline<TInput, TOutput> : IPipeline<TInput, TOutput>
        where TInput : BaseRequest
        where TOutput : IDisposable, new()
    {
        public TOutput EjecutarTarea(TInput request)
        {
           var response = new TOutput();
            Console.WriteLine($"El Request {request}; y retorna el response {response}");
            return response;
        }
    }
}
