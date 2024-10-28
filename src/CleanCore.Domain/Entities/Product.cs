using System.ComponentModel;
using System.Reflection;
using CleanCore.Domain.Entities.Base;

namespace CleanCore.Domain.Entities;

public class Product : EntityBase
{
    public Product(string name, string description, int units, double valuePerUnit, DateTime expirationDate)
    {
        Name = name;
        Description = description;
        Units = units;
        ValuePerUnit = valuePerUnit;
        ExpirationDate = expirationDate;
        SetCreatedDate();
        Activate();
    }

    public Product() { }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Units { get; private set; }
    public double ValuePerUnit { get; private set; }
    public double TotalValue { get; private set; }
    public DateTime ExpirationDate { get; private set; }
}

public enum ProductError
{
    [Description("Error saving entity to the database.")]
    ErrorSavingEntityToTheDatabase
}

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }
}