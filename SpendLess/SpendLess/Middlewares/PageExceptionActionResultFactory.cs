﻿using Haondt.Web.Core.Services;
using SpendLess.Components;
using SpendLess.Web.Core.Exceptions;

namespace SpendLess.Middlewares
{
    public class PageExceptionActionResultFactory(IComponentFactory componentFactory) : ISpecificExceptionActionResultFactory
    {
        public bool CanHandle(Exception exception)
        {
            return exception is PageException;
        }

        public Task<IResult> CreateAsync(Exception exception, HttpContext context)
        {
            if (exception is not PageException pageException)
                throw new ArgumentException(nameof(exception));

            var result = new ErrorPage
            {
                ErrorCode = pageException.Code,
                Message = pageException.MessageArgument.HasValue ? pageException.MessageArgument.Value : pageException.Title,
                Title = pageException.Title,
                Details = pageException.ToString()
            };

            return componentFactory.RenderComponentAsync(result);
        }
    }
}
