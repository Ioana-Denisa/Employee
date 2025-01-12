using BaseLibrary.Entities;
using Blazored.LocalStorage;
using Client;
using Client.ApplicationStates;
using ClientLibrary.Helpers;
using ClientLibrary.Services.Contracts;
using ClientLibrary.Services.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<CustomHttpHandler>();
builder.Services.AddHttpClient("SystemApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7093/");
}).AddHttpMessageHandler<CustomHttpHandler>(); 

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7093/") });

builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<GetHttpClient>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService,UserAccountService>();

builder.Services.AddScoped<IGenericService<GeneralDepartment>,GenericServiceImplementation<GeneralDepartment>>();
builder.Services.AddScoped<IGenericService<Department>,GenericServiceImplementation<Department>>();
builder.Services.AddScoped<IGenericService<Specialization>,GenericServiceImplementation<Specialization>>();

builder.Services.AddScoped<IGenericService<Country>,GenericServiceImplementation<Country>>();
builder.Services.AddScoped<IGenericService<City>,GenericServiceImplementation<City>>();
builder.Services.AddScoped<IGenericService<Town>,GenericServiceImplementation<Town>>();

builder.Services.AddScoped<IGenericService<Employee>,GenericServiceImplementation<Employee>>();

builder.Services.AddScoped<AllState>();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF5cXmBCf0x3TXxbf1x1ZFdMZVVbR3dPIiBoS35Rc0ViWH5fdHFcRWFaUkV0");


await builder.Build().RunAsync();
