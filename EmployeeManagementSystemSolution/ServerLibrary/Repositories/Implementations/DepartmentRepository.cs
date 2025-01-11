using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class DepartmentRepository(AppDbContext appDbContext):IGenericRepository<Department>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var department = await appDbContext.Departments.FindAsync(id);
            if (department == null) return NotFound();

            appDbContext.Departments.Remove(department);
            await Commit();
            return Success();
        }

        public async Task<List<Department>> GetAll() => await appDbContext.Departments.ToListAsync();

        public async Task<Department> GetByID(int id) => await appDbContext.Departments.FindAsync(id);

        public async Task<GeneralResponse> Insert(Department item)
        {
            if (!await CheckName(item.Name!)) return new GeneralResponse(false, "This department already added!");
            appDbContext.Departments.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Department item)
        {
            var dep = await appDbContext.Departments.FindAsync(item.ID);
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
            var item = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
