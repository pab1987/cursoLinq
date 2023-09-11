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

    public int BooksCount(int range1, int range2)
    {
        return librosCollection.Count(p => p.PageCount >= range1 && p.PageCount <= range2);
    }

    public int BookMorePages()
    {
        return librosCollection.Max(p => p.PageCount);
    }

    public int BookMinPages()
    {
        return librosCollection.Min(p => p.PageCount);
    }

    public Book LibrosConMenorNumeroDePaginas()
    {
        var librosConPaginas = librosCollection.Where(p => p.PageCount > 0);

        if (librosConPaginas.Any())
        {
            return librosConPaginas.MinBy(p => p.PageCount);
        }
        else
        {
            // Manejar el caso de que no haya libros con PageCount > 0
            throw new InvalidOperationException("No hay libros con PageCount > 0.");
        }
    }


    public Book LibroConFechaMasReciente()
    {
        return librosCollection.MaxBy(p => p.PublishedDate);
    }

    public int TotalPaginasLibrosEntre0Y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string TitulosDeLibrosDespuesDe2015Concatenados()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != string.Empty)
            {
                TitulosLibros += " - " + next.Title;
            }
            else
            {
                TitulosLibros += next.Title;
            }
            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Where(p => p.PageCount > 0).Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAnio()
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p=>p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioLibrosPorLetra()
    {
        return librosCollection.ToLookup(p => p.Title[0], P => P);
    }

}