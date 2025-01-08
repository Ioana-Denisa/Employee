using BaseLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee>Employees{ get; set; }
        public DbSet<EmployeeEquipment> EmployeeEquipments{ get; set; }
        public DbSet<Equipment> Equipments{ get; set; }
        public DbSet<EquipmentRequest> EquipmentRequests{ get; set; }
        public DbSet<Specialization> Specializations{ get; set; }
        public DbSet<StatusReguest> StatusReguests{ get; set; }
        public DbSet<Stock> Stocks{ get; set; }
        public DbSet<SystemRole> SystemRoles{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserRole> UserRoles{ get; set; }
        public DbSet<RefreshTokenInfo> RefreshTokenInfos{ get; set; }
    }
}
