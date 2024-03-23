using FastResults.Results;
using MediatR;

namespace VendaDireta.Aplication.Abstractions.Contracts;

public interface IRequestUseCase : IRequest<BaseResult>
{
}

public interface IRequestUseCase<TResponse> : IRequest<BaseResult<TResponse>>
{
}