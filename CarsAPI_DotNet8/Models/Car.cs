namespace CarsAPI_DotNet8.Models
{
    public class Car
    {
        public int Id { get; set; }
        public required string Make { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public string Color { get; set; } = string.Empty;



    }
}
