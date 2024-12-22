using Ambev.DeveloperEvaluation.Dto;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response of sale.
/// </summary>
/// <remarks>
/// This response contains the sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class GetSaleResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created sale.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created sale in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// The customer who purchased
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Where the sale was made
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The products of sale
    /// </summary>
    public List<ProductSaleDto> Products { get; set; } = new List<ProductSaleDto>();
}
