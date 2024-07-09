using UneContChallenge.CrossCutting;
using UneContChallenge.Infra.Services;
using UneContChallenge.Presentation.Helpers;
using UneContChallenge.Presentation.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
DependencyInjector.Register(builder.Services);
builder.Services.AddTransient<IConvertingFilesAndSavingOnRoot, ConvertingFilesAndSavingOnRoot>();
ExtensionIOC.AddSqlServerConfig(builder.Services, builder.Configuration);
ExtensionIOC.AddAutoMapperConfig(builder.Services);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

DatabaseManagementService.MigrationInitialisation(app);
app.Run();
