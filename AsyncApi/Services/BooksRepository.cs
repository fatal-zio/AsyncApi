using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncApi.Contexts;
using AsyncApi.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace AsyncApi.Services
{
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private readonly BooksContext _context;

        public BooksRepository(BooksContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.Include(o => o.Author).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(o => o.Author).ToListAsync();
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.Include(o => o.Author).ToList();
        }

        public Book GetBook(Guid id)
        {
            return _context.Books.Include(o => o.Author).FirstOrDefault(o => o.Id == id);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
