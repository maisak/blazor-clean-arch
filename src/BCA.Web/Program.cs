using BCA.Infrastructure.Database;
using BCA.Web.Components;
using BCA.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddIdentity();
builder.ConfigureSecurityFeatures();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.ConfigureSecurityFeatures();
app.UseStaticFiles();
app.MapRazorComponents<App>();
app.MapIdentityEndpoints();

app.Run();