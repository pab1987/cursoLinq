// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Security.Cryptography.X509Certificates;

LinqQueries query  = new LinqQueries();

//Imprime en consola todos los libros
//PrintValues(query.AllCollection());


//Imprime en la consola los libros del año 2000
//PrintValuesFilter(query.TwoThousandBooks(250, "In Action"));



/* void PrintValues(IEnumerable<Book> booksList) 
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Tittle", "Page number", "Publication date");
    foreach (var item in booksList)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
} */

//Todos los libros tienen stattus
//Console.WriteLine($"Todos los libros tienen un status? - {query.AllBooksHaveStatus()}");

//Algun libro fue publicado en 2005
//Console.WriteLine($"Algún libro fue publicado en 2005 ? - {query.SomeBookIsFromTwoThousandFive(2005)}");

//Libros de python
//PrintValuesFilter(query.PythonBooks("Python"));

//Libros de Java
//PrintValuesFilter(query.JavaBooksAsc("Java"));

//Libros con mas de 450 paginas ordenador de forma decendente
//PrintValuesFilter(query.BooksWihtMorePages(450));

//Reto operador Take
//PrintValuesFilter(query.TopThreeBooks("Java", 3));


//Tercer y cuarto libro usando operador Skip
PrintValuesFilter(query.ThirdFourthBook(400));


void PrintValuesFilter(IEnumerable<Book> booksListFilter)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Tittle", "Page number", "Publication date");
    foreach (var item in booksListFilter)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}