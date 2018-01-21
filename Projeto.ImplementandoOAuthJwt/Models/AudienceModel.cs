namespace Projeto.ImplementandoOAuthJwt.Models
{
    public class AudienceModel
    {
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
        public string ApplicationName { get; set; }
    }
}