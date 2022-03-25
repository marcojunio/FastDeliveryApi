namespace FastDelivery.Shared.Configurations { 
    public class TokenConfiguration{ 

        public TokenConfiguration()
        {
            
        }

        public TokenConfiguration(string issuer,string audience,string secret)
        {
            Secret = secret;
            Issuer = issuer;
            Audience = audience;
        }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret{get;set;}
    }
}