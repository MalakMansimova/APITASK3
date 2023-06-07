namespace WEB_API.Entities;

public class Car
{
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public DateTime ModelYear { get; set; }
    public double DailyPrice { get; set; }
    public string Description { get; set; }
    public Color? Color { get; set; }
    public Brand? Brand { get; set; }

}
