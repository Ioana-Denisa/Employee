using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class CityRepository(AppDbContext appDbContext) : IGenericRepository<County>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var city = await appDbContext.Counties.FindAsync(id);
            if (city == null) return NotFound();

            appDbContext.Counties.Remove(city);
            await Commit();
            return Success();
        }

        public async Task<List<County>> GetAll() => await appDbContext
            .Counties
            .AsNoTracking()
            .Include(gd => gd.Country)
            .ToListAsync();

        public async Task<County> GetByID(int id) => await appDbContext.Counties.FindAsync(id);

        public async Task<GeneralResponse> Insert(County item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "This city already added!");
            appDbContext.Counties.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(County item)
        {
            var city = await appDbContext.Counties.FindAsync(item.ID);
            if (city == null) return NotFound();
            city.Name = item.Name;
            city.CountryID= item.CountryID;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry, city not found!");
        private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Counties.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
