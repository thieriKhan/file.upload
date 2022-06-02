using file.upload.Data_context;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(
  options =>
  {
    options.UseSqlServer("Data Source=THIERI;Initial Catalog=file;Integrated Security=True;"
      );
  });
builder.Services.Configure<FormOptions>(o =>
  {
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;

  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(
  new StaticFileOptions
  {
    
    FileProvider = new PhysicalFileProvider(Path.Combine(@"\\THIERI",@"Users", @"Resources", @"Images")),
    RequestPath = new PathString("/Resources")
  });


app.UseAuthorization();

app.MapControllers();

app.Run();
