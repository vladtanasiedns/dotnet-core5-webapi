using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TodoApi.Middleware
{
    public class MyMiddleware
    {
        // The next element in the pipeline
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // Contains the implementation middleware and calls the next middleware
        public async Task InvokeAsync(HttpContext context)
        {
            //code
            // Console.WriteLine("MyMiddleware called");

            // Calls the next middleware in the pipeline
            await _next(context);
        }
    }
}