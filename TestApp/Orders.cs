using System.Collections.Generic;
using System.Text;

namespace TestApp;

public class Orders
{
    public static string Order(params string[] input)
    {
        Dictionary<string, decimal[]> products = new();

        foreach (string s in input)
        {
            string[] data = s.Split();

            string product = data[0];
            decimal price = decimal.Parse(data[1]);
            decimal quantity = decimal.Parse(data[2]);

            products.TryAdd(product, new[] { 0.0m, 0.0m });
            products[product][1] += quantity;
            products[product][0] = price;
        }

        StringBuilder sb = new();
        foreach (var (key, value) in products)
        {
            decimal totalPrice = value[1] * value[0];
            sb.AppendLine($"{key} -> {totalPrice:f2}");
        }

        return sb.ToString().Trim();
    }
}
