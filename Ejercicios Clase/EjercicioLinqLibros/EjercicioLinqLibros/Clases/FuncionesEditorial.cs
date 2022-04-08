using EjercicioLinqLibros.Entidades;
using EjercicioLinqLibros.Interfaces;

namespace EjercicioLinqLibros.Clases
{
    public class FuncionesEditorial : IFuncionesEditorial
    {
        List<Book> BookList { get; set; }
        List<Author> AuthorList { get; set; }

        public FuncionesEditorial()
        {
            BookList = Book.Books();
            AuthorList = Author.Authors();
        }

        public List<Book> GetTop3BookMaxSales()
        {
            var query
                = from book in BookList

                  orderby book.Sales descending

                  select book;

            return query.Take(3).ToList();
        }

        public List<Book> GetTop3BookMinSales()
        {
            var query
                = from book in BookList

                  orderby book.Sales ascending

                  select book;

            return query.Take(3).ToList();
        }

        public List<Book> GetBooks50Years()
        {
            var query
                = from book in BookList

                  where book.PublicationDate >= (DateTime.Now.Year - 50)

                  select book;

            return query.ToList();
        }

        public Book GetOldestBook()
        {
            var query =
                from book in BookList

                orderby book.PublicationDate ascending

                select book;

            return query.First();
        }

        public List<Author> GetAuthors(string bookTitleFilter = null)
        {
            var query =

                from authors in AuthorList

                join books in BookList on authors.AuthorId equals books.AuthorId

                where (bookTitleFilter == null || books.Title.StartsWith(bookTitleFilter))

                select authors;

            //select distinct Title
            //from books
            //where

            return query.Distinct().ToList();
        }

        public List<AuthorExtendido> GetAuthorsAndBooksPublished()
        {
            var query =
                from books in BookList

                group books by books.AuthorId into booksGroup

                join authors in AuthorList on booksGroup.Key equals authors.AuthorId

                select new AuthorExtendido
                {
                    AuthorName = authors.Name,
                    BooksPublished = booksGroup.Count()
                };


            //select count(book.AuthorId) as books, author.Name
            //from book
            //join author on book.AuthorId = book.AuthorId
            //group by book.AuthorId

            return query.ToList();
        }

        public List<AuthorExtendido> GetAuthorsAndBooksPublished2()
        {
            var query =
                from authors in AuthorList

                select new AuthorExtendido
                {
                    AuthorName = authors.Name,
                    BooksPublished = BookList.Where(book => book.AuthorId == authors.AuthorId).Count()
                };

            return query.ToList();
        }

        public List<AuthorExtendido> GetAuthorsAndBooksPublished3()
        {
            List<AuthorExtendido> result = new List<AuthorExtendido>();

            foreach (Author author in AuthorList)
            {
                result.Add(
                    new AuthorExtendido
                    {
                        AuthorName = author.Name,
                        BooksPublished = BookList.Where(book => book.AuthorId == author.AuthorId).Count()
                    });
            }

            return result;
        }

        public AuthorExtendido GetAuthorBestPublisher()
        {
            List<AuthorExtendido> authors = GetAuthorsAndBooksPublished();

            var query =
                from author in authors
                orderby author.BooksPublished descending
                select author;

            return query.First();

            //return authors.OrderByDescending(x => x.booksPublished).First();
        }

        public List<BookExtendido> GetBooksJoinAuthor()
        {
            var query =
                from books in BookList

                join authors in AuthorList on books.AuthorId equals authors.AuthorId

                select new BookExtendido
                {
                    AuthorName = authors.Name,
                    BookName = books.Title
                };

            return query.ToList();
        }

        public List<BookExtendido> GetBooksLeftJoinAuthor()
        {
            var query =
                from books in BookList

                join authors in AuthorList on books.AuthorId equals authors.AuthorId into authorBooks
                from authBook in authorBooks.DefaultIfEmpty()

                select new BookExtendido
                {
                    AuthorName = authBook == null ? "Anonimo" : authBook.Name, //if(authBook==null){"anonimo"}else{authBook.Name}
                    BookName = books.Title
                };

            //select author.Name, book.Title
            //from book
            //left join author on book.AuthotId = author.AuthorId

            return query.ToList();
        }
    }
}
