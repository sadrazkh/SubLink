using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SubLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubsController : ControllerBase
    {
        public string Get()
        {
            var res = new StringBuilder(
                "trojan://0szI4jxthC@irc3.irnetfree.ml:443?security=tls&sni=lond.irnetfree.cf&type=ws&path=/protr&host=lond.irnetfree.cf#Server%20Trojan%20GB%20%F0%9F%87%AC%F0%9F%87%A7-Sadal\n");
            res.Append(
                "trojan://ucmjEDyjdB@95.179.150.52:443?security=tls&sni=sws21-sqw.irnetfree.cf&type=ws&path=/chat&host=swiss21.irnetfree.cf#Switzerland%2021%F0%9F%87%A8%F0%9F%87%AD-Sadra@sadrazk\n");
            res.Append(
                "trojan://dcg8dFSpXO@mci.irnetfree.ml:443?security=tls&sni=hs89-zahrhfrse.irnetfree.ml&type=ws&path=/chat&host=hillsboro.irnetfree.ml#Trojan%20Server%2089%20%F0%9F%87%BA%F0%9F%87%B8-Zahrah.FF\n");
            return res.ToString();
        }
    }
}
