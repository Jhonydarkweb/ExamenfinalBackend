using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Services
{
    public interface IFraudService
    {
        Task<IEnumerable<Fraud>> GetAll();
        Task<Fraud> Add(Fraud fraud);
    }

    public class FraudService : IFraudService
    {
        private readonly LibraryContext _libraryContext;

        public FraudService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<IEnumerable<Fraud>> GetAll()
        {
            return await _libraryContext.Fraudes
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<Fraud> Add(Fraud fraud)
        {
            fraud.CreatedAt = DateTime.UtcNow;
            _libraryContext.Fraudes.Add(fraud);
            await _libraryContext.SaveChangesAsync();
            return fraud;
        }
    }
}
