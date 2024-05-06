using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;

namespace ToolComProjet
{
    public static class GoogleAuthentification
    {
        public static UserCredential Login(string _googleClientID, string _googleClientSecret, string[] _scopes)
        {
            ClientSecrets _secrets = new ClientSecrets()
            {
                ClientId = _googleClientID,
                ClientSecret = _googleClientSecret
            };

            return GoogleWebAuthorizationBroker.AuthorizeAsync(_secrets, _scopes, "user", CancellationToken.None).Result;
        }

        public static async Task<UserCredential> LoginAsync(string _googleClientID, string _googleClientSecret, string[] _scopes)
        {
            ClientSecrets _secrets = new ClientSecrets()
            {
                ClientId = _googleClientID,
                ClientSecret = _googleClientSecret
            };

            return await GoogleWebAuthorizationBroker.AuthorizeAsync(_secrets, _scopes, "user", CancellationToken.None);
        }
    }
}
