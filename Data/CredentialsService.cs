using Microsoft.Extensions.Options;

namespace WaseemRkab_Portfolio.Data
{
    public class CredentialsService
    {
        public GitHubCredentials GitHubCredentials { get; set; }
        public CredentialsService(IOptions<GitHubCredentials> settings)
        {
            GitHubCredentials = settings.Value;
        }
    }
}
