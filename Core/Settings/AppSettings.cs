namespace Core.Settings
{
    public class AppSettings
    {
        public ConnectionString ConnectionString { get; set; }
        public TokenSettings TokenSettings { get; set; }
        public CryptographySettings CryptographySettings { get; set; }

    }
}