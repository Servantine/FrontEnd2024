using utssapi.Components;
using utssapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.AllowAnyOrigin()      // Allow access from all origins
              .AllowAnyMethod()      // Allow all HTTP methods
              .AllowAnyHeader();     // Allow all headers
    });
});

// Register other services before Build
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net/") });
builder.Services.AddScoped<CategoriesService>();
builder.Services.AddScoped<CoursesService>();

var app = builder.Build();

// Apply CORS policy
app.UseCors("AllowBlazorClient");

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
