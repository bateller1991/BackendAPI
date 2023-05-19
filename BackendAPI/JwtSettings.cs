namespace BackendAPI
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public int TokenLifetimeInMinutes { get; set; }
    }

}
