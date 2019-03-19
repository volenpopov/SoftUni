namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    //using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    //using Z.EntityFramework.Plus;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db                

                Console.WriteLine();
            }
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count();

            //using Z.EntityFramework.Plus.EFCore
            //context.Books
            //    .Where(b => b.Copies < 4200)
            //    .Delete();
        }

        public static string IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            return context.SaveChanges().ToString();

            //using Z.EntityFramework.Plus.EFCore
            //return context.Books
            //    .Where(b => b.ReleaseDate.Value.Year < 2010)
            //    .Update(b => new Book() { Price = b.Price + 5 })
            //    .ToString();

            //using System.Data.SqlClient;
            //return context.Database
            //    .ExecuteSqlCommand(@"UPDATE Books
            //                         SET Price = Price + 5
            //                         WHERE YEAR(ReleaseDate) < 2010
            //                         ")
            //    .ToString();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var result = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    RecentBooks = c.CategoryBooks
                                    .OrderByDescending(x => x.Book.ReleaseDate)
                                    .Take(3)
                                    .Select(cb => new
                                    {
                                        cb.Book.Title,
                                        cb.Book.ReleaseDate
                                    })                                    
                                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var c in result)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.RecentBooks)
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var result = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            return string.Join(Environment.NewLine, result.Select(x => $"{x.CategoryName} ${x.Profit:f2}"));
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors                
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            return string
                .Join(Environment.NewLine, authors.Select(a => $"{a.FirstName + " " + a.LastName} - {a.TotalCopies}"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => EF.Functions.Like(b.Author.LastName, $"{input.ToLower()}%"))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToList();

            return string
                .Join(Environment.NewLine, books.Select(b => $"{b.Title} ({b.AuthorFirstName + " " + b.AuthorLastName})"));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //var books = context.Books
            //    .Where(b => b.Title.ToLower().Contains(input.ToLower()))
            //    .Select(b => b.Title)
            //    .OrderBy(b => b)
            //    .ToList();

            var books = context.Books
                .Where(b => b.Title.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, $"%{input}"))
                .Select(a => new { FullName = a.FirstName + " " + a.LastName })
                .OrderBy(a => a.FullName)
                .ToList();

            return string.Join(Environment.NewLine, authors.Select(a => a.FullName));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < targetDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            return string.Join(Environment.NewLine, books
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}"));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var inputCategories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => inputCategories
                        .Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            //STRING COMPARER
            //var books = context.Books
            //    .Where(b => b.BookCategories
            //        .Any(bc => inputCategories
            //            .Any(c => String.Compare(c, bc.Category.Name, true) == 0)))
            //    .Select(b => b.Title)
            //    .OrderBy(b => b)
            //    .ToList();

            //INTERSECT
            //var books = context.Books
            //    .Where(b => b.BookCategories
            //        .Select(bc => bc.Category.Name.ToLower())
            //        .Intersect(inputCategories)
            //        .Any())
            //    .Select(b => b.Title)
            //    .OrderBy(t => t));

            Console.WriteLine(books.Count);
            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new { b.Title, b.Price })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold
                    && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)                
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            object ageRestriction;

            if (!Enum.TryParse(typeof(AgeRestriction), command, true, out ageRestriction))
            {
                throw new ArgumentException("Invalid command");
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b);
                //.ToList();

            return string.Join(Environment.NewLine, books);
        }
    }
}
