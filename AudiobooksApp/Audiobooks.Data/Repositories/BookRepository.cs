using Audiobooks.Data.Common;
using Audiobooks.Data.Contracts;
using Audiobooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audiobooks.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book, int>, IBookRepository
    {
        public BookRepository(BooksContext ctx) : base(ctx)
        {
        }

        public Book GetByCoverId(int id)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Books.First(x => x.CoverId == id);
            }
        }

        public Cover GetCoverById(int id)
        {
            using (var ctx = new BooksContext())
            {
                return ctx.Covers.First(x => x.Id == id);
            }
        }

        
        public void UpdateCover(Book book)
        {
            using (var ctx = new BooksContext())
            {
                var updateBook = ctx.Books
                    .Include(x => x.Covers)
                    .First(x => x.Id == book.Id);

                var newCovers = book.Covers.Where(x => !updateBook.Covers.Any(y => y.FilePath == x.FilePath));

                foreach (var cover in newCovers)
                    updateBook.Covers.Add(new Cover { FilePath = cover.FilePath });

                ctx.SaveChanges();
            }
        }
        
    }
}
