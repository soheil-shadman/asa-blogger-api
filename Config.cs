namespace AsaBloggerApi{
    public class Config{
        public string? JwtSecret ;
        public string? Issuer ;
        public double JwtTime=360 ;

        private static Config? _instance;
    public static Config InitConfig(string? JwtSecret,string? Issuer)
        {
            _instance ??= new Config();
            _instance.Issuer=Issuer;
            _instance.JwtSecret=JwtSecret;

            return _instance;
        }
    public static Config? GetConfig(){

        return _instance;
    }    

    }
}