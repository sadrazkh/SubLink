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

            var user = new { Name = "Sadra", Password = "0lKYuzWcph", Server = "Spain31" };
            var domain = "shopely.xyz";

            if (name == "mci")
            {
                user = new { Name = "Sadra", Password = "vl7FhIWbzV", Server = "Italy10" };
                domain = "sadilo.shop";
                netOperator = " MCI";
            }


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
                    case "Italy10":
                        res.Append(ConfigGenerator.GetItaly10Config(user.Password, $"{user.Name}-{netOperator}", "sadaltest", ip, domain));
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
                        "166.1.131.196","195.201.41.197","65.109.203.209","185.139.230.157","166.1.131.196",
                        "192.200.160.6", "192.200.160.4", "192.200.160.38", "23.227.60.130",
                        "31.43.179.33", "31.43.179.51", "45.85.118.21", "45.85.118.61", "45.85.118.205", "45.85.119.25",
                        "45.85.119.26", "45.85.119.87", "45.85.119.122", "45.85.119.141",
                        "45.85.119.188", "104.16.6.143", "104.16.6.244", "104.16.15.218", "104.16.16.153", "104.16.20.157", "104.16.21.121",
                        "104.16.23.64", "203.22.223.108", "89.116.250.10", "89.116.250.8", "89.116.250.49",
                        "45.159.216.87","203.23.103.31","203.23.106.134","104.31.16.6","104.31.16.4",
                        "104.31.16.11","104.31.16.7","104.31.16.28","104.31.16.27","104.31.16.3",
                        "104.31.16.26","104.31.16.14","104.31.16.13", "104.31.16.17", "104.31.16.16",
                        "104.31.16.29", "104.31.16.30", "104.31.16.12", "104.31.16.5", "104.31.16.25", 
                        "104.31.16.20", "104.31.16.32", "104.31.16.31", "104.31.16.1", "104.31.16.18",
                        "104.31.16.22", "104.31.16.36", "104.31.16.43", "104.31.16.45", "104.31.16.42", "104.31.16.38",
                        "104.31.16.44", "104.31.16.37", "104.31.16.50", "104.31.16.40", "104.31.16.54", "104.31.16.51",
                        "104.31.16.59", "104.31.16.60", "104.31.16.61", "104.31.16.62", "104.31.16.58", "104.31.16.57",
                        "104.31.16.56", "104.31.16.67", "104.31.16.68", "104.31.16.65", "104.31.16.69", "104.31.16.71",
                        "104.31.16.73", "104.31.16.77", "104.31.16.78", "104.31.16.72", "104.31.16.74", "104.31.16.75", 
                        "104.31.16.76", "104.31.16.80", "104.31.16.79", "104.31.16.84", "104.31.16.82", "104.31.16.83", 
                        "104.31.16.85", "104.31.16.81", "104.31.16.86", "104.31.16.91", "104.31.16.87", "104.31.16.93", 
                        "104.31.16.94", "104.31.16.92", "104.31.16.90", "104.31.16.95", "104.31.16.88", "104.31.16.89", 
                        "104.31.16.96", "104.31.16.97", "104.31.16.98", "104.31.16.99", "104.31.16.100", "104.31.16.101",
                        "104.31.16.171", "104.31.16.172", "104.31.16.173", "104.31.16.180", "104.31.16.223", "104.31.16.239",
                        "104.31.16.242", "104.31.16.244", "104.31.16.243", "104.31.16.246", "104.31.16.252", "104.31.16.247",
                        "104.31.16.248", "104.31.16.249", "104.31.16.251", "104.31.16.250", "104.31.16.254", "162.159.24.18", 
                        "162.159.26.226", "162.159.35.87", "162.159.35.227", "162.159.38.8", "162.159.38.100", "162.159.38.118",
                        "162.159.44.16", "162.159.45.39", "162.159.45.87", "45.85.119.41", "203.17.126.133", "45.131.4.199", 
                        "45.131.5.214", "45.159.218.212", "45.159.219.20", "188.42.88.144", "192.65.217.231", "194.152.44.160",
                        "194.36.55.44", "195.245.221.97", "195.245.221.93", "203.13.32.10", "203.23.106.156", "23.227.60.144",
                    };
                case "irc":
                    return new List<string>()
                    {
                        "irc.irnetfree.ml",
                        "irc1.irnetfree.ml",
                        "irc2.irnetfree.ml",
                        "irc3.irnetfree.ml",
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
                case "irc3":
                    return new List<string>()
                    {
                        "166.1.131.196","195.201.41.197","65.109.203.209","185.139.230.157","166.1.131.196",
                        "45.14.174.94",
                        "95.179.240.154",
                        "95.179.241.160",
                        "95.179.243.13",
                        "95.179.244.34",
                        "95.179.244.134",
                        "95.179.244.231",
                        "95.179.244.246",
                        "95.179.245.139",
                        "95.179.245.238",
                        "95.179.246.122",
                        "95.179.247.71",
                        "95.179.248.182",
                        "95.179.250.43",
                        "95.179.252.178",
                        "95.179.254.184",
                        "199.247.19.168",
                        "45.76.85.94",
                        "45.76.85.111",
                        "45.76.85.223",
                        "45.76.86.53",
                        "45.76.86.197",
                        "45.76.91.49",
                        "45.76.92.26",
                        "45.76.92.71",
                        "45.63.117.176",
                        "45.63.117.187",
                        "199.247.0.116",
                        "199.247.0.160",
                        "199.247.4.37",
                        "199.247.4.162",
                        "199.247.5.245",
                        "199.247.6.41",
                        "199.247.6.98",
                        "199.247.11.145",
                        "199.247.19.168",
                        "199.247.20.44",
                        "199.247.21.147",
                        "199.247.21.169",
                        "199.247.22.126",
                        "199.247.22.228",
                        "199.247.23.75",
                        "80.240.28.64",
                        "104.238.176.244",
                        "104.207.130.42",
                        "154.84.175.87",
                        "154.84.175.111",
                        "154.84.175.147",
                        "154.84.175.170",
                        "136.244.81.179",
                        "136.244.81.173",
                        "136.244.84.9",
                        "136.244.84.63",
                        "136.244.86.248",
                        "136.244.88.10",
                        "136.244.89.149",
                        "192.248.179.53",
                        "170.114.45.6",
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

        public static string GetItaly10Config(string password, string name, string sni, string ip, string domain)
            =>
                $"trojan://{password}@{ip}:443?security=tls&sni=italy10-{sni}.{domain}&type=ws&path=/chat&host=italy10.{domain}#Pro%2010%20%F0%9F%87%AE%F0%9F%87%B9-{name}\n";
    }

}
