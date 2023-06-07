namespace WEB_API.Entities.Dtos.Cars
{
    public class GetCarDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
