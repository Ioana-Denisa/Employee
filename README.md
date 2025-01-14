# Employee Management System

##  Description  
**Employee Management System** is an application designed to streamline the management of employees within a factory environment. It provides an intuitive interface for maintaining employee records, monitoring their activity, and managing user roles. The system is tailored to ensure efficient handling of employee data and interactions.

---

##  Key Benefits  
- **Comprehensive Employee Database Management**: Add, update, remove, and search for employee records.
- **Role-Based Access Control**: Securely manage different user roles (Admin, Worker, Staff, and Management).
- **User-friendly interface** for all roles  
- **Request Management**: Workers can submit and track requests related to their employment details.
-  **Activity Logs**: Track employee activity and history for better decision-making. 

---


## User Story    

1. **Admin**  
   - Manage (add, update, or delete) database records.
   - Assign and update user roles. 

2. **User**  
   - View personal equipment history.  
   - Submit requests for equipment.  
   - Check the status of submitted requests.  

3. **Staff**  
   - Monitor stock levels.  
   - Distribute equipment based on approved requests.  

4. **Management**  
   - Approve or reject requests after reviewing the employee’s request history.  

---

##  Project Structure  

- **Server**: ASP.NET Core Web API  
- **Client**: Blazor  WebApp  
- **Database**: SQL Server  

---

## Instalation

**Client**:
- Blazored.LocalStorage
- Microsoft.AspNetCore.Components.Authorization
- Microsoft.AspNetCore.Components.WebAssembly
- Microsoft.AspNetCore.Components.WebAssembly.DevServer
- Microsoft.Extensions.Http
- Syncfusion.Blazor.DropDowns
- Syncfusion.Blazor.Buttons
- Syncfusion.Blazor.Popups
- Syncfusion.Blazor.Themes

**Server**:
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.IdentityModel.Tokens
- Swashbuckle.AspNetCore
- Swashbuckle.AspNetCore.Filters
- System.IdentityModel.Tokens.Jwt

**Base Library**:
- AutoMapper

**Client Library**:
- Blazored.LocalStorage
- Microsoft.AspNetCore.Components.Authorization
- Microsoft.Extensions.Http
- System.IdentityModel.Tokens.Jwt

**Server Library**:
- BCrypt.Net-Next
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.IdentityModel.Tokens
- System.IdentityModel.Tokens.Jwt

**EmployeeManagementTests**:
- Microsoft.NET.Test.Sdk
- Microsoft.Playwright
- Microsoft.Playwright.MSTest
- MSTest
- xunit.extensibility.core
  

