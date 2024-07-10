using TestOrderWebApplication.Data;
using TestOrderWebApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestOrderWebApplication.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IAllOrder, OrderRepository>(); //объединяет интерфейс и класс

builder.Configuration.AddJsonFile("dbsettings.json").Build();
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection(); // автоматические переадресации
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute(); //отслеживает адрес url, по умолчанию будет использовать url по умолчанию

using (var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
{
    AppDBContent content;
    //подлючение к бд
    // создание области для доступа к AppDBContent
    content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Init(content);
}

app.Run();
