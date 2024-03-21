namespace Domain.Exceptions;

public class UnsupportedBrandException : Exception
{
    public UnsupportedBrandException(string brand)
        : base($"Brand \"{brand}\" is unsupported.")
    {
    }
}
