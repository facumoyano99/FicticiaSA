namespace FicticiaSA.Models.Dtos.UserDtos
{
    public class UserTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
