// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Security.Cryptography.X509Certificates;

LinqQueries query = new LinqQueries();

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
//PrintValuesFilter(query.ThirdFourthBook(400));


//Libros entre 400 y 500 paginas 
//Console.WriteLine($"Cantidad de libros en el rango de 200 a 500 páginas: {query.BooksCount(200, 500)}");



//Libros con el mayor número de páginas
//Console.WriteLine($"Libro con el mayor número de paáginas: {query.BookMorePages()}");



//Libros con el menor número de páginas
//Console.WriteLine($"Libro con el menor número de páginas tiene: {query.BookMinPages()} páginas");

//Libro con menor número de páginas mayor a 0
//var libroMenorNumeroDePaginas = query.LibrosConMenorNumeroDePaginas();
//Console.WriteLine($"Título del libro: {libroMenorNumeroDePaginas.Title} - con {libroMenorNumeroDePaginas.PageCount} páginas");


//Libro con menor número de páginas mayor a 0
//var LibroConFechaMasReciente = query.LibroConFechaMasReciente();
//Console.WriteLine($"Título del libro: {LibroConFechaMasReciente.Title} - con fecha de publicación {LibroConFechaMasReciente.PublishedDate.ToShortDateString()}");


//Suma de pginas del libros entre 0 y 500
//Console.WriteLine($"Suma de las páginas de los libros entre 0 y 500 páginas {query.TotalPaginasLibrosEntre0Y500()}");

//Libros publicados despues del 2015
//Console.WriteLine(query.TitulosDeLibrosDespuesDe2015Concatenados());


//Promedio de caracteres por titulo
//Console.WriteLine($"Caracteres por titulo: {query.PromedioCaracteresTitulo()}");


//Libros despues del 2000 y agrupados por año
//ImprimirGrupo(query.LibrosDespuesDel2000AgrupadosPorAnio());

//Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = query.DiccionarioLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'S');

//Libros con Join de different collectios
PrintValuesFilter(query.LibrosDespuesdel2005ConMasde500Paginas());




void PrintValuesFilter(IEnumerable<Book> booksListFilter)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Tittle", "Page number", "Publication date");
    foreach (var item in booksListFilter)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}\n",item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString()); 
        }
        Console.WriteLine("\n");

    }

}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    foreach (var grupo in ListadeLibros)
    {
        
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in ListadeLibros[letra])
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}\n",item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString()); 
        }

    }

}