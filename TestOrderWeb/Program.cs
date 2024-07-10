using Microsoft.AspNetCore.Mvc;
using TestOrderWebApplication.Data;
using TestOrderWebApplication.Data.Interfaces;
using TestOrderWebApplication.Data.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Options;
using TestOrderWebApplication.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IAllOrder, OrderRepository>(); //объединяет интерфейс и класс

builder.Configuration.AddJsonFile("dbsettings.json").Build();
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//IConfigurationRoot _confString;
//IHostingEnvironment _hostEnv;
//_confString = new ConfigurationBuilder().SetBasePath(_hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();

var app = builder.Build();

//app.

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

//app.MapGet("/", () => "Hello World!");

app.Run();
