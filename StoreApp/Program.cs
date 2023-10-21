using StoreApp.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//ServiceExtension
builder.Services.ConfigureDbContext(builder.Configuration);

//Middleware inþasý gerçekleþtirildi
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

//Singleton nesne üretimi tek bir nesne üzerinden iþlem yapýlacaðý için her tarayýcýda ayný sepet gözükür. AddScopped yapýlmalý ki her kullanýcý için ayrý bir nesne üretimi gerçekleþtirilsin. Session bilgileri kullanýcýya ve taracýya özeldir. 
// Yapý gereði her defasýnda sepete bir tane ürün eklendiðinde sepet güncellenmektedir.
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
//Statik dosyalarý kullanmamýzý saðlayan konfigürasyon ifadesidir.(wwwrooot)
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
