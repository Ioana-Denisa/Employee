using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Repositories.Implementations
{
    public class TownRepository(AppDbContext appDbContext) : IGenericRepository<Town>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var town = await appDbContext.Towns.FindAsync(id);
            if (town == null) return NotFound();

            appDbContext.Towns.Remove(town);
            await Commit();
            return Success();
        }

        public async Task<List<Town>> GetAll() => await appDbContext.Towns.ToListAsync();

        public async Task<Town> GetByID(int id) => await appDbContext.Towns.FindAsync(id);

        public async Task<GeneralResponse> Insert(Town item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "This country already added!");
            appDbContext.Towns.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Town item)
        {
            var town = await appDbContext.Towns.FindAsync(item.ID);
            if (town == null) return NotFound();
            town.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry, country not found!");
        private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Towns.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}

