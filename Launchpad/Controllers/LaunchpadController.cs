using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Launchpad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Launchpad.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LaunchpadController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        //ILogger _logger;

        //LaunchpadController(ILogger<LaunchpadController> logger)
        //{
        //    _logger = logger;
        //}
        // GET: api/Launchpad
        [HttpGet]
        public IEnumerable<LaunchPadInfo> Get()
        {
            //Get launch pad info from SpaceX WS.
            IEnumerable<LaunchPadInfo> launchPadInfo = GetFromWS(); //For DB source, create GetFromDB().  Using models for Entity Framework.

            //Returns JSON.
            return launchPadInfo;
        }

        private IEnumerable<LaunchPadInfo> GetFromWS()
        {
            var launchPadResults = ProcessLaunchPad().Result;
            List<LaunchPadInfo> padInfoList = new List<LaunchPadInfo>();

            foreach (LaunchPad padResult in launchPadResults)
            {
                LaunchPadInfo padInfo = new LaunchPadInfo { id = padResult.id, name = padResult.full_name, status = padResult.status };
                padInfoList.Add(padInfo);
            }

            return padInfoList;
        }


        // GET: api/Launchpad/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Launchpad
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Launchpad/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private static async Task<List<LaunchPad>> ProcessLaunchPad()
        {
            //Getting data asynchronously.
            var serializer = new DataContractJsonSerializer(typeof(List<LaunchPad>));
            var streamTask = client.GetStreamAsync("https://api.spacexdata.com/v2/launchpads");
            var launchPads = serializer.ReadObject(await streamTask) as List<LaunchPad>;
            return launchPads;
        }
    }
}
