using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private int price;

    private static Product CreateProduct(string input)
    {
        string[] elements = input.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
        string name = elements[0];
        int cost = int.Parse(elements[1]);
        Product product = new Product(name, cost);

        return product;
    }

    public static List<Product> CreateListOfAllProducts(string[] input)
    {
        List<Product> products = new List<Product>();

        foreach (var productInput in input)
        {
            Product currentProduct = Product.CreateProduct(productInput);
            products.Add(currentProduct);
        }

        return products;
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }

    public Product(string name, int cost)
    {
        this.Name = name;
        this.Price = cost;
    }

    public int Price
    {
        get { return price; }

        private set
        {
            Validator.ValidateMoney(value);
            this.price = value;
        }
    }

    public string Name
    {
        get { return name; }

        private set
        {
            Validator.ValidateName(value);
            this.name = value;
        }
    }

}

