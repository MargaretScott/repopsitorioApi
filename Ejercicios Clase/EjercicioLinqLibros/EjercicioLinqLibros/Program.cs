using EjercicioLinqLibros.Clases;
using EjercicioLinqLibros.Entidades;

namespace EjercicioLinqLibros
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------Top 3 Ventas---------------");

            FuncionesEditorial funciones = new FuncionesEditorial();

            List<Book> booksTop3Sales = funciones.GetTop3BookMaxSales();

            foreach(Book book in booksTop3Sales)
            {
                Console.WriteLine($"El libro {book.Title} tiene {book.Sales} ventas.");
            }

            Console.WriteLine("--------------3 libros con menos ventas---------------");

            List<Book> booksTop3MinSales = funciones.GetTop3BookMinSales();

            foreach (Book book in booksTop3MinSales)
            {
                Console.WriteLine($"El libro {book.Title} tiene {book.Sales} ventas.");
            }

            Console.WriteLine("--------------libros escritos en los ultimos 50 años---------------");

            List<Book> booksWith50Years = funciones.GetBooks50Years();

            foreach (Book book in booksWith50Years)
            {
                Console.WriteLine($"El libro {book.Title} es de {book.PublicationDate}");
            }

            Console.WriteLine("--------------Libro mas antiguo---------------");

            Book oldestBook = funciones.GetOldestBook();

            Console.WriteLine($"El libro {oldestBook.Title} es el mas antiguo");

            Console.WriteLine("--------------Autores que tienen libros pubicados que comienzan por El---------------");

            List<Author> authors = funciones.GetAuthors("El");

            foreach (Author author in authors)
            {
                Console.WriteLine($"El autor {author.Name} tiene libros publicados que comienzan por El");
            }

            Console.WriteLine("--------------Libros publicados por autor---------------");

            List<AuthorExtendido> booksPublished = funciones.GetAuthorsAndBooksPublished();

            foreach (AuthorExtendido book in booksPublished)
            {
                Console.WriteLine($"El autor {book.AuthorName} tiene publicados {book.BooksPublished} libros");
            }

            Console.WriteLine("--------------Libros publicados por autor con lambda---------------");

            List<AuthorExtendido> booksPublished2 = funciones.GetAuthorsAndBooksPublished2();

            foreach (AuthorExtendido book in booksPublished2)
            {
                Console.WriteLine($"El autor {book.AuthorName} tiene publicados {book.BooksPublished} libros");
            }

            Console.WriteLine("--------------Libros publicados por autor con foreach---------------");

            List<AuthorExtendido> booksPublished3 = funciones.GetAuthorsAndBooksPublished3();

            foreach (AuthorExtendido book in booksPublished3)
            {
                Console.WriteLine($"El autor {book.AuthorName} tiene publicados {book.BooksPublished} libros");
            }

            Console.WriteLine("--------------Autor con mas libros publicados---------------");

            AuthorExtendido authorBestPublisher = funciones.GetAuthorBestPublisher();

            Console.WriteLine($"El autor {authorBestPublisher.AuthorName} tiene {authorBestPublisher.BooksPublished} libros publicados");

            Console.WriteLine("--------------Join de libros con autor---------------");

            List<BookExtendido> joinBooks = funciones.GetBooksJoinAuthor();

            foreach (BookExtendido book in joinBooks)
            {
                Console.WriteLine($"El libro {book.BookName} fue escrito por {book.AuthorName}");
            }

            Console.WriteLine("--------------Left Join de libros con autor---------------");

            List<BookExtendido> leftJoinBooks = funciones.GetBooksLeftJoinAuthor();

            foreach (BookExtendido book in leftJoinBooks)
            {
                Console.WriteLine($"El libro {book.BookName} fue escrito por {book.AuthorName}");
            }

        }
    }
}
