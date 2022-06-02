using file.upload.Model;
using Microsoft.EntityFrameworkCore;

namespace file.upload.Data_context;

public class DataContext: DbContext
{
  
  public DataContext( DbContextOptions<DataContext> options): base(options)
  {

  }
  public DbSet<MyFile> myFile { get; set; }

}
