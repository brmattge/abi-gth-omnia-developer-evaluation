﻿using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Dto;

/// <summary>
/// Represents a DTO product inside new sale in the system.
/// </summary>
public class CreateProductSaleDto
{
    /// <summary>
    /// The unique identifier of the product sale
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; set; }

    /// <summary>
    /// The name of product
    /// </summary>  
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of product
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of product
    /// </summary>
    public decimal UnitPrice { get; set; }
}