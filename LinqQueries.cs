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

    public IEnumerable<Book> TwoThousandBooks()
    {
        //Esta es la manera con extension method
        //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

        //Manera con query expresion
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool AllBooksHaveStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SomeBookIsFromTwoThousandFive()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> PythonBooks()
    {

        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }
}