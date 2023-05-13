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


        [HttpGet("{userId}/{netOperator}")]
        public async Task<string> Get(Guid userId, string netOperator)
        {
            //Todo Log User

            var user = await _dbContext.Users.FindAsync(userId);
            var ips = await _dbContext.InternetServiceProviders.Where(c => c.Code == netOperator)
                .SelectMany(c => c.CleanIps)
                .Where(c => c.Active)
                .Select(s => s.IP)
                .OrderBy(c => Guid.NewGuid())
                .Take(10).ToListAsync();


            StringBuilder res = new StringBuilder();
            foreach (var ip in ips)
            {
                switch (user.Server)
                {
                    case "London":
                        res.Append(ConfigGenerator.GetLondonConfig(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, "irnetfree.cf"));
                        break;
                    case "Sweden76":
                        res.Append(ConfigGenerator.GetSweden76Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, "irnetfree.cf"));
                        break;
                    case "Spain31":
                        res.Append(ConfigGenerator.GetSpain31Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, "irnetfree.cf"));
                        break;
                    case "USA89":
                        res.Append(ConfigGenerator.GetUSA89Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, "irnetfree.cf"));
                        break;
                    case "France41":
                        res.Append(ConfigGenerator.GetFrance41Config(user.Password, $"{user.Name}-{netOperator}", "sadal", ip, "irnetfree.cf"));
                        break;
                    default: res.Append("\n");
                        break;
                }
            }

            return res.ToString();
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

                case "irc":
                    return new List<string>()
                    {
                        "80.94.83.141",
                        "89.116.250.22",
                        "89.116.250.90",
                        "80.94.83.121",
                        "45.76.86.197",
                        "45.63.117.116",
                        "192.248.191.3",
                        "80.240.18.58",
                        "80.240.28.19",
                        "45.76.81.159",
                        "45.76.86.53",
                        "45.76.85.208",
                        "45.76.81.18",
                        "170.114.45.224",
                        "199.247.19.103"
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

                default: return GetIpPerInternetOperator("irc");
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
                $"trojan://{password}@{ip}:443?security=tls&sni=sps31-{sni}.{domain}&type=ws&path=/chat&host=spain31.{domain}#Pro%2031%20%F0%9F%87%AA%F0%9F%87%B8-{name}\n";

        public static string GetFrance41Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=fr41-{sni}.{domain}&type=ws&path=/chat&host=france41.{domain}#Trojan%20Server%2041%20%F0%9F%87%AB%F0%9F%87%B7-{name}\n";

        public static string GetUSA89Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=hs89-{sni}.{domain}&type=ws&path=/chat&host=hillsboro.{domain}#Trojan%20Server%2089%20%F0%9F%87%BA%F0%9F%87%B8-{name}\n";
    }

}
