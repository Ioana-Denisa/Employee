using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class GeneralDepartmentRepository(AppDbContext appDbContext) : IGenericRepository<Division>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var department = await appDbContext.Divisions.FindAsync(id);
            if (department == null) return NotFound();

            appDbContext.Divisions.Remove(department);
            await Commit();
            return Success();
        }

        public async Task<List<Division>> GetAll() => await appDbContext.Divisions.ToListAsync();

        public async Task<Division> GetByID(int id) => await appDbContext.Divisions.FindAsync(id);

        public async Task<GeneralResponse> Insert(Division item)
        {
            var checkIfIsNull = await CheckName(item.Name);
            if (!checkIfIsNull)
                return new GeneralResponse(false, "This department already added!");
            appDbContext.Divisions.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Division item)
        {
            var dep = await appDbContext.Divisions.FindAsync(item.ID);
            if (dep == null) return NotFound();
            dep.Name = item.Name;
            await Commit();
            return Success();
        }

        private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry, department not found!");
        private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();
        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Divisions.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
