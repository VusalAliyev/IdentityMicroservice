using IdentityServer4.Models;

namespace IdentityMicroservice.AuthServer
{
    public class Config
    {
        //Hangi API'lara erişim 
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>()
            {
                 new ApiResource("resource_api1")
                 {
                     Scopes = { "api1.read", "api1.write", "api1.update" },
                     ApiSecrets = new[] { new Secret("secretapi1".Sha256()) }
                 },
                 new ApiResource("resource_api2")
                 {
                     Scopes={"api2.read","api2.write","api2.update" },
                     ApiSecrets=new[]{new Secret("secretapi2".Sha256())}
                 }
            };
        }

        //Hangi API'lara hangi crud izni
        public static IEnumerable<ApiScope> GetScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope("api1.read","api1 ucun oxuma icazesi"),
                new ApiScope("api1.write","api1 ucun yazma icazesi"),
                new ApiScope("api1.update","api1 ucun guncelleme icazesi"),

                new ApiScope("api2.read","api2 ucun oxuma icazesi"),
                new ApiScope("api2.write","api2 ucun yazma icazesi"),
                new ApiScope("api2.update","api2 ucun guncelleme icazesi"),
            };
        }

        //Clientləri tanımlıyoruz
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId="Client1",
                    ClientName="Client 1 web app",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read","api1.update","api1.write"}
                },
                new Client()
                {
                    ClientId="Client2",
                    ClientName="Client 2 web app",
                    ClientSecrets=new[] {new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={"api1.read"}
                }
            };
        }
    }
}
