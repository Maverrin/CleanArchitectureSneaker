namespace Application.DTOs;

public class SneakerDTO : BaseDTO
{
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public int Price { get; set; }
    public float Size { get; set; }
    public int Year { get; set; }
    public float Rating { get; set; }
}
