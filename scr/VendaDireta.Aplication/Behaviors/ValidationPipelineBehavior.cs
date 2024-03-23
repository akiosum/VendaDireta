﻿using System.Net;
using FastResults.Enums;
using FastResults.Errors;
using FastResults.Results;
using FluentValidation;
using MediatR;

namespace VendaDireta.Aplication.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> fluentValidators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResult
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        List<Error> errors = fluentValidators
            .Select(validator => validator.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error is not null)
            .Select(error => new Error(
                HttpStatusCode.BadRequest,
                error.ErrorMessage,
                TypeError.Validation))
            .Distinct()
            .ToList();

        if (errors.Any())
        {
            CreatedErrors(errors);
        }

        return await next();
    }

    private void CreatedErrors(List<Error> errors)
    {
        List<string> messages = errors
            .Select(error => error.Message)
            .ToList();
        string message = string.Join(Environment.NewLine, messages);

        throw new ValidationException(message);
    }
}