
using System.Diagnostics.Contracts;
using FlavorWorld.Domain.BaseTypes;
using Microsoft.EntityFrameworkCore;

namespace FlavorWorld.Domain.Aggregates.ProductAggregate.ValueObjects;

[Owned]
public sealed class Address : ValueObject
{
    public string City { get; private set; }
    public string Country { get; private set; }
    public string Street { get; private set; }
    public string FullAddress { get; private set; }

    private Address()
    {

    }

    private Address(string city, string country, string street, string fullAddress)
    {
        City = city;
        Country = country;
        Street = street;
        FullAddress = fullAddress;
    }

    public static Address Create(string city, string country, string street, string fullAddress)
    {
        return new(city, country, street, fullAddress);
    }

    public void AddressDetailSet(string city, string country, string street, string fullAddress)
    {
        City = city;
        Country = country;
        Street = street;
        FullAddress = fullAddress;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Country;
        yield return Street;
        yield return FullAddress;
    }
}