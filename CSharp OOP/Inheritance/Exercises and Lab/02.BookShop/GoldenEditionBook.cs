
public class GoldenEditionBook : Book
{
    private const decimal PriceMultiplier = 1.3m;

    public GoldenEditionBook(string title, string author, decimal price)
        : base(title, author, price)
    { }
    
    public override decimal Price
    {
        get => base.Price;
        set => base.Price = (value * PriceMultiplier);
    }
}

