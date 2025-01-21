
using BaseLibrary.Entities;
using BaseLibrary.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations
{
    public class EmployeeRepository(AppDbContext appDbContext) : IGenericRepository<Employee>
    {
        public async Task<GeneralResponse> DeleteByID(int id)
        {
            var item = await appDbContext.Employees.FindAsync(id);
            if (item == null)
                return NotFound();

            appDbContext.Employees.Remove(item);
            await Commit();
            return Success();

        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await appDbContext.Employees
                .AsNoTracking()
                .Include(t => t.Town)
                .ThenInclude(b => b.County)
                .ThenInclude(c => c.Country)
                .Include(s => s.Specialization)
                .ThenInclude(d => d.Department)
                .ThenInclude(div => div.Division)
                .ToListAsync();
            return employees;
        }

        public async Task<Employee> GetByID(int id)
        {
            var employee = await appDbContext.Employees
                .Include(t => t.Town)
                .ThenInclude(b => b.County)
                .ThenInclude(c => c.Country)
                .Include(s => s.Specialization)
                .ThenInclude(d => d.Department)
                .ThenInclude(div => div.Division)
                .FirstOrDefaultAsync(i => i.ID == id);
            return employee;
        }

        public async Task<GeneralResponse> Insert(Employee item)
        {
            if (!await CheckName(item.Fullname!))
                return new GeneralResponse(false, "This employee already added");

            appDbContext.Employees.Add(item);
            await Commit();
            return Success();
        }

        public async Task<GeneralResponse> Update(Employee item)
        {
            var findUser = await appDbContext.Employees.FirstOrDefaultAsync(e => e.ID == item.ID);
            if (findUser == null)
                return new GeneralResponse(false, "This employee does not exist!");

            findUser.Fullname=item.Fullname;
            findUser.Address=item.Address;
            findUser.PhoneNumber=item.PhoneNumber;
            findUser.SpecializationID=item.SpecializationID;
            findUser.TownID=item.TownID;
            findUser.HireDate=item.HireDate;
            findUser.UserID=item.UserID;
            await appDbContext.SaveChangesAsync();
            await Commit();
            return Success();
        }


        private static GeneralResponse NotFound() => new GeneralResponse(false, "Sorry, country not found!");
        private static GeneralResponse Success() => new GeneralResponse(true, "Process completed!");
        private async Task Commit() => await appDbContext.SaveChangesAsync();

        private async Task<bool> CheckName(string name)
        {
            var item = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Fullname!.ToLower().Equals(name.ToLower()));
            return item is null;
        }
    }
}
