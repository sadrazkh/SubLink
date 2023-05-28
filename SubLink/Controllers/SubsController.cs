using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SubLink.Data;

namespace SubLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SubsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet("{name}")]

        public async Task<string> Get(string name)
        {
            //Todo Log User

            //var user = await _dbContext.Users.FindAsync(userId);
            //var ips = await _dbContext.InternetServiceProviders.Where(c => c.Code == netOperator)
            //    .SelectMany(c => c.CleanIps)
            //    .Where(c => c.Active)
            //    .Select(s => s.IP)
            //    .OrderBy(c => Guid.NewGuid())
            //    .Take(10).ToListAsync();

            var netOperator = " IRC";

            var ips = ConfigGenerator.GetIpPerInternetOperator(name);

            var user = new {Name = "Sadra", Password = "0lKYuzWcph", Server = "Spain31" };

            var domain = "shopely.xyz";

            StringBuilder res = new StringBuilder();
            foreach (var ip in ips)
            {
                switch (user.Server)
                {
                    case "London":
                        res.Append(ConfigGenerator.GetLondonConfig(user.Password, $"{user.Name}-{netOperator}", "sadaltest", ip, domain));
                        break;
                    case "Sweden76":
                        res.Append(ConfigGenerator.GetSweden76Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, domain));
                        break;
                    case "Spain31":
                        res.Append(ConfigGenerator.GetSpain31Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, domain));
                        break;
                    case "USA89":
                        res.Append(ConfigGenerator.GetUSA89Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, domain));
                        break;
                    case "France41":
                        res.Append(ConfigGenerator.GetFrance41Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, domain));
                        break;
                    default:
                        res.Append("\n");
                        break;
                }
            }

            //return res.ToString();

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(res.ToString());
            return System.Convert.ToBase64String(plainTextBytes);
        }


    }

    public class Config
    {
        public string password { get; set; }
        public string Server { get; set; }
        public string Name { get; set; }
    }

    public static class ConfigGenerator
    {
        public static List<string> GetIpPerInternetOperator(string internetOperator)
        {
            switch (internetOperator)
            {
                case "mci":
                    return new List<string>()
                    {
                        "45.85.119.5",
                        "45.159.216.12",
                        "45.159.216.87"
                    };

                case "irc1":
                    return new List<string>()
                    {
                        "95.179.241.60",
                        "95.179.243.130",
                        "95.179.243.184",
                        "95.179.244.214",
                        "95.179.245.139",
                        "95.179.246.202",
                        "95.179.250.81",
                        "95.179.255.134",
                        "95.179.255.199",
                        "199.247.19.174",
                        "45.76.83.197",
                        "45.76.85.173",
                        "45.76.92.26",
                        "45.76.92.71",
                        "95.179.168.124",
                        "95.179.169.223",
                        "45.63.119.169",
                        "199.247.0.16",
                        "199.247.0.116",
                        "199.247.0.160",
                        "199.247.0.186",
                        "199.247.0.226",
                        "199.247.0.236",
                        "199.247.2.131",
                        "199.247.2.255",
                        "199.247.4.212",
                        "199.247.5.61",
                        "199.247.9.190",
                        "199.247.17.2",
                        "199.247.20.252",
                        "199.247.21.147",
                        "199.247.22.54",
                        "199.247.22.44",
                        "199.247.23.172",
                        "199.247.28.164",
                        "136.244.81.173",
                        "136.244.86.248",
                        "136.244.87.9",
                        "136.244.88.16",
                        "95.179.202.57",
                        "95.179.240.154",
                        "95.179.241.150",
                        "95.179.244.134",
                        "95.179.248.77",
                        "95.179.250.43",
                        "95.179.250.86",
                        "95.179.251.153",
                        "95.179.254.20",
                        "45.76.91.228",
                        "45.63.119.55",
                        "45.63.119.118",
                        "199.247.5.9",
                        "199.247.5.70",
                        "95.179.243.13",
                        "95.179.247.71",
                        "95.179.247.168",
                        "95.179.250.152",
                        "95.179.252.143",
                        "95.179.254.184",
                        "45.76.85.135",
                        "45.76.86.53",
                        "45.76.86.197",
                        "45.76.89.166",
                        "95.179.168.130",
                        "95.179.169.117",
                        "45.63.116.105",
                        "45.63.117.136",
                        "45.63.119.209",
                        "199.247.6.98",
                        "199.247.22.126",
                        "136.244.87.193",
                        "95.179.190.154",
                        "95.179.135.195",
                        "95.179.255.3",
                        "45.63.116.249",
                        "45.63.119.147",
                        "95.179.242.87",
                        "95.179.242.247",
                        "95.179.242.241",
                        "95.179.246.191",
                        "95.179.248.215",
                        "95.179.253.40"
                    };
                case "irc2":
                    return new List<string>()
                    {
                        "95.179.244.42",
                        "95.179.244.134",
                        "95.179.244.231",
                        "95.179.245.139",
                        "95.179.249.171",
                        "95.179.250.249",
                        "199.247.19.88",
                        "45.76.83.81",
                        "45.76.85.225",
                        "45.76.89.54",
                        "45.76.89.134",
                        "95.179.168.196",
                        "95.179.169.22",
                        "45.63.116.158",
                        "199.247.0.123",
                        "199.247.0.116",
                        "199.247.5.158",
                        "199.247.11.145",
                        "199.247.17.167",
                        "199.247.19.88",
                        "199.247.20.44",
                        "199.247.21.114",
                        "199.247.21.147",
                        "199.247.22.62",
                        "199.247.22.126",
                        "199.247.23.38",
                        "136.244.84.224",
                        "136.244.86.50",
                        "136.244.87.27",
                        "136.244.87.116",
                        "136.244.87.178",
                        "136.244.89.149",
                        "95.179.186.177",
                    };
                case "mkb":
                    return new List<string>()
                    {
                        "80.240.30.10",
                        "95.179.253.245",
                        "95.179.246.202",
                        "95.179.242.162"
                    };
                case "ztl":
                    return GetIpPerInternetOperator("irc");
                    break;
                case "mbt":
                    return GetIpPerInternetOperator("irc");
                    break;

                default: return GetIpPerInternetOperator("mkb");
            }

        }


        public static string GetLondonConfig(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=lndgb-{sni}.{domain}&type=ws&path=/protr&host=lond.{domain}#Server%20Trojan%20GB%20%F0%9F%87%AC%F0%9F%87%A7-{name}\n";

        public static string GetSweden76Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=swd76-{sni}.{domain}&type=ws&path=/chat&host=sweden76.{domain}#Pro%2076%20%F0%9F%87%B8%F0%9F%87%AA-{name}\n";

        public static string GetSpain31Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=sps31-{sni}.{domain}&type=ws&path=/chat&host=spain31.{domain}#Pro 31 🇪🇸-{name}\n";

        public static string GetFrance41Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=fr41-{sni}.{domain}&type=ws&path=/chat&host=france41.{domain}#Trojan%20Server%2041%20%F0%9F%87%AB%F0%9F%87%B7-{name}\n";

        public static string GetUSA89Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=hs89-{sni}.{domain}&type=ws&path=/chat&host=hillsboro.{domain}#Trojan%20Server%2089%20%F0%9F%87%BA%F0%9F%87%B8-{name}\n";
    }

}
