using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CountryRepository(AppDbContext appDbContext) : IGenericRepository<Country>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var country = await appDbContext.Countries.FindAsync(id);
            if (country == null) return NotFound();

            appDbContext.Countries.Remove(country);
            await Commit();
            return Success();
        }

        public async Task<List<Country>> GetAll() => await appDbContext.Countries.ToListAsync();

        public async Task<Country> GetByID(int id) => await appDbContext.Countries.FindAsync(id);

        public async Task<GeneralResponse> Insert(Country item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "This country already added!");
            appDbContext.Countries.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Country item)
        {
            var count = await appDbContext.Countries.FindAsync(item.ID);
            if (count == null) return NotFound();
            count.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry, country not found!");
        private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
