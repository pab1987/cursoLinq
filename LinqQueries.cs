using System.Reflection.Metadata;

class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(
                json, new System.Text.Json.JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true })
                ?? Enumerable.Empty<Book>().ToList();
        }
    }

    public IEnumerable<Book> AllCollection()
    {
        return librosCollection;
    }

    public IEnumerable<Book> TwoThousandBooks(int PageNumber, String Categories)
    {
        //Esta es la manera con extension method
        //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

        //Manera con query expresion
        return from l in librosCollection where l.PageCount > PageNumber && l.Title.Contains(Categories) select l;
    }

    public bool AllBooksHaveStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SomeBookIsFromTwoThousandFive(int Year)
    {
        return librosCollection.Any(p => p.PublishedDate.Year == Year);
    }

    public IEnumerable<Book> PythonBooks(String Categories)
    {

        return librosCollection.Where(p => p.Categories.Contains(Categories));
    }

    public IEnumerable<Book> JavaBooksAsc(String Categorie)
    {
        return librosCollection.Where(p => p.Categories.Contains(Categorie)).OrderBy(p => p.Title);
    }


    public IEnumerable<Book> BooksWihtMorePages(int NumberPages)
    {
        return librosCollection.Where(p => p.PageCount > NumberPages).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> TopThreeBooks(String Categorie, int cantidad)
    {
        return librosCollection
        .Where(p => p.Categories
        .Contains(Categorie))
        .OrderByDescending(p => p.PublishedDate)
        .Take(cantidad);
    }

    public IEnumerable<Book> ThirdFourthBook(int cantidad)
    {
        return librosCollection
        .Where(p => p.PageCount > cantidad)
        .Take(4)
        .Skip(2);
    }
}