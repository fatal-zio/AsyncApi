using System;
using AsyncApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncApi.Services
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(Guid id);
    }
}
