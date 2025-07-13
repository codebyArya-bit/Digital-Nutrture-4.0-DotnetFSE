// Filters/CustomExceptionFilter.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace Exercise3_CustomModelAndFilters.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 1) Log full exception to a file
            var err = $"{DateTime.UtcNow:o} — {context.Exception}\n";
            File.AppendAllText("errors.log", err);

            // 2) Return a generic 500 response
            context.Result = new ObjectResult("An internal error occurred")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
