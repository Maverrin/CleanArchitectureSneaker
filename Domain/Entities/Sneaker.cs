using Domain.Common;

namespace Domain.Entities;

public sealed class Sneaker : BaseEntity
{
    public string? Name { get; set; }

    //Enum
    public string? Brand { get; set; }

    //decimal
    public int Price { get; set; }
    public float Size { get; set; }

    //DateTime
    public int Year { get; set; }
    public float Rating { get; set; }
    
}
