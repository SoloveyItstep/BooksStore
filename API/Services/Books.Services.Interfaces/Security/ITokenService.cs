namespace Books.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(string userName);
    }
}
