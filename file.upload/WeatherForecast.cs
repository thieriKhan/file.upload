namespace file.upload
{
  public class WeatherForecast
  {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
  }


  public abstract class IGlobal
  {

    public int a { get; set; }
    public int b { get; set; }


  }


  public class Global : IGlobal
  {

    public virtual int a1 { get; set; }
    public int b1 { get; set; }
    public int c1 { get; set; }
    public int a2 { get; set; }
    public int b2 { get; set; }
    public int c2 { get; set; }


  }

}
