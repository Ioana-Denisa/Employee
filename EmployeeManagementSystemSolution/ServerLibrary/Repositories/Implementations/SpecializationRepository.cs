using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class SpecializationRepository(AppDbContext appDbContext) : IGenericRepository<Specialization>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var specialization = await appDbContext.Specializations.FindAsync(id);
            if (specialization == null) return NotFound();

            appDbContext.Specializations.Remove(specialization);
            await Commit();
            return Success();
        }

        public async Task<List<Specialization>> GetAll() => await appDbContext.Specializations.ToListAsync();

        public async Task<Specialization> GetByID(int id) => await appDbContext.Specializations.FindAsync(id);

        public async Task<GeneralResponse> Insert(Specialization item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "This Specialization already added!");
            appDbContext.Specializations.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Specialization item)
        {
            var spec = await appDbContext.Specializations.FindAsync(item.ID);
            if (spec == null) return NotFound();
            spec.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry, Specialization not found!");
        private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Specializations.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
