using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateSaleHandler> _logger;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="logger">The ILogger instance</param>
    public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper, ILogger<CreateSaleHandler> logger)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a new sale for customer {Customer}", command.Customer);

        var sale = new SaleEntity
        {
            Customer = command.Customer,
            Branch = command.Branch,
            Products = command.Products.Select(p => {
                ValidateProductQuantity(p.Quantity);

                var productSale = new ProductSale
                {
                    Name = p.Name,
                    Quantity = p.Quantity,
                    UnitPrice = p.UnitPrice
                };

                ApplyDiscount(productSale);
                return productSale;
            }).ToList()
        };

        sale.CalculateTotalSaleAmount();

        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);

        _logger.LogInformation("Sale created successfully with ID {SaleId}", createdSale.Id);

        return new CreateSaleResult { Id = createdSale.Id };
    }

    private void ValidateProductQuantity(int quantity)
    {
        if (quantity > 20)
        {
            throw new InvalidOperationException("Is not possible to sell more than 20 identical items.");
        }
    }

    private void ApplyDiscount(ProductSale productSale)
    {
        if (productSale.Quantity >= 4 && productSale.Quantity < 10)
        {
            productSale.UnitPrice *= 0.9m; // 10% discount
        } else if (productSale.Quantity >= 10 && productSale.Quantity <= 20)
        {
            productSale.UnitPrice *= 0.8m; // 20% discount
        }
    }
}