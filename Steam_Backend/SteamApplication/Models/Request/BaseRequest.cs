namespace SteamApplication.Models.Request
{
    public class BaseRequest
    {
        public int limit { get; set; } = 100;
        public int offset { get; set; } = 0;
    }
}
