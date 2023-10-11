using FlavorWorld.Domain.BaseTypes;
using Microsoft.EntityFrameworkCore;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

[Owned]
public sealed class ProductDetail : ValueObject
{
    public string Description { get; private set; }
    public string Manufacturer { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public double WeightInGrams { get; private set; }
    public int StockQuantity { get; private set; }


    public ProductDetail(string description, string manufacturer, string model, string color, double weightInGrams, int stockQuantity)
    {
        Description = description;
        Manufacturer = manufacturer;
        Model = model;
        Color = color;
        WeightInGrams = weightInGrams;
        StockQuantity = stockQuantity;
    }

    public static ProductDetail Create(string description, string manufacturer, string model, string color, double weightInGrams, int stockQuantity)
    {
        return new(description, manufacturer, model, color, weightInGrams, stockQuantity);
    }

    public void ProductDetailSet(string description, string manufacturer, string model, string color, double weightInGrams, int stockQuantity)
    {
        Description = description;
        Manufacturer = manufacturer;
        Model = model;
        Color = color;
        WeightInGrams = weightInGrams;
        StockQuantity = stockQuantity;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Description;
        yield return Manufacturer;
        yield return Model;
        yield return Color;
        yield return WeightInGrams;
        yield return StockQuantity;
    }
}