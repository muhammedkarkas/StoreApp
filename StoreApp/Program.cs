using StoreApp.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//ServiceExtension
builder.Services.ConfigureDbContext(builder.Configuration);

//Middleware in�as� ger�ekle�tirildi
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

//Singleton nesne �retimi tek bir nesne �zerinden i�lem yap�laca�� i�in her taray�c�da ayn� sepet g�z�k�r. AddScopped yap�lmal� ki her kullan�c� i�in ayr� bir nesne �retimi ger�ekle�tirilsin. Session bilgileri kullan�c�ya ve tarac�ya �zeldir. 
// Yap� gere�i her defas�nda sepete bir tane �r�n eklendi�inde sepet g�ncellenmektedir.
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//Statik dosyalar� kullanmam�z� sa�layan konfig�rasyon ifadesidir.(wwwrooot)
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{ id ?}");

    endpoints.MapControllerRoute( 
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.ConfigureAndCheckMigration();
    

app.Run();
