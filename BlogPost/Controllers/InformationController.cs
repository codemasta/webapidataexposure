using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPost.Data;
using BlogPost.Helper;
using BlogPost.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BlogPost.Controllers
{
    [Route("api/[controller]")]
    public class InformationController : Controller
    {
        private static Clients _clients;

        public InformationController(IOptions<Clients> clients)
        {
            _clients = clients.Value;
        }

        [HttpGet()]
        public IActionResult Get([FromQuery]string number , [FromQuery]string clientName)
        {
            var response = new Response();

            foreach (var info in ClientData())
            {
                if (info.Key == clientName)
                {
                    var props = info.Value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var result = DataRepository.GetData().FirstOrDefault(c => c.PhoneNumber == number);

                    foreach (var prop in props)
                    {
                        if (result != null)
                        {
                            response[prop] = GetPropertyValue(result, prop);
                        }
                    }
                }
            }

            
            return new ObjectResult(JsonConvert.SerializeObject(response.Get(), Formatting.Indented));
        }

        private static Dictionary<string, string> ClientData()
        {

            var clients = _clients.Banks.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var clientInfo = new Dictionary<string, string>();

            foreach (var client in clients)
            {
                var split = client.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                clientInfo.Add(split.First(), split.Last());
            }

            return clientInfo;
        }

        private static string GetPropertyValue(Data.Data data, string property)
        {
            return data.GetType().GetProperty(property)?.GetValue(data, null).ToString() ?? string.Empty;
        }
    }
}