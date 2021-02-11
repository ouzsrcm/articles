namespace Articles.Business.Dtos
{
    public class UserDto : BaseDto
    {
        public int ApiUserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
