using TestOrderWebApplication.Data;
using TestOrderWebApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestOrderWebApplication.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IAllOrder, OrderRepository>(); //���������� ��������� � �����

builder.Configuration.AddJsonFile("dbsettings.json").Build();
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection(); // �������������� �������������
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute(); //����������� ����� url, �� ��������� ����� ������������ url �� ���������

using (var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope())
{
    AppDBContent content;
    //���������� � ��
    // �������� ������� ��� ������� � AppDBContent
    content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Init(content);
}

app.Run();
