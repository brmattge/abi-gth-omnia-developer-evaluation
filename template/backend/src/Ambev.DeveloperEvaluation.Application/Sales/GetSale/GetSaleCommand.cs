using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving sales
/// </summary>
public record GetSaleCommand : IRequest<List<GetSaleResult>>
{
}
